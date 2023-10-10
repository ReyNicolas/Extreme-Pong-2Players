using UnityEngine;
using UniRx;

[CreateAssetMenu(fileName = "New GameData", menuName = "ScriptableObjects/GameData")]
public class GameDataSO : ScriptableObject
{
    public ReactiveProperty<int> playerLeftScore = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> playerRightScore = new ReactiveProperty<int>(0);
    public ReactiveProperty<string> winnerName = new ReactiveProperty<string>();
    public int pointsToWin;
    public float ballSpeed;


    public void AddPointToPlayer(string playerName)
    {
        if(playerName == "Left Player")
        {
            playerLeftScore.Value++;
        }
        else
        {
            playerRightScore.Value++;
        }
    }
}
