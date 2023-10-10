using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerDataSO playerData;
    [SerializeField] float speed = 5f;
    [SerializeField] KeyCode keyUp;
    [SerializeField] KeyCode keyDown;

    float minY, maxY;

    void Start()
    {
        SetMovementLimits();
    }
    void Update()
    {
        if (Input.GetKey(keyUp))
        {
            MoveUp();
        }
        if (Input.GetKey(keyDown))
        {
            MoveDown();
        }
    }

    public PlayerDataSO GetPlayerData()
    {
        return playerData;
    }
    void SetMovementLimits()
    {
        Camera mainCamera = Camera.main;
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));
        minY = bottomLeft.y + 1.5f;
        maxY = topRight.y -1.5f;
    }
     

    void MoveUp()
    {
        if (transform.position.y < maxY)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    void MoveDown()
    {
        if (transform.position.y > minY)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

}

