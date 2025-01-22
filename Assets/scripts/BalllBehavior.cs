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
    public float cooldown;
    public bool launching;
    public float launchDuration;
    public float timeLastLaunch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        secondsToMaxSpeed = 45f;
     //   minSpeed = 0.01f ;
     //   maxSpeed = 15.0f;

      targetPosition =  getRandomPosition();
        
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 currentPos = gameObject.GetComponent<Transform>().position;
        float distance = Vector2.Distance(currentPos, targetPosition);

        if(distance > 0.1) {
            float difficulty = getDifficultypercentage();
            float currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, difficulty);
            currentSpeed = currentSpeed * Time.deltaTime;
            Vector2 newPosition = Vector2.MoveTowards(currentPos,targetPosition,currentSpeed);
            transform.position = newPosition;

        }
        else
        {
            targetPosition = getRandomPosition();
        }

        //getRandomPosition();
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

    }



}
