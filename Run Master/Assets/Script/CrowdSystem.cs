using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    public Transform crowdparent;
    public GameObject follower;
    private List<Transform> crowd = new List<Transform>();


    private void Awake()
    {
        addfirst();
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
        Vector3 pos = new Vector3(Random.Range(-0.4f, 0.4f), 0,
            Random.Range(-0.4f, 0.4f));
        newfollower.transform.localPosition = pos;
        Animator anim = newfollower.GetComponentInChildren<Animator>();
        if (anim != null)
        {
            anim.SetBool("isRunning", true);
        }
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
                break;
            Transform follower = crowd[crowd.Count - 1];
            crowd.RemoveAt(crowd.Count - 1);  
            Destroy(follower.gameObject);
        }
        if (crowd.Count <= 0)
        {
            GameManager.Instance.LevelFail();
        }
    }


    public void RemoveSpecificFollower(Transform follower)
    {
        if (crowd.Contains(follower))
        {
            crowd.Remove(follower);
            Destroy(follower.gameObject);

            if (crowd.Count <= 0)
            {
                GameManager.Instance.LevelFail();
            }
        }
    }

    public void multiflyadd(int amount)
    {
        int current = crowd.Count;
        int multifly = current * (amount - 1);
        addfollowers(multifly);
    }
}
