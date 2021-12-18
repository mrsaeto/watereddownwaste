using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathButtons : MonoBehaviour
{
    public void PlayAgain(){
        AudioManager.singleton.Play("Press");
        SceneManager.LoadScene(1);
    }
    public void MainMenuD(){
        AudioManager.singleton.Play("Press");
        SceneManager.LoadScene(0);
    }

}
