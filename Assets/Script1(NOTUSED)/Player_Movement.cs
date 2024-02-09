using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Movement : MonoBehaviour
{
    float movementSpeed = 2f;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    { 
        // Get animator from Component
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        // Declare variable for x Axis
        Vector3 movement = new Vector3(1f, 0f, 0f) * movementSpeed * Time.deltaTime;

        // Move the player
        transform.Translate(movement);

        // execute the run animation 
        animator.SetFloat("Speed", movement.magnitude);  
    }  
 }
    



