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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int secondsToMaxSpeed = 30;
        minSpeed = 0.75f;
        maxSpeed = 2.0f; 

      targetPosition =  getRandomPosition();
        
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 currentPos = gameObject.GetComponent<Transform>().position;

        if(targetPosition != currentPos) {
            float currentSpeed = minSpeed;
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
}
