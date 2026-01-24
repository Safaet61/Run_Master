using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float sidespeed = 5f;
    public float lerpspeed = 10f;

    private Animator anim;
    private Vector3 targetpos;

    private CharacterController controller;

    private bool isFinished = false;
    private float horizontalinput;
 
    private Vector2 lastTouchPos;
 
    public CrowdSystem crowdsystem;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

        if (anim != null)
            anim.SetBool("isRunning", false);
        else
            Debug.LogError("Animator component missing on Player!");

        targetpos = transform.position;
    }

    void Update()
    {
        if (isFinished) return;
        if (anim != null && GameManager.Instance.isGameStarted)
            anim.SetBool("isRunning", true);
        else return;

        GetInput();
        Movement();

    }
   
  
    void GetInput()
    {
        horizontalinput = 0f;

#if UNITY_EDITOR
        horizontalinput = Input.GetAxis("Horizontal");
#endif

        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                lastTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float deltaX = touch.position.x - lastTouchPos.x;

                if (deltaX > 0f)
                    horizontalinput = 1f;      
                else if (deltaX < 0f)
                    horizontalinput = -1f;    
                else
                    horizontalinput = 0f;

                
                lastTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                horizontalinput = 0f; 
            }
        }

        targetpos = new Vector3(transform.position.x + horizontalinput * sidespeed * Time.deltaTime,
            transform.position.y, transform.position.z
        );
    }

    void Movement()
    {
        if (controller == null) return;
        if (crowdsystem == null) return;

        Vector3 move = Vector3.forward * speed;

        float targetX = Mathf.Clamp(targetpos.x, -0.8f, 0.8f);
        move.x = (targetX - transform.position.x) * lerpspeed;
        move.y = 0f;
        

        controller.Move(move * Time.deltaTime);
    }

    public void GameOver()
    {
        if (isFinished) return;

        isFinished = true;

        if (anim != null)
            anim.SetBool("isRunning", false);

        foreach (Transform t in crowdsystem.crowdparent)
        {
            Animator anim = t.GetComponentInChildren<Animator>();
            if (anim != null)
                anim.SetBool("isRunning", false);
        }

        GameManager.Instance.LevelFinished();
    }
}
