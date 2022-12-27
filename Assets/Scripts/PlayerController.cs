using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float force;
    private bool isJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && !isJump){
            rb.AddForce(new Vector2(0, force));
            transform.Rotate(0, 0, -90);
            isJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(isJump){
            isJump = false;
        }

        if(collision.transform.tag.Equals("Obstacle")){
            Destroy(gameObject);
        }

        if(collision.transform.tag.Equals("Jumper")){
            rb.AddForce(new Vector2(0, 900));
        }


    }
}
