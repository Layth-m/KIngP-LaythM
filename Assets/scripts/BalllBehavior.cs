using UnityEngine;

public class BalllBehavior : MonoBehaviour
{

    public float minX = -8.29f;
    public float minY = -4.46f;
    public float maxX =  8.42f;
    public float maxY =  4.35f;
    public Vector2 targetPosition;
    public float minSpeed;
    public float maxSpeed;
    public float secondsToMaxSpeed;

    public GameObject target;
    public float minLaunchSpeed;
    public float maxLaunchSpeed;
    public float minTimeToLaunch; 
    public float maxTimeToLaunch;
    private float cooldown;
        
    public bool launching;
    private float launchDuration;
        
    public float timeLastLaunch;

    public float timeLaunchStart;
    Rigidbody2D body;
    public bool rerouting;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        secondsToMaxSpeed = 45f;
     //   minSpeed = 0.01f ;
     //   maxSpeed = 15.0f;

      targetPosition =  getRandomPosition();
        cooldown = Random.Range(2, 10);
        launchDuration = Random.Range(3, 15);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        body = GetComponent<Rigidbody2D>();

       if(onCooldown() == false)
        {
            if(launching == true)
            {
                float currentLaunchTime = Time.time - timeLaunchStart;
                if(currentLaunchTime > launchDuration)
                {
                    startCooldown();
                }
                else
                {
                    launch();
                }
            }
         
        }

        Vector2 currentPos = body.position;
        //currentPos = transform.position;
        float distance = Vector2.Distance(currentPos, targetPosition);

        if(distance > 0.1) {
            float difficulty = getDifficultypercentage();
            float currentSpeed;
            if (launching == true)
            {
                float launchingForHowLong = Time.time - timeLaunchStart;
                if (launchingForHowLong < launchDuration)
                {
                    launch();
                }
                else 
                { 
                    startCooldown();
                }

                currentSpeed = Mathf.Lerp(minLaunchSpeed, maxLaunchSpeed, difficulty);
            }
            else
            {
                currentSpeed = Mathf.Lerp(minLaunchSpeed, maxLaunchSpeed, difficulty);
            }
           
            currentSpeed = currentSpeed * Time.deltaTime;
            Vector2 newPosition = Vector2.MoveTowards(currentPos,targetPosition,currentSpeed);
            body.MovePosition(newPosition);

        }
        else
        {
            if(launching == true)
            {
                startCooldown();
            }

           targetPosition = getRandomPosition();
        }



      // float timeLaunching = Time.time - timeLastLaunch;
      // if(timeLaunching > launchDuration)
      //  {
      //      startCooldown();
      //  }
      //  else
      //  {
      //      launch();
      //  }
       

    }

    Vector2 getRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector2 v = new Vector2(randomX,randomY);
        return v;
    }


    private float getDifficultypercentage()
    {

      // clamp01 ramge normalization 
      float difficulty = Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxSpeed); 
      
      return difficulty; 

    }


    public void launch()
    {
        Rigidbody2D targetBody = target.GetComponent<Rigidbody2D>();
        targetPosition = target.transform.position;

        if (launching == false)
        {
            timeLaunchStart = Time.time;
            launching = true;

        }

    }

    public bool onCooldown()
    {
        bool result = false;
        float timeSinceLastLaunch = Time.time - timeLastLaunch;

        if(timeSinceLastLaunch < cooldown)
        {
            result = true;
        }
        return result; 
    }

    public void startCooldown()
    {
        launching = false;
        timeLastLaunch = Time.time;
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            targetPosition = getRandomPosition();
        }
        if(collision.gameObject.tag == "Ball")
        {
            Reroute(collision);
        }

        Debug.Log(this + "Collided with: " + collision.gameObject.name);
    }
    public void initialPostion()
    {
        body = GetComponent<Rigidbody2D>();
        body.position = getRandomPosition();
    }
    public void initalPosition()
    {
        body = GetComponent<Rigidbody2D>();
        body.position = getRandomPosition();
        targetPosition = getRandomPosition();
        launching= false;
        rerouting = true;
    }

    public void Reroute(Collision2D collision)
    {
        GameObject otherBall = collision.gameObject;
        if (rerouting == true)
        {
            otherBall.GetComponent<BalllBehavior>().rerouting = false;

            Rigidbody2D ballBody = otherBall.GetComponent<Rigidbody2D>();
            Vector2 contact = collision.GetContact(0).normal;
            targetPosition = Vector2.Reflect(targetPosition, contact).normalized;
            launching = false;
            float seperationDistance = 0.1f;
            ballBody.position += contact * seperationDistance;
        }
        else
        {
            rerouting = true;
        }
    }
}
