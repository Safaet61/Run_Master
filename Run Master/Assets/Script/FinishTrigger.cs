using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public GameObject finishLine;

    private bool revealed = false;

    private void Start()
    {
        finishLine.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (revealed) return;
        if (!other.CompareTag("Player")) return;

        revealed = true;

        finishLine.SetActive(true);
        Destroy(gameObject);
    }
}