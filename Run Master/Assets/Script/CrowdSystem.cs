using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    public Transform crowdparent;
    public GameObject follower;
    public float spwanradious = 5f;
    private List<Transform> crowd = new List<Transform>();

    void Start()
    {
        addfirst();
        addfollowers(10);
        
    }



    void addfollowers(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            addfollower();
        }
    }
    void addfollower()
    {

        GameObject newfollower = Instantiate(follower);
        newfollower.transform.SetParent(crowdparent );
        Vector2 circle = Random.insideUnitCircle * spwanradious;
        Vector3 pos = new Vector3(circle.x, 0, circle.y);
        newfollower.transform.localPosition = pos;
        crowd.Add(newfollower.transform);
       
    }
     


    void addfirst()
    {
        GameObject firstfollower = Instantiate(follower);
        firstfollower.transform.SetParent(crowdparent);
        firstfollower.transform.localPosition = Vector3.zero;
    }
}
