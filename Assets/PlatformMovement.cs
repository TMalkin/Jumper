using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 Center = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth/3,Camera.main.pixelHeight/3));
        Vector2 BottomRight = Camera.main.ScreenToWorldPoint(new Vector2 (Camera.main.pixelWidth, Camera.main.pixelHeight));
        if(transform.position.y >= BottomRight.y) {
            speed = -speed;
        }
        if(transform.position.y <= Center.y) {
            speed = -speed;
        }
        if(Random.Range(1,1000) <= 1) {
            speed = -speed;
        }
        transform.position = new Vector2(transform.position.x, transform.position.y+speed*Time.deltaTime);
    }
}
