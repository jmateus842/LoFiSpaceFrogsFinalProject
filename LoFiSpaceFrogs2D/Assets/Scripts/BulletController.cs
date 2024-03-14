using UnityEngine;

public class BulletController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ItemGood")) // If the bullet touches an object tagged as ItemGood
        {
            Destroy(other.gameObject); // Destroy the ItemGood object
            Destroy(gameObject); // Destroy the bullet
        }
        else if (other.CompareTag("ItemBad")) // If the bullet touches an object tagged as ItemBad
        {
            Destroy(other.gameObject); // Destroy the ItemBad object
            Destroy(gameObject); // Destroy the bullet
            GameManager gameManager = FindObjectOfType<GameManager>(); // Find the GameManager
            if (gameManager != null)
            {
                gameManager.IncreaseScore(); // Increase the score only if the bullet hits an ItemBad object
            }
            else
            {
                Debug.LogWarning("GameManager not found!"); // Log a warning if GameManager not found
            }
        }
    }
}
