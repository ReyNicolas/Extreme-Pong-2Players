using UnityEngine;

public class DoubleBallSpeedPower : PlayerPowerEffects
{
    bool doubleVelocity = false;

    private void Awake()
    {
        canUse = GetComponent<PlayerController>().GetPlayerData().doubleVelocity;
    }


    protected override void UseIt()
    {
        base.UseIt();
        doubleVelocity = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (doubleVelocity && collision.gameObject.CompareTag("Ball"))
        {
            collision.rigidbody.velocity *= 2;
            doubleVelocity = false;
        }
    }
}

