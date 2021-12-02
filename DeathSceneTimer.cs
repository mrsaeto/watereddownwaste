using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathSceneTimer : MonoBehaviour
{
    public float timing;
    public float startcountdown = 10f;

    public GameObject YouDied;
    public GameObject Survived;
    public GameObject Trash;
    public GameObject FinalScore;
    public GameObject PlayAgainQuit;
    public float trashPicked;


    public Text timeText;
    public Text scoreText;
    public Text trashText;

    void Start()
    {
        AudioManager.singleton.Play("PlayerDeath");
        trashPicked = (Timer.singleton.score - (Timer.singleton.totalTime/10)) / 100;
        YouDied.SetActive(false);
        Survived.SetActive(false);
        Trash.SetActive(false);
        FinalScore.SetActive(false);
        PlayAgainQuit.SetActive(false);
        timing = startcountdown;
        trashText.text = "You  Picked   Up   " + trashPicked.ToString("F0") + "   Pieces   of   Trash";
        scoreText.text = "Your Score was:   " + Timer.singleton.score.ToString();
        timeText.text = "You   Survived   for:   " + Timer.singleton.minutes.ToString("00") + ":" + Timer.singleton.seconds.ToString("00");
    }

    // Update is called once per frame
    void Update()
    {



        if (timing <= 8){
            YouDied.SetActive(true);

        }
        if (timing <= 6){
            Survived.SetActive(true);

        }
        if (timing <= 4){
            Trash.SetActive(true);

        }
        if (timing <= 2){
            FinalScore.SetActive(true);

        }
        if (timing <=0){
            PlayAgainQuit.SetActive(true);
        }

        timing -= Time.deltaTime;
    }
}
