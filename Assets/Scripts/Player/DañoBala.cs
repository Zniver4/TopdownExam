using UnityEngine;

public class DañoBala : MonoBehaviour
{
    public float damage = 10f;

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        BulletPool.Instance.ReturnBullet(gameObject);
    }
}

