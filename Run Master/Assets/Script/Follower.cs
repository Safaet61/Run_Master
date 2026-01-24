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
            StartCoroutine(MeltAndRemove());
        }
    }

    private IEnumerator MeltAndRemove()
    {
        cs.RemoveSpecificFollower(transform);

        float duration = 0.5f; 
        float elapsed = 0f;
        Vector3 originalScale = transform.localScale;

        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = Vector3.zero;
        Destroy(gameObject);
    }
}
