using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager : MonoBehaviour
{
    public Pins pinsDb;
    public static int selection = 0;
    public SpriteRenderer sprite;
    public TMP_Text nameLabel;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateCharcter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void updateCharcter()
    {
        pin current = pinsDb.getPin(selection);

        sprite.sprite = current.prefab.GetComponent<SpriteRenderer>().sprite;
        nameLabel.SetText(current.name);


    }

    public void next()
    {
        StartCoroutine(WaitForSoundTransition());
        int numberPins = pinsDb.getCount();
        if(selection < numberPins - 1)
        {
            selection = selection + 1;

        }
        else
        {
            selection = 0;
        }
        updateCharcter();
    }

    public void previous()
    {
        StartCoroutine(WaitForSoundTransition());

        if (selection > 0)
        {
            selection = selection - 1;
        }
        else
        {
            selection = pinsDb.getCount() - 1;
        }
        updateCharcter();
    }

    private IEnumerator WaitForSoundTransition()
    {
        AudioSource audioSource = GetComponentInChildren<AudioSource>();
        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);


      
    }
}
