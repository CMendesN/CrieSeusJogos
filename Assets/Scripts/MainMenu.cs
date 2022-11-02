using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    string hoverOverSound = "ButtonHover";
    [SerializeField]
    string pressButtonSound = "PressButton";
    [SerializeField]
    string sound = "Intro";
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;
        if( audioManager == null)
        {
            Debug.LogError("AudioManager not found");
        }
        audioManager.PlaySound(sound);
    }
    public void PlayGame()
    {
        audioManager.PlaySound(pressButtonSound);
        audioManager.StopSound(sound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void QuitGame()
    {
        audioManager.PlaySound(pressButtonSound);
        Application.Quit();
    }
    public void Credits()
    {
        audioManager.PlaySound(pressButtonSound);
        
    }
    public void OnMouseOver()
    {
        audioManager.PlaySound(hoverOverSound);


    }
    
}
