using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Cheats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheatCoin()
    {
        PlayerPrefs.SetInt("Coin", 999);
    }

    public void CheatBos(){
        SceneManager.LoadScene("Bos1");
    }
}
