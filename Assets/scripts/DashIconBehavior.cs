using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DashIconBehavior : MonoBehaviour
{
    TextMeshProUGUI label;
    float cooldown;
    public Image overlay;
    float cooldownRate;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        label = GetComponentInChildren<TextMeshProUGUI>();
        Image[] images = GetComponentsInChildren<Image>();
        for(int i = 0; i<images.Length; i++)
        {
            if (images[i].tag == "overlay")
            {
                overlay = images[i];
            }
        }
        cooldownRate = PinBehavior.cooldownRate;
        overlay.fillAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        cooldown = PinBehavior.cooldown;
        string message = " ";

        if(PinBehavior.cooldown> 0.0)
        {
            float fill = cooldown / cooldownRate;
            message = string.Format("{0:0.0}",PinBehavior.cooldown);
            overlay.fillAmount = fill;
        }


        label.SetText(message); 
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collided = collision.gameObject.tag;
        Debug.Log("Collided with" + collided);
        Debug.Log(collided);
        if(collision.gameObject.tag == "Ball"||  collision.gameObject.tag == "Wall")
        {
            Debug.Log("gg");
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }
}
