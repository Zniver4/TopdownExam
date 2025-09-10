using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidad = 3f;
    public float health = 50f;
    public float damageToPlayer = 10f; 
    public float attackCooldown = 1f;
    private float nextAttackTime = 0f;

    private Transform jugador;

    void Start()
    {
        GameObject objJugador = GameObject.FindGameObjectWithTag("Player");
        if (objJugador != null)
        {
            jugador = objJugador.transform;
        }
    }

    void Update()
    {
        if (jugador != null)
        {
            Vector3 direccion = (jugador.position - transform.position).normalized;
            transform.position += direccion * velocidad * Time.deltaTime;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"{gameObject.name} recibió {damage} de daño. Vida restante: {health}");

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} ha muerto.");
        gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Time.time >= nextAttackTime)
        {
            Vida player = other.GetComponent<Vida>();
            if (player != null)
            {
                player.TakeDamage(damageToPlayer);
                nextAttackTime = Time.time + attackCooldown; // 🔹 espera antes del siguiente golpe
            }
        }
    }
}
