using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_speed : MonoBehaviour
{
    // Declare a variable as needed
    [SerializeField] float movementSpeed = 2f;
    private Rigidbody2D rb;
    private float playerSpeed;
    [SerializeField] int bulletHit = 0;
    [SerializeField] int bulletsToDestroy = 10;
    public Transform shootPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Set the initial position of the enemy to the right side of the screen
        Vector3 initialPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, 0f));
        transform.position = new Vector3(initialPosition.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (gameObject != null)
        // Move the enemy to the right in the horizontal direction
        {
            rb.velocity = new Vector2(movementSpeed, 0f); 
        }            
          
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) 
        {
            // Increment the bullets hit count
            bulletHit++;

            if (gameObject != null && !IsDestroyed())
            {
                // checked that bulletHit is equal or greater than bulletsToDestroy
                if (bulletHit >= bulletsToDestroy)
                {
                    DestroyEnemy();
                }
            }
        }
        void DestroyEnemy()
        {
            if (!IsDestroyed())
            {
                // Destroy enemy game object
                Destroy(gameObject);
            }
        }

        bool IsDestroyed()
        {
            // Check if the object has been destroyed
            return gameObject == null || !gameObject.activeSelf;
        }
    }
}

