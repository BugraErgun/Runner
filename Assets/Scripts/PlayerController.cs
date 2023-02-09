using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Elements")]
    [SerializeField] private CrowdSystem crowdSystem;
    [SerializeField] private PlayerAnimator playerAnimator;

    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float roadWidth;
    private bool canMove;

    [Header("Control")]
    [SerializeField] private float slideSpeed;
    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;


    private void Awake()
    {
        if (instance !=null)
        {
            Destroy(gameObject);
        }else
        {
            instance= this;
        }
    }

    void Start()
    {
        GameManager.onGameStateChaned += GameStageChangedCallBack;
    }

    private void OnDestroy()
    {
        GameManager.onGameStateChaned -= GameStageChangedCallBack;
    }

    void Update()
    {
        if (canMove)
        {
            MoveForward();
            ManageControl();
        }
    }
    private void GameStageChangedCallBack(GameManager.GameState state)
    {
        if (state == GameManager.GameState.Game)
        {
            StartMoving();
        }
        else if (state == GameManager.GameState.GameOver || state== GameManager.GameState.LevelComplete)
        {
            StopMoving();
        }
    }
    void StartMoving()
    {
        canMove = true;
        playerAnimator.Run();
    }
    void StopMoving()
    {
        canMove= false;
        playerAnimator.Idle();
    }
    void MoveForward()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }
    void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if(Input.GetMouseButton(0))
        {
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;

            xScreenDifference /= Screen.width;
            xScreenDifference *= slideSpeed;

            Vector3 pos = transform.position;
            pos.x = clickedPlayerPosition.x + xScreenDifference;

            pos.x = Math.Clamp(pos.x, -roadWidth / 2 + crowdSystem.GetCrowdRadius(),
                roadWidth / 2 - crowdSystem.GetCrowdRadius());

            transform.position = pos;
           
        }
    }
}
