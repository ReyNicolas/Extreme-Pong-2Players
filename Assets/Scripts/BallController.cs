using System.Linq;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float speedMultiplier = 1.1f;
    [SerializeField] AudioSource audioSource;
    Rigidbody2D rb;
    int[] initialDirections = new int[] { 1,-1 };

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();       
    }
  

    public void SetVelocity()
    {
        rb.velocity = new Vector2(initialDirections[Random.Range(0,initialDirections.Count())], initialDirections[Random.Range(0, initialDirections.Count())]) * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity *= speedMultiplier;
        }
    }

}
