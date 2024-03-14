using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //DEATH ZONE REPLACEMENT FALLING COUNTER
    private float fallStartTime;
    private bool isFalling;
    private GameManager gameManager; //game manager object
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    private int index = 0;
    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer myspriteRenderer;
    private bool isGrounded;
    private bool hasJumped;

    // Start is called before the first frame update
    void Start()
    {
        //game manager
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        //rest
        myrigidbody2D = GetComponent<Rigidbody2D>();
        myspriteRenderer = GetComponent<SpriteRenderer>();
        myrigidbody2D.gravityScale = 1f; // Set the gravity scale to 1
        StartCoroutine(WalkCoRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.2f);

        // Get horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move the player horizontally
        myrigidbody2D.velocity = new Vector2(horizontalInput * playerSpeed, myrigidbody2D.velocity.y);

        // Check for jump input and if the player is grounded and hasn't jumped yet
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !hasJumped)
        {
            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, playerJumpForce);
            hasJumped = true;
        }
        // DEATH ZONE REPLACEMENT
        if (isFalling && Time.time - fallStartTime >= 9.0f)
        {
            gameManager.RestartScene(); // Restart the scene if falling for 5 seconds or more
        }
    }

    // Check if the player has landed after jumping
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasJumped = false;
        }
        //DEATH ZONE REPLACEMENT
        if (collision.collider.CompareTag("Ground")) // If the player touches the ground
        {
            isFalling = false; // Player is no longer falling
        }
    }

    // DEATH ZONE REPLACEMENT
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) // If the player stays on the ground
        {
            isFalling = false; // Player is not falling
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) // If the player leaves the ground
        {
            isFalling = true; // Player is falling
            fallStartTime = Time.time; // Record the start time of the fall
        }
    }

    //subrutina de caminata
    IEnumerator WalkCoRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            myspriteRenderer.sprite = mySprites[index];
            index = (index + 1) % mySprites.Length; // Wrap around the array length
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ItemGood")) // If the player touches a coin
        {
            gameManager.IncreaseScore(); // Increase the score in the GameManager
            Destroy(other.gameObject); // Destroy the coin
        }
        else if (other.CompareTag("ItemBad") || other.CompareTag("DeathZone")) // If the player touches an enemy or the death zone
        {
            gameManager.RestartScene(); // Restart the scene using the GameManager
        }
    }
}
