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

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag(targetTag).GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}