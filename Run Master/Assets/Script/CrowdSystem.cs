using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    public Transform crowdparent;
    public GameObject follower;
    public float spwanradious = 5f;
    private List<Transform> crowd = new List<Transform>();


    private void Awake()
    {
        addfirst();
    }
    void Start()
    {
    
        
    }



    public void addfollowers(int amount)
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
        
            foreach (Transform t in crowdparent)
            {
                crowd.Add(t);

            }
        

    }
    public void removefollower(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (crowd.Count <= 0)
                return;
            Transform follower = crowd[crowd.Count - 1];
            crowd.RemoveAt(crowd.Count - 1);
            Destroy(follower.gameObject);
        }
    }
    public void multiflyadd(int amount)
    {
        int current = crowd.Count;
        int multifly = current * (amount - 1);
        addfollowers(amount);
    }
}
