using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public float force;
    private float position;
    private bool isJump = false;
    public GameObject map;
    public GameObject cam;

    // untuk boss fight
    public GameObject canvasControll;
    public GameObject projectile;
    public int life = 3;
    public int coin;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Texture2D lastSprite = new Texture2D(1,1);
        lastSprite.LoadImage(Convert.FromBase64String(PlayerPrefs.GetString("LastSkin")));
        spriteRenderer.sprite = Sprite.Create(lastSprite, new Rect(0.0f, 0.0f, lastSprite.width, lastSprite.height), new Vector2(0.5f, 0.5f), 100.0f) ?? spriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && !isJump){
            rb.AddForce(new Vector2(0, force));
            transform.Rotate(0, 0, 180);
            isJump = true;
        }

        // jika life player habis maka game over
        if(life == 0){
            SceneManager.LoadScene("GameOver");
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
            gameObject.SetActive(false);
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

         if(collision.transform.tag.Equals("BOSFIGHT")){
            canvasControll.SetActive(true);
        }   
        // jika terkena projectile maka life berkurang
        if(collision.transform.tag.Equals("Projectile")){
            life--;
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

    // fungsi gerak kanan atas bawah kiri dengan tombol dari layar
    public void MoveUp(){
        rb.AddForce(new Vector2(0, force));
        transform.Rotate(0, 0, 180);
        isJump = true;
    }

    public void MoveDown(){
        rb.AddForce(new Vector2(0, -force));
        transform.Rotate(0, 0, 180);
        isJump = true;
    }

    public void MoveLeft(){
        rb.AddForce(new Vector2(-force, 0));
        transform.Rotate(0, 0, 180);
        isJump = true;
    }

    public void MoveRight(){
        rb.AddForce(new Vector2(force, 0));
        transform.Rotate(0, 0, 180);
        isJump = true;
    }
    // fungsi shoot projectile dengan tombol dari layar
    public void Shoot(){
        GameObject peluru = Instantiate(projectile, transform.position, Quaternion.identity);
        peluru.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1000));
    }
}
