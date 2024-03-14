using UnityEngine;

public class EnemyApproach : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public float speed = 2f; // Speed at which the enemy approaches the player

    void Update()
    {
        if (player == null)
            return;

        // Calculate the direction from the enemy to the player
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();

        // Move the enemy towards the player
        transform.position += direction * speed * Time.deltaTime;
    }
}
