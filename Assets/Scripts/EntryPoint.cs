using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    public GameObject TriggerZone;

    public GameObject Trees;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Trees.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Trees.gameObject.SetActive(true);
        }
    }
}
