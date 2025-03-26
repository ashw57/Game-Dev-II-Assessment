using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    protected static GameManager _GM { get { return GameManager.instance; } }
    protected static TargetManager _TM { get { return TargetManager.instance; } }
    protected static PlayerMovement _PLAYER { get { return PlayerMovement.instance; } }
    protected static UiManager _UI {  get { return UiManager.instance; } }

    public Transform GetClosestObject(Transform _origin, List<GameObject> _objects)
    {
        if (_objects == null || _objects.Count == 0)
            return null;

        float distance = Mathf.Infinity;
        Transform closest = null;

        foreach (GameObject go in _objects)
        {
            float currentDistance = Vector3.Distance(_origin.transform.position, go.transform.position);
            if (currentDistance  < distance)
            {
                distance = currentDistance;
                closest = go.transform;
            }
        }
        return closest;
    }

    public Transform GetClosestObject(Transform _origin, List<Target> _objects)
    {
        if (_objects == null || _objects.Count == 0)
            return null;

        float distance = Mathf.Infinity;
        Transform closest = null;

        foreach (Target go in _objects)
        {
            float currentDistance = Vector3.Distance(_origin.transform.position, go.transform.position);
            if (currentDistance < distance)
            {
                distance = currentDistance;
                closest = go.transform;
            }
        }
        return closest;
    }


    public static List<T> ShuffleList<T>(List<T> _list)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            T temp = _list[i];
            int randomIndex = UnityEngine.Random.Range(i, _list.Count);
            _list[i] = _list[randomIndex];
            _list[randomIndex] = temp;
        }
        return _list;
    }


}
