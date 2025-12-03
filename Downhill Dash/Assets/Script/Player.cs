using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    Vector2 movement;
    Camera gameCamera;
    float moveX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameCamera = Camera.main;
    }

    void MovePlayer()
    {
        //getting user input
        moveX = Input.GetAxis("Horizontal");
        //player movement iin x-axis without clamping
        movement = Vector2.zero;//initialize to zero:
        movement.x = moveX;
        movement *= playerSpeed * Time.deltaTime;
        transform.Translate(movement);

        //creating boundary for player movement along x axis
        Vector3 playerMoveBoundary = gameCamera.WorldToViewportPoint(transform.position);
        playerMoveBoundary.x = Mathf.Clamp(playerMoveBoundary.x, 0.06f, 0.96f);
        transform.position = gameCamera.ViewportToWorldPoint(playerMoveBoundary);

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
}
