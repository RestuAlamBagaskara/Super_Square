using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonShop : MonoBehaviour
{
    // get data buyed character from GameDataSharedPref.cs
    public List<bool> buyedCharacter = new List<bool>();

    public int index;

    // Start is called before the first frame update
    void Start()
    {
        // get data buyed character from GameDataSharedPref.cs
        buyedCharacter = GameDataSharedPref.instance.buyedCharacter;

        // set button color to grey if not owned yet
        if (!buyedCharacter[index])
        {
            GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}