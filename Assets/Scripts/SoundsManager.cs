using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] private AudioSource buttonSounds;
    [SerializeField] private AudioSource doorHitSound;
    [SerializeField] private AudioSource runnerDieSound;
    [SerializeField] private AudioSource levelCompleteSound;
    [SerializeField] private AudioSource gameOverSound;


    void Start()
    {
        PlayerDedection.onDoorsHit += PlayDoorHit;

        GameManager.onGameStateChaned += GameStateChangedCallBack;

        Enemy.onRunnerDied+= PlayRunnerDieSound;
    }

    private void OnDestroy()
    {
        PlayerDedection.onDoorsHit -= PlayDoorHit;
        GameManager.onGameStateChaned -= GameStateChangedCallBack;
        Enemy.onRunnerDied -= PlayRunnerDieSound;
    }
    void Update()
    {
        
    }
    private void PlayDoorHit()
    {
        doorHitSound.Play();
    }
    private void GameStateChangedCallBack(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.LevelComplete)
        {
            levelCompleteSound.Play();
        }
        else if (gameState == GameManager.GameState.GameOver)
        {
            gameOverSound.Play();
        }
    }
    private void PlayRunnerDieSound()
    {
       runnerDieSound.Play();
    }
    public void DisableSounds()
    {
        doorHitSound.volume = 0;
        runnerDieSound.volume = 0;
        levelCompleteSound.volume = 0;
        gameOverSound.volume = 0;
        buttonSounds.volume = 0;
    }
    public void EnableSounds()
    {
        buttonSounds.volume = 1;
        doorHitSound.volume = 1;
        runnerDieSound.volume = 1;
        levelCompleteSound.volume = 1;
        gameOverSound.volume = 1;
    }
}
