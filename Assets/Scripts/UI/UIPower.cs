using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UIPower : MonoBehaviour
{

    [SerializeField] PlayerDataSO playerLeftData;
    [SerializeField] PlayerDataSO playerRightData;
    [SerializeField] List<GameObject> leftImages;
    [SerializeField] List<GameObject> righttImages;

    // Start is called before the first frame update
    void Start()
    {
        playerLeftData.doubleSize.Subscribe(newValue => leftImages[0].SetActive(newValue));
        playerRightData.doubleSize.Subscribe(newValue => righttImages[0].SetActive(newValue));

        playerLeftData.teleport.Subscribe(newValue => leftImages[1].SetActive(newValue));
        playerRightData.teleport.Subscribe(newValue => righttImages[1].SetActive(newValue)); 

        playerLeftData.doubleVelocity.Subscribe(newValue => leftImages[2].SetActive(newValue));
        playerRightData.doubleVelocity.Subscribe(newValue => righttImages[2].SetActive(newValue));
    }

}
