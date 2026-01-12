using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSystem : MonoBehaviour
{

    public enum Gatetype{Add, Minus, Multiply}
    public Gatetype gatetype;
    public int gatevalue;
    public CrowdSystem cs;
    private bool used=false;


    private void OnTriggerEnter(Collider other)
    {
        if (used) return;
        if (!other.CompareTag("Player")) return;

        used = true;

        switch (gatetype)
        {
            case Gatetype.Add:
                cs.addfollowers(gatevalue);
                break;

            case Gatetype.Minus:
                cs.removefollower(gatevalue);
                break;

            case Gatetype.Multiply:
                cs.multiflyadd(gatevalue);
                break;
        }

        Destroy(gameObject);
    }
}
