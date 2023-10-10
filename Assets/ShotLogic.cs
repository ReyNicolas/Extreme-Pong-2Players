using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLogic : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer spriteRenderer;
    private void Start()
    {
        transform.up = (new Vector3(0, transform.position.y) - transform.position);
        rb.velocity = transform.up * speed;
    }
    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PowerDestroyer"))
        {
            Destroy(gameObject);
        }
    }
}
