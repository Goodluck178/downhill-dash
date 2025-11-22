using UnityEngine;

public class Background : MonoBehaviour
{
    //Control the 
    [SerializeField] float bgScrollSpeed = 0.5f;
    Material backgroundMaterial;
    Vector2 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get material from the inspector
        backgroundMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(0f, bgScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //Applying the scroll speed to the background
        backgroundMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
