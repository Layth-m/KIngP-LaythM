
using UnityEngine;
using TMPro;

public class TimerBehavior : MonoBehaviour
{
    private float timer;
    private TextMeshProUGUI textField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();

        if (textField == null)
        {
            Debug.LogError("No TextMeshProUGUI component found on this GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (textField != null)
        {
            timer += Time.deltaTime; // increment timer

            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);

            string message = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
            textField.SetText(message);
        }
    }
}
