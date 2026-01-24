using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public PlayerMovement playerMovement;
    

    private void OnTriggerEnter(Collider other)
    {
        
        if (!other.CompareTag("Player")) return;
        
            playerMovement.GameOver();
            Destroy(gameObject);
        
    }
}
