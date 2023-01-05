using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public float jedaTembakan = 1f;
    public int life = 3;
    public float batasAtas = 4f;
    public float batasBawah = -4f;
    public GameObject enemyProjectile;

    // Fungsi Start 
    void Start()
    {

    }

    void MoveUp()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void MoveDown()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void TerkenaPeluru()
    {
        life -= 1;
        if (life == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Menu");
        }
    }

    // Fungsi Update
    void Update()
    {
        if (transform.position.y > batasAtas)
        {
            MoveDown();
        }
        else if (transform.position.y < batasBawah)
        {
            MoveUp();
        }
        else
        {
            MoveUp();
        }

        jedaTembakan -= Time.deltaTime;
        if (jedaTembakan <= 0)
        {
            GameObject peluru = Instantiate(enemyProjectile, transform.position, Quaternion.identity);
            jedaTembakan = 1f;
        }
    }
}





