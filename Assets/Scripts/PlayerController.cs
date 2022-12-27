using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float force;
    private float position;
    private bool isJump = false;
    public GameObject map;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        position = Portal.position;
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

        if(collision.transform.tag.Equals("Ground")){
            rb.freezeRotation = true;
        }

        if(collision.transform.tag.Equals("Obstacle")){
            map.transform.position = new Vector2(transform.position.x, map.transform.position.y);
        }

        if(collision.transform.tag.Equals("Jumper")){
            rb.AddForce(new Vector2(0, 2000));
            isJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.transform.tag.Equals("PortalHorizontal")){
            MapMover.speed = -MapMover.speed;
            map.transform.position = new Vector2(position + 4.0f, map.transform.position.y);
            map.transform.Rotate(0, -180, 0);
        }

        if(collision.transform.tag.Equals("PortalVertical")){
            rb.gravityScale = -rb.gravityScale;
            map.transform.position = new Vector2(19, map.transform.position.y);
            map.transform.Rotate(180, 0, 0);
        }
    }
}
