using UnityEngine;
using System.Collections;


using System.Collections.Generic; 

public class Main_menu : MonoBehaviour
{

    public void gotoCharacterSelection()
    {

        StartCoroutine(WaitForSoundTransition("CharacterSelection"));
        UnityEngine.SceneManagement.SceneManager.LoadScene("CharacterSelection");
    }
    public void gotoGame()

    {

        StartCoroutine(WaitForSoundTransition("MainGame"));
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");

    
    }

    public void gotoMainMenu()
    {
        StartCoroutine(WaitForSoundTransition("MainMenu"));
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator WaitForSoundTransition(string sceneName)
    {
        AudioSource audioSource = GetComponentInChildren<AudioSource>();
        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }







}
