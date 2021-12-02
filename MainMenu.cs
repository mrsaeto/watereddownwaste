using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool started = false;
    public GameObject Starting;
    public GameObject postStart;

    void Start()
    {
        Starting.SetActive(true);

    }


    void Update()
    {
        if (started == false){
            if (Input.anyKey){
                StartGame();
            }
        }
    }
    void StartGame(){
        AudioManager.singleton.Play("TVON");
        Starting.SetActive(false);
        postStart.SetActive(true);
    }

    public void Play(){
        AudioManager.singleton.Play("Press");
        SceneManager.LoadScene(1);
    }

    public void HowToPlay(){
        AudioManager.singleton.Play("Press");
        SceneManager.LoadScene(2);
    }

    public void About(){
        AudioManager.singleton.Play("Press");
        SceneManager.LoadScene(3);
    } 

    public void Quit(){
        AudioManager.singleton.Play("Press");
        Application.Quit();
        Debug.Log("Closed the Game");
    }

}
