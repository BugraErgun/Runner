using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private SoundsManager soundsManager;
    [SerializeField] private Sprite optionsOnSprite;
    [SerializeField] private Sprite optionsOffSprite;
    [SerializeField] private Image soundsBtnImage;
    [SerializeField] private Image vibrationBtnImage;

    [Header("Settings")]
    private bool soundsState = true;
    private bool vibrationState = true;

    private void Awake()
    {
        soundsState = PlayerPrefs.GetInt("Sounds",1) == 1;
        vibrationState = PlayerPrefs.GetInt("Vibration", 1) == 1;
    }

    void Start()
    {
        Setup();
    }

    void Update()
    {
        
    }
    private void Setup()
    {
        if (soundsState)
        {
            EnabledSounds();
        }
        else
        {
            DisableSound();
        }

        if (vibrationState)
        {
            EnabledVibration();
        }
        else
        {
            DisableVibration();
        }
    }
    public void ChangeSoundsState()
    {
        if (soundsState)
        {
            DisableSound();
        }
        else
        {
            EnabledSounds();
        }
        soundsState = !soundsState;

        int soundsSaveState = 0;
        if (soundsState)
        {
            soundsSaveState = 1;
        }
        else
        {
            soundsSaveState = 0;
        }

        PlayerPrefs.SetInt("Sounds", soundsSaveState);
    }
    public void ChangeVibrationState()
    {
        if (vibrationState)
        {
            DisableVibration();
        }
        else
        {
            EnabledVibration();
        }
        vibrationState = !vibrationState;

        int vibratinoSaveState = 0;
        if (vibrationState)
        {
            vibratinoSaveState = 1;
        }
        else
        {
            vibratinoSaveState = 0;
        }
        PlayerPrefs.SetInt("Vibration",vibratinoSaveState) ;
    }
    private void DisableSound()
    {
        soundsManager.DisableSounds();
        soundsBtnImage.sprite = optionsOffSprite;        
    }
    private void EnabledSounds()
    {
        soundsManager.EnableSounds();
        soundsBtnImage.sprite = optionsOnSprite;
    }
    private void EnabledVibration()
    {
        vibrationBtnImage.sprite = optionsOnSprite;
    }
    private void DisableVibration()
    {
        vibrationBtnImage.sprite = optionsOffSprite;
    }
}
