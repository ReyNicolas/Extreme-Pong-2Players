using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class SoundController : MonoBehaviour
{
    [SerializeField] GameDataSO gameData;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip pointClip;
    [SerializeField] AudioClip endGameClip;
    [SerializeField] AudioClip waitClip;
    [SerializeField] AudioClip startClip;

    private void Start()
    {
       
        gameData.playerRightScore.Subscribe(PointSound);
        gameData.playerLeftScore.Subscribe(PointSound);
        gameData.winnerName.Subscribe(EndGameSound);
    }

    void PointSound(int value)
    {
        if (value > 0) audioSource.PlayOneShot(pointClip);          

    }

    void EndGameSound(string value)
    {
        if (value.Count() > 1)
        {
            audioSource.PlayOneShot(endGameClip);
        }else if(value.Count() == 1)
        {
            audioSource.PlayOneShot(waitClip);
        }
        else
        {
            audioSource.PlayOneShot(startClip);
        }
    }
}
