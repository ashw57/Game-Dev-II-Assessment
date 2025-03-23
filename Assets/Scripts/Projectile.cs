using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool collided;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Player" && !collided)
        {
            collided = true;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 3);
        }

        if (collision.collider.CompareTag("Target"))
        {
            Destroy(collision.collider.gameObject, 1f);
        }
    }
}
