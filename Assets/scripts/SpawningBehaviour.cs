using UnityEngine;
using UnityEngine.UI;
public class SpawningBehaviour : MonoBehaviour
{

    public GameObject[] ballVariants;
    public GameObject targetObject;
    GameObject newObject;
    public float startTime;
    public int minSpawn = 5;
    public int maxSpawn = 30;
    public float spawnRatio;

    public float minX;
    public float maxX;

    public float minY;
    public float maxY;
 
    void Start()
    {
        spawnBall();
        spawnRatio = Random.Range(minSpawn, maxSpawn);
    }

    void spawnBall()
    {
        int numVariants = ballVariants.Length;
        if(numVariants > 0)
        {
            int selection = Random.Range(0, numVariants);
            newObject = Instantiate(ballVariants[selection], new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
            BalllBehavior ballBehaviour = newObject.GetComponent<BalllBehavior>();
            ballBehaviour.setBounds(minX, maxX, minY, maxY);
            ballBehaviour.initialPosition();



        }
        startTime = Time.time;
    }

    void Update()
    {
        float currentTime = Time.time;
        float timeElapsed = currentTime - startTime;
        if(timeElapsed > spawnRatio)
        {
            spawnBall();
        }
    }
}
