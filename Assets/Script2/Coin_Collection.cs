using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Collection : MonoBehaviour
{
    [SerializeField] private AudioSource collectionSoundEffect;
    void OnTriggerEnter2D(Collider2D collision)
    {
        
            // Check if the object colliding with the coin is not null and has the "Player" tag
            if (collision != null && collision.CompareTag("Player"))
            {
                // Destroy the coin GameObject
                Destroy(gameObject);
            collectionSoundEffect.Play();
            }
       
    }
   
}
