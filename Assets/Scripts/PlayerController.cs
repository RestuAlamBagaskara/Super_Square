using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float force;
    private float position;
    private Vector2 location;
    private bool isJump = false;
    public GameObject map;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        position = Portal.position;
        Debug.Log("Ini" + position);
        location = rb.position;
        Debug.Log("Ini" + location);
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetMouseButton(0) && !isJump){
        //     isJump = true;
        //     rb.AddForce(new Vector2(0, force));
        //     transform.Rotate(0, 0, 180);
        // }
if(!isJump){
    //    if(Input.GetMouseButton(0)){
       if(Input.GetKey(KeyCode.Space)){
            isJump = true;
            rb.AddForce(new Vector2(0, force));
            transform.Rotate(0, 0, 180);
        }
}
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // if(isJump){
        //     isJump = false;
        // }

        if(collision.transform.tag.Equals("Ground")){
            rb.freezeRotation = true;   
            isJump = false;       
        }

        if(collision.transform.tag.Equals("Obstacle")){
            map.transform.position = new Vector2(transform.position.x, map.transform.position.y);
            rb.transform.position = location;
            // yield WaitForSeconds (3.0);
            // yield return new WaitForSeconds(5);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.transform.tag.Equals("Jumper")){
            rb.AddForce(new Vector2(0, 2000));
            isJump = true;
        }

        if(collision.transform.tag.Equals("PortalHorizontal")){
            MapMover.speed = -MapMover.speed;
            map.transform.position = new Vector2(position, map.transform.position.y);
            map.transform.Rotate(0, -180, 0);
        }

        if(collision.transform.tag.Equals("PortalVertical")){
            rb.gravityScale = -rb.gravityScale;
            force = -force;
            map.transform.position = new Vector2(position, map.transform.position.y);
            map.transform.Rotate(180, 0, 0);
        }
    }
}
