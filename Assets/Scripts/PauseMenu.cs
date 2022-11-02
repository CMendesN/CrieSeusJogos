using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPause = false;
    public GameObject pauseMenuUI;
    AudioManager audioManager;
    [SerializeField]
    string hoverOverSound = "ButtonHover";
    [SerializeField]
    string pressButtonSound = "PressButton";
    void Start()
    {
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("no audiomanager found");

        }
    }
        // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;

    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
    }
    public void MainMenu()
    {
        audioManager.PlaySound(pressButtonSound);
        Resume();
        audioManager.StopSound("Environment");
        SceneManager.LoadScene("Menu");
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
