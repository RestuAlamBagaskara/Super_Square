using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changebgcolor : MonoBehaviour
{
    public Image imageColor;
    public Color color1, color2;

    public bool isChanged = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void colorChange(){
        if(isChanged == false){
            imageColor.color = color1;
            isChanged = true;
        }
        else if (isChanged == true){
            imageColor.color= color2;
            isChanged = false;
        }

    }
}
