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
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;
        if( audioManager == null)
        {
            Debug.LogError("AudioManager not found");
        }
    }
    public void PlayGame()
    {
        audioManager.PlaySound(pressButtonSound);
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
