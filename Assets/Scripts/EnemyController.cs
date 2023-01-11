using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float yMin, yMax;
    public float shootDelay;
    public GameObject projectile;

    private float shootTimer;
    private int lives = 3;
    public Text lifeE;


    // Start is called before the first frame update
    void Start()
    {
        shootTimer = shootDelay;
    }

    // Update is called once per frame
    void Update()
    {
        // move up and down
        transform.position += Vector3.up * speed * Time.deltaTime;

        // change direction when reach the top or bottom
        if (transform.position.y > yMax)
        {
            speed = -Mathf.Abs(speed);
        }
        else if (transform.position.y < yMin)
        {
            speed = Mathf.Abs(speed);
        }

        // shoot a projectile
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            shootTimer = shootDelay;
            Instantiate(projectile, transform.position, Quaternion.identity);
        }

        // update the lifeE text
        lifeE.text = lives.ToString();

        if(lives == 0)
        {
            Destroy(gameObject);
            // invoke the game over scene 2 seconds after the enemy is destroyed
            Invoke("GameOver", 2f); 
        }
    }

    // when the enemy is hit by a projectile, it will lose a life
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            lives--;
            Destroy(collision.gameObject);
            if (lives <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

