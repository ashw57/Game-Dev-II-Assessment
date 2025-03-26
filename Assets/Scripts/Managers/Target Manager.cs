using System.Collections;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public enum TargetClass
{
    Beanz,
    Pickle,
    Nyeh
}

public enum PatrolType
{
    Random
}

public class TargetManager : Singleton<TargetManager>
{
    public int initialSpawnCount = 6;
    public float initialSpawnDelay = 1;

    public Transform[] spawnPoints;
    public GameObject[] targetClass;
    public List<Target> targets;

    public int TargetCount => targets.Count;
    public bool NoTargets => targets.Count == 0;

    public Transform GetRandomSpawnPoint => spawnPoints[Random.Range(0, spawnPoints.Length)];

    private void Start()
    {
        StartCoroutine(SpawnWithDelay(initialSpawnCount, initialSpawnDelay));
    }
  
    private IEnumerator SpawnWithDelay (int _spawnCount, float _spawnDelay)
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            yield return new WaitForSeconds(_spawnDelay);
            if (_GM.currentGameState == GameState.Playing)
            SpawnTarget();
        }
    }

    private void SpawnTargets()
    {
        for (int i = 0; i < initialSpawnCount; i++)
        {
            SpawnTarget();
        }
    }

    public void SpawnTarget()
    {

        int rndTarget = Random.Range(0, targetClass.Length);
        int rndSpawn = Random.Range(0, spawnPoints.Length);

        GameObject target = Instantiate(targetClass[rndTarget], spawnPoints[rndSpawn].transform.position, spawnPoints[rndSpawn].transform.rotation);
        target.GetComponent<Target>().Initialize(GetRandomSpawnPoint);
        targets.Add(target.GetComponent <Target>());
        _UI.UpdateTarget(TargetCount);
    }

    public void KillTarget(Target _target)
    {
        GameManager.instance.AddScore(_target.MyScore);
        Destroy(_target.gameObject);
        targets.Remove(_target);
        _GM.AddScore(_target.MyScore);
        _UI.UpdateTarget(TargetCount);
    }

    private void KillRandomTarget()
    {
        if (NoTargets)
            return;

        int rndTarget = Random.Range(0, TargetCount);
        KillTarget(targets[rndTarget]);
    }

    private void KillClosestTarget()
    {
        Transform closest = GetClosestObject(_PLAYER.transform, targets).transform;
        print(closest.name);
        KillTarget(closest.GetComponent<Target>());
    }
}
