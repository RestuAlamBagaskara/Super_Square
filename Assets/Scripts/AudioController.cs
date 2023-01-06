using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    // get data volume & sfx from GameDataSharedPref.cs
    public float volume;
    public float sfx;

    // Start is called before the first frame update
    void Start()
    {
        // get data volume & sfx from GameDataSharedPref.cs
        volume = GameDataSharedPref.instance.volume;
        sfx = GameDataSharedPref.instance.sfx;

        // set volume & sfx
        AudioListener.volume = volume;
        GetComponent<AudioSource>().volume = sfx;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // set volume & sfx
    public void setVolume(float volume)
    {
        AudioListener.volume = volume;
        GameDataSharedPref.instance.volume = volume;
    }

    public void setSfx(float sfx)
    {
        GetComponent<AudioSource>().volume = sfx;
        GameDataSharedPref.instance.sfx = sfx;
    }
}