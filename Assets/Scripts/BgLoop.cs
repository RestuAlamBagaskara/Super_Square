using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLoop : MonoBehaviour
{
    public float speed = -5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0);

        if(transform.position.x < -17.83)
        {
            transform.position = new Vector3(17.83f, transform.position.y);
        }
        
    }
}
