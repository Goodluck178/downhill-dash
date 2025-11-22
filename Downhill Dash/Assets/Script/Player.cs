using UnityEngine;

public class Player : MonoBehaviour
{
    //So you can control the speed from the inspector
    [SerializeField] float speed = 5f;
    Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Move()
    {
        //Movement along the x axis
        float horizontal = Input.GetAxis("Horizontal");

        //Calculate the player movement within the x Axis and making the game frame rate independent
        Vector2 movement = new Vector2(horizontal, 0f) * speed * Time.deltaTime;

        //Apply movement  to the player
        transform.Translate(movement);

        //Set Player Boundary
        //Converting to viewport point
        Vector3 playerBoundary = mainCamera.WorldToViewportPoint(transform.position);
        playerBoundary.x = Mathf.Clamp(playerBoundary.x,0.06f, 0.96f);

        //Converting back to World view
        transform.position = mainCamera.ViewportToWorldPoint(playerBoundary);
    }

    // Update is called once per frame
    void Update()
    {
        Move();


    }
}
