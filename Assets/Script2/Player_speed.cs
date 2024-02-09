using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_speed : MonoBehaviour
{ 
    // Declare a variable

    [SerializeField] float speed = 2f; 
    public float jumpForce = 10f; 
    public Transform firingPoint; 
    public GameObject bulletPrefab; 
    public float movementSpeed = 1.75f; 
    [SerializeField] private AudioSource playerDeathAudio; 

    private Rigidbody2D rb;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // player starts on the ground
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player continuously to the right
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Get the camera's current position
        Vector3 cameraPosition = Camera.main.transform.position;

        // Update the camera's position to follow the player on the x-axis
        cameraPosition.x = Mathf.Max(transform.position.x, cameraPosition.x);

        Camera.main.transform.position = cameraPosition;

        // Check for touch input on the left and right sides of the screen
        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x < Screen.width / 2)
            {
                // Touch left side of the screen for jump
                if (touch.phase == TouchPhase.Began && isGrounded)
                {
                    Jump();
                }
            }
            if (touch.position.x >= Screen.width / 2)
            {
                // Touch right side of the screen for fire
                if (touch.phase == TouchPhase.Began)
                {
                    Fire();
                }
            }
        }
    }
    void Fire()
    {
        // Instantiate a projectile at the fire point
        GameObject bullet = Instantiate(bulletPrefab , firingPoint.position, firingPoint.rotation);

        // Ensure the Bullet script is present on the instantiated bullet object
        Bullet bulletScript = bullet.AddComponent<Bullet>();
      
        if (bulletScript == null)
        {
            bulletScript = bullet.AddComponent<Bullet>();
        }
    }
    void Jump()
    {
        // Check if Rigidbody2D component is present
        if (rb != null)
        {
            // Add a force to make the player jump
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogError("Rigidbody2D component is missing on the player GameObject.");
        }
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player has collided with a ground object
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Player is grounded
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the player GameObject
            Destroy(gameObject);
            playerDeathAudio.Play();

            // RestartGame method after 2 seconds
            Invoke("RestartGame", 2f);
        }
    }
    private void RestartGame()
    {
        // Restart to the GameLevel
        UnityEngine.SceneManagement.Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene.name);
    }
}

    


