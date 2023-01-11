using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class defaultSkin : MonoBehaviour
{
    public Sprite firstSkin;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("LastSkin")){
            Sprite sliceToSave = firstSkin;
            // Texture2D spriteToTexture = spriteToSave.texture;
            Texture2D texture = new Texture2D((int)sliceToSave.rect.width, (int)sliceToSave.rect.height);
            texture.SetPixels(sliceToSave.texture.GetPixels((int)sliceToSave.rect.x, (int)sliceToSave.rect.y, (int)sliceToSave.rect.width, (int)sliceToSave.rect.height));
            texture.Apply();
            byte[] spriteData = texture.EncodeToPNG();
            PlayerPrefs.SetString("LastSkin", Convert.ToBase64String(spriteData));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
