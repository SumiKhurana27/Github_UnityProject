using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;

    private void Start()
    {
        gameObject.tag = "Bullet";
    }

    // Update is called once per frame
    void Update()
    {
        // Move the bullet horizontally to the right
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Destroy the bullet if it goes off-screen
        if (transform.position.x > Camera.main.ViewportToWorldPoint(new Vector3(1.1f, 0, 0)).x)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Get the EnemyHealth component from the collided enemy
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                // Call the TakeDamage method of the enemy's health script
                enemyHealth.TakeDamage(damage);
            }

            // Destroy the bullet upon hitting the enemy
            Destroy(gameObject);
        }
    }

}
