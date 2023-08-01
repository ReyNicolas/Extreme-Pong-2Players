using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameDataSO gameData;
    [SerializeField] PlayerDataSO playerDataLeft;
    [SerializeField] PlayerDataSO playerDataRight;
    [SerializeField] Transform playerLeftTransform;
    [SerializeField] Transform playerRightTransform;
    [SerializeField] BallController ball;

    private void Start()
    {
        ResetValues();
        gameData.playerRightScore.Subscribe(CheckWinnerRight);
        gameData.playerLeftScore.Subscribe(CheckWinnerLeft);       
    }

    void CheckWinnerRight(int value)
    {
        
        if (gameData.pointsToWin <= gameData.playerRightScore.Value)
        {
            gameData.winnerName.Value = "Player Right";
            StartCoroutine(ResetGame());
        }
        else if(value>0)
        {
            ResetPositions();
        }
       
    }

    void CheckWinnerLeft(int value)
    {
        
        if (gameData.pointsToWin <= gameData.playerLeftScore.Value)
        {
            gameData.winnerName.Value = "Player Left";
            StartCoroutine(ResetGame());
        }
        else if(value>0)
        {
            ResetPositions();
        }
       
    }

   public void ResetPositions()
    {
        playerLeftTransform.position *= Vector2.right;
        playerRightTransform.position *= Vector2.right;
        ball.transform.position = Vector2.zero;
        ball.SetVelocity();
    }

    IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(2);
        gameData.winnerName.Value = "3";
        yield return new WaitForSeconds(1);
        gameData.winnerName.Value = "2";
        yield return new WaitForSeconds(1);
        gameData.winnerName.Value = "1";
        yield return new WaitForSeconds(1);

        ResetValues();
        ResetPositions();
    }

    void ResetValues()
    {
        gameData.playerLeftScore.Value = 0;
        gameData.playerRightScore.Value = 0;
        gameData.winnerName.Value = "";
        playerDataLeft.ResetPowers();
        playerDataRight.ResetPowers();
    }
}
