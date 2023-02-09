using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum GameState
    {
        Menu,
        Game,
        LevelComplete,
        GameOver
    }

    private GameState gameState;

    public static Action<GameState> onGameStateChaned;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        onGameStateChaned?.Invoke(gameState);
    }

    public bool IsGameState()
    { 
        return gameState == GameState.Game;
    }
}
