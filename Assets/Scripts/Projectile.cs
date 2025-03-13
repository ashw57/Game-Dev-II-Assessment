using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform barrelEnd;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectile, barrelEnd.position, barrelEnd.rotation);
        }
    }
}
