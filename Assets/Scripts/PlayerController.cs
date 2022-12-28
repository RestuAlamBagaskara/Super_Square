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
    public GameObject cam;

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
            transform.Rotate(0, 0, 180);
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
            if(cam.transform.position.z == 30) {
                cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -10);
                cam.transform.Rotate(cam.transform.rotation.x, 180, cam.transform.rotation.z);
            }
            else{
                cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, 30);
                cam.transform.Rotate(cam.transform.rotation.x, 180, cam.transform.rotation.z);
            }
        }

        if(collision.transform.tag.Equals("PortalVertical")){
            if(cam.transform.position.z == 30) {
                cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -10);
                cam.transform.Rotate(cam.transform.rotation.x, -180, 180);
            }
            else{
                cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, 30);
                cam.transform.Rotate(cam.transform.rotation.x, -180, 180);
            }
        }
    }
}
