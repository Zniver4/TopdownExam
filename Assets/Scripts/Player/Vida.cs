using UnityEngine;

public class Vida : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"Jugador recibió {damage} de daño. Vida restante: {health}");

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Jugador ha muerto.");
        gameObject.SetActive(false); // 🔹 o respawn, según tu diseño
    }
}
