using UnityEngine;

public class EnemySetup : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject

    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player"); // Find the player GameObject in the scene
    }
}
