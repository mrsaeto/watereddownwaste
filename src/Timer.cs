using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer singleton = null;

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject howToMenuUI;


    public Text timerText;
    public float timeStart;
    public float minutes, seconds;
    public float totalTime = 0;
    public bool firstInstance = true;

    public Text scoreText;
    public float score;
    public float timerscore;
 
    void Awake() {
        if (Timer.singleton == null) {
            Timer.singleton = this;
        }
    }

    void Start(){
        Time.timeScale = 1f;
        timerscore = 10;
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (gameIsPaused){
                Resume();
            } else {
                Pause();
            }
        }
        totalTime += Time.deltaTime;

        minutes = (int)(totalTime / 60);
        seconds = (int)(totalTime % 60);


        timerText.text = "Time:" + minutes.ToString("00") + ":" + seconds.ToString("00");

        timerscore -= Time.deltaTime;

        if (timerscore <= 0){
            score = score + 10;
            timerscore = 10;
        }

        scoreText.text = "Score: " + score.ToString("0");

        if (firstInstance == true){
            Time.timeScale = 1f;
            firstInstance = false;
        }

    }
    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

    }

    public void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;

    }

    public void Restart(){
        firstInstance = true;
        SceneManager.LoadScene(1);
    }

    public void HowTo(){
        pauseMenuUI.SetActive(false);
        howToMenuUI.SetActive(true);
    }

    public void Menu(){
        firstInstance = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene(0);
    }

    public void Continue(){
        firstInstance = true;
        howToMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene(2);
    }
    
    public void Back(){ 
        howToMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}
