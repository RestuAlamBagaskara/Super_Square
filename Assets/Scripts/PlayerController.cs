using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public float force;
    private float position;
    private bool isJump = false;
    public GameObject map;
    public GameObject cam;
    public int coin;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Texture2D lastSprite = new Texture2D(1,1);
        lastSprite.LoadImage(Convert.FromBase64String(PlayerPrefs.GetString("LastSkin")));
        spriteRenderer.sprite = Sprite.Create(lastSprite, new Rect(0.0f, 0.0f, lastSprite.width, lastSprite.height), new Vector2(0.5f, 0.5f), 100.0f);
        Debug.Log(PlayerPrefs.GetInt("Coin"));
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

        if(collision.transform.tag.Equals("Coin")){
            coin = PlayerPrefs.GetInt("Coin") + 1;
            PlayerPrefs.SetInt("Coin" , coin);
            Destroy(collision.gameObject);
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
    
    public void OnSpriteClick(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
        PlayerPrefs.SetString("LastSkin", Convert.ToBase64String(spriteRenderer.sprite.texture.EncodeToPNG()));
    }
}
