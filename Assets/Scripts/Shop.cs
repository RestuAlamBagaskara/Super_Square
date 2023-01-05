// Script for the shop
// User can buy items from the shop with coins from GameDataSharedPref.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    // get coin from GameDataSharedPref.cs
    public Text coinText;
    public int coin;
    
    // 6 items in the shop with different prices
    public int[] itemPrice = new int[6];
    public Text[] itemPriceText = new Text[6];
    public GameObject[] item = new GameObject[6];
    public GameObject[] itemButton = new GameObject[6];
    public GameObject[] buyedCharacter = new GameObject[6];

    // Start is called before the first frame update
    void Start()
    {
        // get coin from GameDataSharedPref.cs
        coin = GameDataSharedPref.instance.coin;
        coinText.text = coin.ToString();

        // get price of items
        for (int i = 0; i < itemPrice.Length; i++)
        {
            itemPrice[i] = Random.Range(10, 100);
            itemPriceText[i].text = itemPrice[i].ToString();
        }

        // get buyed character
        for (int i = 0; i < buyedCharacter.Length; i++)
        {
            if (GameDataSharedPref.instance.buyedCharacter[i])
            {
                buyedCharacter[i].SetActive(true);
                itemButton[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // buy item and save to GameDataSharedPref.cs
    public void buyItem(int index)
    {
        if (coin >= itemPrice[index])
        {
            coin -= itemPrice[index];
            coinText.text = coin.ToString();
            GameDataSharedPref.instance.coin = coin;
            GameDataSharedPref.instance.saveCoin();

            item[index].SetActive(true);
            itemButton[index].SetActive(false);
            buyedCharacter[index].SetActive(true);

            GameDataSharedPref.instance.buyedCharacter[index] = true;
            GameDataSharedPref.instance.saveBuyedCharacter();
        }
    }
}