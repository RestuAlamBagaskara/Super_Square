using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoop : MonoBehaviour
{
    public float speed = -10;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0);

        if(transform.position.x < -22.43)
        {
            transform.position = new Vector3(13.17f, transform.position.y);
        }
    }
}
