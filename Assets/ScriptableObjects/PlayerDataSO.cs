using UnityEngine;
using UniRx;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "ScriptableObjects/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    public ReactiveProperty<bool> doubleSize = new ReactiveProperty<bool>(true);
    public ReactiveProperty<bool> doubleVelocity = new ReactiveProperty<bool>(true);
    public ReactiveProperty<bool> teleport = new ReactiveProperty<bool>(true);


    public void ResetPowers()
    {
        doubleSize.Value = true;
        doubleVelocity.Value = true;
        teleport.Value = true;
    }
}