using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UniRx;
using System.Linq;

public class ScorerController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreLeftText;
    [SerializeField] TextMeshProUGUI scoreRightText;
    [SerializeField] TextMeshProUGUI resultText;
    [SerializeField] GameDataSO gameData;
    private void Start()
    {
        gameData.playerRightScore.Subscribe(ChangeScoreRight);
        gameData.playerLeftScore.Subscribe(ChangeScoreLeftt);
        gameData.winnerName.Subscribe(ChangeResultMessage);
    }

    void ChangeScoreRight(int value)
    {
        scoreRightText.text = value.ToString();
    }

    void ChangeScoreLeftt(int value)
    {
        scoreLeftText.text = value.ToString();
    }

    void ChangeResultMessage(string value)
    {
        if (value.Count() > 1) resultText.text = value + " wins.";
        else if (value.Count() == 1) resultText.text = "Restarts in " + value;
        else resultText.text = "";
    }
}
