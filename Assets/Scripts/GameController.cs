using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    [SerializeField] private TMP_Text scoreText;
    public int score { get; private set; }
    private bool startGame = false;
    private bool isStart = false;

    private void Awake()
    {
        startGame = false;
        score = 0;
        Instance = this;
    }

    public bool IsStart()
    {
        isStart = startGame;
        return isStart;
    }

    public void StartGame()
    {
        startGame = true;
    }
    
    public void PickUpCoin(int scorePickUp)
    {
        Debug.Log("PickUpCoin");
        score += scorePickUp;
        scoreText.text = $"Score: {score}";
    }
}
