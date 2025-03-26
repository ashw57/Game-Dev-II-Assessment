using UnityEngine;

public class Projectile : GameBehaviour
{
    private bool collided;

    private int damage = 1;

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
            if (collision.gameObject.GetComponent<Target>() != null)
                collision.gameObject.GetComponent<Target>().Hit(damage);
            Destroy(gameObject);
        }
    }
}
