using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PinBehavior : MonoBehaviour
{

    public float dashSpeed = 12.0f; 
    public float baseSpeed = 8.0f;
    static public float cooldownRate = 5.0f;
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

    public AudioSource[] audioSources;

    // Start is called once before
    // the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        cam = Camera.main;
        dashing = false;

        audioSources = GetComponents<AudioSource>();
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
        Debug.Log("Collided with" + collided);
        Debug.Log(collided);
        if (collision.gameObject.tag == "Ball" || collision.gameObject.tag == "Wall")
        {
            Debug.Log("gg");
            StartCoroutine(WaitForSoundAndTransition());
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
                if (audioSources[1].isPlaying)
                {
                    audioSources[1].Stop();
                }
                audioSources[1].Play();
            }
        }
    }

    private IEnumerator WaitForSoundAndTransition()
    {
        
        audioSources[0].Play();

        yield return new WaitForSeconds(audioSources[0].clip.length);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }






}