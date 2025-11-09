using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;         
    public float sidespeed = 5f;    
    public float lerpspeed = 10f;  

    private Vector3 targetpos;

    private Vector2 touchstartpos;
    public float swipeThreshold = 50f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        targetpos = transform.position;
    }

    void Update()
    {
        getinput();
        movement();
    }

    void getinput()
    {
       float horizontalinput = Input.GetAxis("Horizontal");

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchstartpos = touch.position;

            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 delta = touch.position - touchstartpos;
                if (Mathf.Abs(delta.x) > swipeThreshold)
                {
                    horizontalinput = delta.x > 0 ? 1f : -1f;

                }
            }
      
          }
     
        targetpos = new Vector3(
            transform.position.x + horizontalinput * sidespeed * Time.deltaTime,
            transform.position.y,
            transform.position.z
        );
    }

    void movement()
    {
        if (controller == null) return;

        Vector3 move = Vector3.forward * speed;
        move.x = (targetpos.x - transform.position.x) * lerpspeed; 
        controller.Move(move * Time.deltaTime);
    }
}
