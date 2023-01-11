using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float yMin, yMax;
    public float shootDelay;
    public GameObject projectile;
    public GameObject congratulation;

    private float shootTimer;
    private int lives = 3;
    public Text lifeE;
    public int rewardCoin = 10;


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

        

       
    }

    // when the enemy is hit by a projectile, it will lose a life
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            Debug.Log(lives);
            lives--;
            // update the lifeE text
        lifeE.text = lives.ToString();
            Destroy(collision.gameObject);
            if (lives == 0)
            {
                Destroy(gameObject);
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + rewardCoin);
                congratulation.SetActive(true);
            }
        }
    }
}

