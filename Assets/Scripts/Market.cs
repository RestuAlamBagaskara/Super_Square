using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Market : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Image preview;
    public Sprite[] character;
    public Image[] button;
    private Sprite selectedSprite;
    public GameObject popUp;
    public GameObject CoinKurang;
    public Text coinTxt;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Coin") == 0){
            PlayerPrefs.SetInt("Coin", 1000);
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        Texture2D lastSprite = new Texture2D(1,1);
        lastSprite.LoadImage(Convert.FromBase64String(PlayerPrefs.GetString("LastSkin")));
        spriteRenderer.sprite = Sprite.Create(lastSprite, new Rect(0.0f, 0.0f, lastSprite.width, lastSprite.height), new Vector2(0.5f, 0.5f), 100.0f) ?? spriteRenderer.sprite;
        spriteRenderer.color = Color.blue;
        for (int i = 0; i < character.Length; i++)
        {
            if(!PlayerPrefs.HasKey(character[i].name)){
                PlayerPrefs.SetInt(character[i].name, 0);
            }
        }
        PlayerPrefs.SetInt("Charcter_1", 1);
    }

    // Update is called once per frame
    void Update()
    {
        coinTxt.text = PlayerPrefs.GetInt("Coin").ToString();
        for (int i = 0; i < character.Length; i++)
        {
            if(character[i].name == button[i].sprite.name && PlayerPrefs.GetInt(character[i].name) == 1){
                button[i].color = Color.blue;
            }
        }
    }

    public void OnSpriteClick(Sprite newSprite)
    {
        selectedSprite = newSprite;
        preview.sprite = newSprite;
        if(PlayerPrefs.GetInt(selectedSprite.name) == 1){
            spriteRenderer.sprite = newSprite;
            Sprite sliceToSave = spriteRenderer.sprite;
            // Texture2D spriteToTexture = spriteToSave.texture;
            Texture2D texture = new Texture2D((int)sliceToSave.rect.width, (int)sliceToSave.rect.height);
            texture.SetPixels(sliceToSave.texture.GetPixels((int)sliceToSave.rect.x, (int)sliceToSave.rect.y, (int)sliceToSave.rect.width, (int)sliceToSave.rect.height));
            texture.Apply();
            byte[] spriteData = texture.EncodeToPNG();
            PlayerPrefs.SetString("LastSkin", Convert.ToBase64String(spriteData));
        }
        else {
            popUp.SetActive(true);
        }
    }

    public void buy(){
        if(PlayerPrefs.GetInt("Coin") >= 10){
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - 10);
            PlayerPrefs.SetInt(selectedSprite.name, 1);
            spriteRenderer.sprite = selectedSprite;
            Sprite sliceToSave = spriteRenderer.sprite;
            // Texture2D spriteToTexture = spriteToSave.texture;
            Texture2D texture = new Texture2D((int)sliceToSave.rect.width, (int)sliceToSave.rect.height);
            texture.SetPixels(sliceToSave.texture.GetPixels((int)sliceToSave.rect.x, (int)sliceToSave.rect.y, (int)sliceToSave.rect.width, (int)sliceToSave.rect.height));
            texture.Apply();
            byte[] spriteData = texture.EncodeToPNG();
            PlayerPrefs.SetString("LastSkin", Convert.ToBase64String(spriteData));
            popUp.SetActive(false);
        }
        else{
            CoinKurang.SetActive(true);
            popUp.SetActive(false);
        }
    }

    public void close(){
        popUp.SetActive(false);
    }
    public void closeCoinKurang(){
        CoinKurang.SetActive(false);
    }
}
