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
    
    // 8 Skins for the player to choose from in the shop
    public GameObject[] skins;
    public int selectedSkin;
    public int[] skinPrice;
    public Text[] skinPriceText;
    public GameObject[] skinBuyButton;
    public GameObject[] skinSelectedButton;
    public GameObject[] skinOwnedButton;
    public List<bool> skinOwned = new List<bool>();

    // Start is called before the first frame update
    void Start()
    {
        // get coin from GameDataSharedPref.cs
        coin = GameDataSharedPref.instance.coin;
        coinText.text = coin.ToString();

        // get selected skin from GameDataSharedPref.cs
        selectedSkin = GameDataSharedPref.instance.selectedCharacter;
        skins[selectedSkin].SetActive(true);

        // get owned skin from GameDataSharedPref.cs
        for (int i = 0; i < skins.Length; i++)
        {
            if (GameDataSharedPref.instance.buyedCharacter[i])
            {
                skinOwned.Add(true);
                skinOwnedButton[i].SetActive(true);
                skinBuyButton[i].SetActive(false);
                skinSelectedButton[i].SetActive(false);
            }
            else
            {
                skinOwned.Add(false);
                skinOwnedButton[i].SetActive(false);
                skinBuyButton[i].SetActive(true);
                skinSelectedButton[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // get coin from GameDataSharedPref.cs
        coin = GameDataSharedPref.instance.coin;
        coinText.text = coin.ToString();

        // get selected skin from GameDataSharedPref.cs
        selectedSkin = GameDataSharedPref.instance.selectedCharacter;
        skins[selectedSkin].SetActive(true);

        // get owned skin from GameDataSharedPref.cs
        for (int i = 0; i < skins.Length; i++)
        {
            if (GameDataSharedPref.instance.buyedCharacter[i])
            {
                skinOwned[i] = true;
                skinOwnedButton[i].SetActive(true);
                skinBuyButton[i].SetActive(false);
                skinSelectedButton[i].SetActive(false);
            }
            else
            {
                skinOwned[i] = false;
                skinOwnedButton[i].SetActive(false);
                skinBuyButton[i].SetActive(true);
                skinSelectedButton[i].SetActive(false);
            }
        }
    }

    // select skin
    public void selectSkin(int skinIndex)
    {
        if (skinOwned[skinIndex])
        {
            skins[selectedSkin].SetActive(false);
            selectedSkin = skinIndex;
            skins[selectedSkin].SetActive(true);
            GameDataSharedPref.instance.saveSelectedCharacter(selectedSkin);
        }
    }

    // buy skin
    public void buySkin(int skinIndex)
    {
        if (coin >= skinPrice[skinIndex])
        {
            coin -= skinPrice[skinIndex];
            GameDataSharedPref.instance.saveCoin(coin);
            skinOwned[skinIndex] = true;
            GameDataSharedPref.instance.buyedCharacter[skinIndex] = true;
            GameDataSharedPref.instance.saveBuyedCharacter(GameDataSharedPref.instance.buyedCharacter);
            skinOwnedButton[skinIndex].SetActive(true);
            skinBuyButton[skinIndex].SetActive(false);
            skinSelectedButton[skinIndex].SetActive(false);
        }
    }
}
