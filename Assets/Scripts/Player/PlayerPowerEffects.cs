using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerEffects : MonoBehaviour
{
    [SerializeField] PlayerDataSO playerData;
    [SerializeField] KeyCode doubleSizeKey;
    [SerializeField] KeyCode doubleVelocityKey;
   [SerializeField] KeyCode teleportKey;
    bool doubleVelocity = false;

    private void Update()
    {
        if (Input.GetKeyDown(doubleSizeKey) && playerData.doubleSize.Value)
        {
            playerData.doubleSize.Value = false;
            ChangeLenght(2, 2);
        }
        if (Input.GetKeyDown(teleportKey) && playerData.teleport.Value)
        {
            playerData.teleport.Value = false;
            Translate(GameObject.Find("Ball").transform.position);
        }
        if (Input.GetKeyDown(doubleVelocityKey) && playerData.doubleVelocity.Value)
        {
            playerData.doubleVelocity.Value = false;
            doubleVelocity = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(doubleVelocity && collision.gameObject.CompareTag("Ball"))
        {
            collision.rigidbody.velocity *= 2;
            doubleVelocity = false;
        }
    }





    public void ChangeLenght(float size,float time)
    {
        transform.localScale *= new Vector2(1, size);
        StartCoroutine(ReLenght(size, time));
    }

    public void Translate(Vector2 position)
    {
        transform.position = new Vector2(transform.position.x, position.y);
    }


    IEnumerator ReLenght(float size,float time)
    {
        yield return new WaitForSeconds(time);
        transform.localScale /= new Vector2 (1, size);
    }
}
