using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitas : MonoBehaviour
{
    public Vector2 angle;
    public Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
    }
    void OnCollisionEnter2D(Collision2D call) {
        if(call.gameObject.name == "Playr"){
            Physics2D.gravity = angle;
            call.gameObject.transform.rotation = rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
