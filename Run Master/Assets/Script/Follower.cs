using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Follower : MonoBehaviour
{
   
    private CrowdSystem cs;
    private bool dead = false;

    private void Start()
    {
        cs = GetComponentInParent<CrowdSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (dead) return;

        if (other.CompareTag("Obstacle"))
        {
            dead = true;
            cs.RemoveSpecificFollower(transform);
        }
    }
}