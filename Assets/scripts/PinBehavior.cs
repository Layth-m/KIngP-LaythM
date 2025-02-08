using UnityEngine;

public class PinBehavior : MonoBehaviour
{

    public float dashSpeed = 12.0f; 
    public float baseSpeed = 8.0f;
    static public float cooldownRate = 6.0f;
    static public float cooldown;
    public bool dashing; 
    public Vector2 newPosition;
    public float currentSpeed =2.0f;
    public Vector3 mousePosG;
    Camera cam;

    Rigidbody2D body;
    public float dashDuration = 3.0f;

    public float timedashStart;
    public float timedashEnd;
        
    // Start is called once before
    // the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        cam = Camera.main;
        dashing = false; 
    }
    void Update()
    {
        checkDash();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
      

        mousePosG = cam.ScreenToWorldPoint(Input.mousePosition);

        newPosition = Vector2.MoveTowards(transform.position, mousePosG, currentSpeed * Time.fixedDeltaTime);

       transform.position = newPosition;


      //  body.MovePosition(newPosition);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collided = collision.gameObject.tag;
        Debug.Log("Collided with "+ collided);
        if (collided == "Ball" || collided == "Wall")
        {
            Debug.Log("Game Over");
        }
    }






    private void checkDash()
    {

        if (dashing == true)
        {
            float howLong = Time.time - timedashStart;
            if (howLong > dashDuration)
            {
                dashing = false;
                currentSpeed = baseSpeed;
                timedashEnd = Time.time;
            }

            cooldown = cooldownRate;
        }
        else
        {
            cooldown = cooldown - Time.deltaTime;

            if(cooldown< 0)
            {
                cooldown = 0.0f;
            }
            if (Input.GetMouseButtonDown(0) && cooldown == 0.0)
            {
                dashing = true;

                currentSpeed = dashSpeed;

                timedashStart = Time.time;
            }
        }
    }








}