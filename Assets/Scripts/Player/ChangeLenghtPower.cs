using System.Collections;
using UnityEngine;

public class ChangeLenghtPower: PlayerPowerEffects
{
    [SerializeField] float time=5;
    [SerializeField] float size=2;

    private void Awake()
    {
        canUse = GetComponent<PlayerController>().GetPlayerData().doubleSize;
    }

    protected override void UseIt() 
    {
        base.UseIt();

        transform.localScale *= new Vector2(1, size);
        StartCoroutine(ReLenght(size, time));
    }

    IEnumerator ReLenght(float size, float time)
    {
        yield return new WaitForSeconds(time);
        transform.localScale /= new Vector2(1, size);
    }
}

