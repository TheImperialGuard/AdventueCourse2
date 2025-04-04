using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Game : MonoBehaviour
{
    [SerializeField] private Ball _ball;

    [SerializeField] private List<GameObject> _destructableObjects;

    [SerializeField] private float _defaultSecondsForLose;

    private string WinMessage = "Ты победил!";
    private string LoseMessage = "Время вышло! Ты проиграл!";

    private KeyCode RestartKeyCode = KeyCode.R;

    private CoinsResolver _coinsResolver;

    private Vector3 _defaultBallPosition;
    private Quaternion _defaultBallRotation;

    private float _secondsForLose;

    private bool _isRunning;

    private void Awake()
    {
        _coinsResolver = GetComponent<CoinsResolver>();

        _defaultBallPosition = _ball.transform.position;
        _defaultBallRotation = _ball.transform.rotation;
    }

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(RestartKeyCode))
            StartGame();

        if (_isRunning == false)
            return;

        UpdateTimer();

        if (IsTimerOut() || _coinsResolver.IsAllCoinsCollected)
        {
            EndGame();

            string resultMessage = _coinsResolver.IsAllCoinsCollected ? WinMessage : LoseMessage;

            Debug.Log(resultMessage);
        }
    }

    private bool IsTimerOut() => _secondsForLose <= 0;
    
    private void UpdateTimer()
    {
        if (_secondsForLose > 0)
            _secondsForLose -= Time.deltaTime;
    }

    private void EndGame()
    {
        _isRunning = false;
    }

    private void StartGame()
    {
        _isRunning = true;

        _secondsForLose = _defaultSecondsForLose;

        ResetBall();

        _coinsResolver.RespawnCoins();

        RebuildDestructableObjects();
    }

    private void ResetBall()
    {
        _ball.transform.position = _defaultBallPosition;
        _ball.transform.rotation = _defaultBallRotation;

        _ball.ResetMotion();

        Physics.SyncTransforms();

        _ball.GetComponent<Wallet>().ResetBalance();
    }

    private void RebuildDestructableObjects()
    {
        foreach (GameObject destructableObject in _destructableObjects)
        {
            destructableObject.SetActive(true);
        }
    }
}
