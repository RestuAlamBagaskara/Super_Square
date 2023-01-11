using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectile; 
    // Digunakan untuk menentukan object peluru berdasarkan tag
    public string targetTag;
    public float speed;
    private Transform target;

    // deklarasi waktu untuk menghancurkan peluru
    public float destroyTime = 3f;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag(targetTag).GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // menghancurkan peluru setelah 3 detik
        if (destroyTime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            destroyTime -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.tag.Equals(targetTag)){
            Destroy(gameObject);
        }
    }
}