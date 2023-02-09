using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject levelComplatePanel; 
    [SerializeField] private GameObject settingsPanel;

    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI levelText;


    void Start()
    {
        progressBar.value = 0;
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        settingsPanel.SetActive(false);

        levelText.text = "Level " + (ChunkManager.instance.GetLevel() + 1);

        GameManager.onGameStateChaned += GameStateChangedCallBack;

    }

    private void OnDestroy()
    {
        GameManager.onGameStateChaned -= GameStateChangedCallBack;
    }
    void Update()
    {
        UpdateProgressBar();
    }
    private void GameStateChangedCallBack(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.GameOver)
        {
            ShowGameOver();
        }
        else if (gameState == GameManager.GameState.LevelComplete)
        {
            ShowLevelComplete();
        }
    }
    public void PlayButton()
    {
        GameManager.instance.SetGameState(GameManager.GameState.Game);
        gamePanel.SetActive(true);
        menuPanel.SetActive(false);

    }
    public void RetryButton()
    {
        SceneManager.LoadScene(0);
    }
    public void ShowGameOver()
    {
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }
    private void ShowLevelComplete()
    {
        gamePanel.SetActive(false);
        levelComplatePanel.SetActive(true);
    }
    public void UpdateProgressBar()
    {
        if (!GameManager.instance.IsGameState())
        {
            return;
        }
        float progress = PlayerController.instance.transform.position.z / ChunkManager.instance.GetFinishZ();
        progressBar.value = progress;
    }
    public void ShowSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }
    public void HideSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }
}
