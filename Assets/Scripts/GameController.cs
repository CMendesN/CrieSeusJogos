using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public int total;
    public Text scoreText;
    public GameObject gameover;
    public static GameController instance;

    void Start()
    {
        instance = this;    
    }
    public void UpdateScoreText()
    {
        scoreText.text = total.ToString();

    }
    public void GameOver()
    {
        gameover.SetActive(true);
    }
    public void ResetLv()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        
    }
    
}
