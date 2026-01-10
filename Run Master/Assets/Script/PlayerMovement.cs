using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    [Header("Movement")]

    public float speed = 5f;
    public float sidespeed = 5f; 
    public float lerpspeed = 10f;

    private Animator anim;
    private Vector3 targetpos; 
    private Vector2 touchstartpos;
    public float swipeThreshold = 50f;
    private CharacterController controller;
    private bool isswiping = false;
    public float currentspeed;
    private bool isFinished;

    public CrowdSystem crowdsystem;
    void Start()
    {
        isFinished = false;
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();


        if (anim != null)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            Debug.LogError("Animator component missing on Player!");
        }
        targetpos = transform.position;
        currentspeed = speed;
    } 
    void Update() 
    { 
           
        getinput();  
        movement(); 
    }
    void getinput()
    {
        if (isFinished) return;
        float horizontalinput = Input.GetAxis("Horizontal");

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 

            if (touch.phase == TouchPhase.Began)
            { touchstartpos = touch.position; isswiping = true;
            } 
            else if (touch.phase == TouchPhase.Moved && isswiping) 
            { Vector2 delta = touch.position - touchstartpos;
                if (Mathf.Abs(delta.x) > swipeThreshold) 
                { horizontalinput = delta.x > 0 ? 1f : -1f; isswiping = false; }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) 
                {
                    isswiping = false; 
                }
            }
        } 

        targetpos = new Vector3(transform.position.x + horizontalinput * sidespeed * Time.deltaTime, transform.position.y, transform.position.z);

    }

    void movement()
    {
        if (controller == null) return;
        if (isFinished) return;

        Vector3 move = Vector3.forward * speed;

        float targetX = targetpos.x;
        targetX = Mathf.Clamp(targetX, -0.8f, 0.8f);
        move.x = (targetX - transform.position.x) * lerpspeed;
        controller.Move(move * Time.deltaTime);
    }
    
    public  void GameOver()
    {
       
        isFinished = true;
        anim.SetBool ("isRunning",false);
 

        foreach (Transform t in crowdsystem.crowdparent)
        {
            Animator anim = t.GetComponentInChildren<Animator>();
            if (anim != null)
                anim.SetBool("isRunning", false);
      
        }
        StartCoroutine(StopDelay(2));
        GameManager.Instance.LevelFinished();
 
    }
    IEnumerator StopDelay(float duration)
    {
        yield return new WaitForSeconds(duration);
        speed = 0f;
 
    }
}