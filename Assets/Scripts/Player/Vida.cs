using UnityEngine;
using TMPro;
public class Vida : MonoBehaviour
{
    public float health = 100f;
    public GameObject gameOverCanvas;
    public TMP_Text healthText;
    void Start()
    {
        UpdateHealthUI();

        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(false);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"Jugador recibió {damage} de daño. Vida restante: {health}");

        UpdateHealthUI();

        if (health <= 0f)
        {
            Die();
        }
    }

    [ContextMenu("Die")]
    void Die()
    {
        Debug.Log("Jugador ha muerto.");
        gameObject.SetActive(false); 

        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true); 
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
            healthText.text = $"Vida: {Mathf.Max(0, Mathf.RoundToInt(health))}";
    }
}
