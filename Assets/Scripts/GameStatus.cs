using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;

public class GameStatus : MonoBehaviour
{

    //parameters
    [Range(0.1f, 10f)] [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlockDestroyed = 83;
    [SerializeField] private TextMeshProUGUI scoreText;

    // state variables
    [SerializeField] private int currentScore = 0;


    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;

    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();

    }
}
