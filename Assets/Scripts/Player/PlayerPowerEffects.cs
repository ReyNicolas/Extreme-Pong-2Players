using UniRx;
using UnityEngine;

public abstract class PlayerPowerEffects : MonoBehaviour
{
    [SerializeField]protected KeyCode key;
    [SerializeField]protected ReactiveProperty<bool> canUse;

    protected virtual void Update()
    {
        if (Input.GetKeyDown(key) && canUse.Value)
        {
            UseIt();
        }
    }

    protected virtual void UseIt()
    {
        canUse.Value = false;
    }
}

