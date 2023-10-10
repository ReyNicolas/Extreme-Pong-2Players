using UnityEngine;

public class ShotPower : PlayerPowerEffects
{
    [SerializeField] GameObject shotPrefab;

    private void Awake()
    {
        canUse = GetComponent<PlayerController>().GetPlayerData().shot;
    }


    protected override void UseIt()
    {
        base.UseIt();
        Instantiate(shotPrefab,transform.position,transform.rotation).GetComponent<ShotLogic>().SetColor(GetComponent<SpriteRenderer>().color);

    }

}

