using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public Text timeText;

    public static int ragdollScore;
    public float timeLeft;


    void Update()
    {
        scoreText.text = "Score :" + ragdollScore.ToString();
    }



    public static void AddScore()
    {
        ragdollScore++;
    }

}
