using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    // Adjust the speed of enemy as needed
    [SerializeField] float enemySpeed = 1.75f;
    private Rigidbody2D rb;
    private float playerSpeed;
    private Player_speed playerScript;


    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Enemy_Controller Awake");
    
    
    // Get the Rigidbody2D component on start
    rb = GetComponent<Rigidbody2D>();
        // Assuming the player is tagged as "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Get the player's speed
            playerScript = player.GetComponent<Player_speed>();
            if (playerScript != null)
            {
                playerSpeed = playerScript.movementSpeed;
            }
        }
        // Set the initial position of the enemy to the right side of the screen
        Vector3 initialPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, 0f));
        transform.position = new Vector3(initialPosition.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Enemy_Controller Update");
        // Move the enemy to the right at 3/4 of the player's speed
        rb.velocity = new Vector2(playerSpeed * enemySpeed , rb.velocity.y);
    }
}
