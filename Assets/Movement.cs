using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Movement : MonoBehaviour
{
    public int negativo = 1;
    public bool isdead = false;
    public bool isgrounded = true;
    public int speed = 0;
    public Rigidbody2D rigidbody; 
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isdead == true) {
            SceneManager.LoadScene("LosingScene");
        }
        float y_movement = rigidbody.velocity.y;
        float x_movement = rigidbody.velocity.x;
        rigidbody.velocity = new Vector2(1 * Input.GetAxisRaw("Horizontal") * speed, y_movement);
        if(Input.GetAxisRaw("Vertical") == 1 && isgrounded == true) {
            rigidbody.velocity = new Vector2(x_movement, 0);
            rigidbody.AddForce(new Vector2(0,1) * negativo *600);
            isgrounded = false;
        }
        RaycastHit2D[] o = Physics2D.BoxCastAll(transform.position, new Vector2(.3f,.3f), 0, transform.right , 1);
        RaycastHit2D[] p = Physics2D.BoxCastAll(transform.position, new Vector2(.3f,.3f), 0, -transform.right , 1);
        for(int n = 0; n < o.Length; n++) {
            if(o[n].transform.tag == "Platform") {
                if(Input.GetAxisRaw("Horizontal") < 0) {
                    rigidbody.velocity = new Vector2(1 * Input.GetAxisRaw("Horizontal") * speed, y_movement);
                }
                else{
                    rigidbody.velocity = new Vector2(0, y_movement);
                }
            }
        }
        for(int n = 0; n <p.Length; n++) {
            if(p[n].transform.tag == "Platform") {
                if(Input.GetAxisRaw("Horizontal") > 0) {
                    rigidbody.velocity = new Vector2(1 * Input.GetAxisRaw("Horizontal") * speed, y_movement);
                }
                else{
                    rigidbody.velocity = new Vector2(0, y_movement);
                }
            }
        }
    }
        void OnTriggerEnter2D(Collider2D coal) {
        if(coal.tag == "Platform") {
            isgrounded = true;
        }

        if(coal.tag == "Spiky Platfom") {
            isdead = true;
        }

        if(coal.tag == "Finisher") {
            SceneManager.LoadScene("MainMenu");
        }
        if(coal.tag == "ReverseP") {
            isgrounded = true;
            negativo = -1;
        }

        }
        void OnTriggerStay2D(Collider2D coal) {

        if(coal.tag == "Platform") {
            isgrounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D coal) {
        if(coal.tag == "Platform") {
            isgrounded = false;
        }
    }


}
