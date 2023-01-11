using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Sprite defaultSkin;
    public float force;
    private float position;
    private Vector2 location;
    private bool isJump = false;
    public GameObject map;
    public GameObject cam;

    // untuk boss fight
    public GameObject projectile;
    public int life = 3;
    public int coin;
    public float shootTimer = 3f;
    public float shootDelay = 3f;
    public Text lifeP;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        location = rb.position;
        Debug.Log("Ini" + location);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Texture2D lastSprite = new Texture2D(1,1);
        lastSprite.LoadImage(Convert.FromBase64String(PlayerPrefs.GetString("LastSkin")));
        spriteRenderer.sprite = Sprite.Create(lastSprite, new Rect(0.0f, 0.0f, lastSprite.width, lastSprite.height), new Vector2(0.5f, 0.5f), 100.0f) ?? defaultSkin;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!isJump){
            if(Input.GetKey(KeyCode.Space)){
                isJump = true;
                rb.AddForce(new Vector2(0, force));
                transform.Rotate(0, 0, 180);
            }
        }

        if(life == 0){
                SceneManager.LoadScene("GameOver");
        }

        shootTimer -= Time.deltaTime;

        //  Set UI LifeP
        lifeP.text = life.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        // if(isJump){
        //     isJump = false;
        // }

        if(collision.transform.tag.Equals("Ground")){
            rb.freezeRotation = true;   
            isJump = false;       
        }

        if(collision.transform.tag.Equals("ToBoss")){
            SceneManager.LoadScene("BOS");
        }

        if(collision.transform.tag.Equals("Obstacle")){
            map.transform.position = new Vector2(transform.position.x, map.transform.position.y);
            rb.transform.position = location;
            // yield WaitForSeconds (3.0);
            // yield return new WaitForSeconds(5);
            if(cam.transform.position.z == 30) {
                cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -10);
                cam.transform.rotation = Quaternion.Euler(Vector3.zero);
                // cam.transform.Rotate(cam.transform.rotation.x, 180, cam.transform.rotation.z);
            }
            if(cam.transform.rotation.x == -180){
                 cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -10);
                // cam.transform.Rotate(cam.transform.rotation.x, 180, cam.transform.rotation.z);
                cam.transform.rotation = Quaternion.Euler(Vector3.zero);
            }
            cam.transform.rotation = Quaternion.Euler(Vector3.zero);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.transform.tag.Equals("Jumper")){
            rb.AddForce(new Vector2(0, 2000));
            isJump = true;
        }

        if(collision.transform.tag.Equals("Coin")){
            coin = PlayerPrefs.GetInt("Coin") + 1;
            PlayerPrefs.SetInt("Coin" , coin);
            Destroy(collision.gameObject);
        }  
        // jika terkena projectile maka life berkurang
        if(collision.transform.tag.Equals("Projectile")){
            life--;
        }

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
    // fungsi shoot projectile dengan tombol dari layar
    public void Shoot(){
        if (shootTimer <= 0)
        {
            shootTimer = shootDelay;
            Instantiate(projectile, transform.position, Quaternion.identity);
        }
    }
}
