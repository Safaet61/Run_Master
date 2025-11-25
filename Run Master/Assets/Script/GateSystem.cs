using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSystem : MonoBehaviour
{

    public enum Gatetype{Add, Minus, Multiply}
    public Gatetype gatetype;
    public int gatevalue;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        CrowdSystem cs = FindObjectOfType<CrowdSystem>();
        if (gatetype == Gatetype.Add)
        {
            cs.addfollowers(gatevalue);
            Destroy(gameObject);
        }
        else if (gatetype == Gatetype.Minus)
        {
            cs.removefollower(gatevalue);
            Destroy(gameObject);
        }
        else if (gatetype == Gatetype.Multiply)
        {
            cs.multiflyadd(gatevalue);
            Destroy(gameObject);
        }

    }


}
