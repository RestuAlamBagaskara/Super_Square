using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBosController : MonoBehaviour
{
    public float speed;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        if(gameObject.name is "L")
        {
            player.transform.Translate(Vector3.left*speed*Time.fixedDeltaTime, Space.Self);
        }else if(gameObject.name is "R")
        {
            player.transform.Translate(Vector3.right*speed*Time.fixedDeltaTime, Space.Self);
        }

        if(gameObject.name is "T")
        {
            player.transform.Translate(Vector3.up*speed*Time.fixedDeltaTime, Space.Self);
        }else if(gameObject.name is "D")
        {
            player.transform.Translate(Vector3.down*speed*Time.fixedDeltaTime, Space.Self);
        }
    }

    public void MoveLeft()
    {
        player.transform.Translate(Vector3.left*speed*Time.fixedDeltaTime, Space.Self);
    }

    public void MoveRight()
    {
        player.transform.Translate(Vector3.right*speed*Time.fixedDeltaTime, Space.Self);
    }

    public void MoveUp()
    {
        player.transform.Translate(Vector3.up*speed*Time.fixedDeltaTime, Space.Self);
    }

    public void MoveDown()
    {
        player.transform.Translate(Vector3.down*speed*Time.fixedDeltaTime, Space.Self);
    }
}
