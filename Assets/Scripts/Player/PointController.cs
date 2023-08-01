using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] GameDataSO gameData;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            gameData.AddPointToPlayer(playerName);
        }
    }
}
