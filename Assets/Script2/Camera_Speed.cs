using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Speed : MonoBehaviour
{
    [SerializeField] float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
