using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Apple;

public class FiringPoints : MonoBehaviour
{
    public Camera cam;
    public GameObject projectile;

    public float projectileSpeed = 30;
    private float timeToFire;
    public float fireRate = 4;

    public Transform LHFirePoint, RHFirePoint;
    private bool leftHand;

    private Vector3 destination;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            ShootProjectile();


        }
    }

    void ShootProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            destination = hit.point;

        }
        else
        {
            destination = ray.GetPoint(1000);
        }

        if(leftHand)
        {
            leftHand = false;
            InstantiateProjectile(LHFirePoint);
        }
        else
        {
            leftHand = true;
            InstantiateProjectile(RHFirePoint);
        }

        
    }

    void InstantiateProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().linearVelocity = (destination - firePoint.position).normalized * projectileSpeed;
    }
}
