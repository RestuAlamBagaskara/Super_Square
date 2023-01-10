using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataSharedPref : MonoBehaviour
{
    public static GameDataSharedPref instance;

    public int coin;
    public int level;
    public int selectedCharacter;
    // list data buyed character
    public List<bool> buyedCharacter = new List<bool>();

    // data volume & sfx
    public float volume;
    public float sfx;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // save data per object
    public void saveCoin(int coin)
    {
        PlayerPrefs.SetInt("coin", coin);
    }

    public void saveLevel(int level)
    {
        PlayerPrefs.SetInt("level", level);
    }

    public void saveSelectedCharacter(int selectedCharacter)
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
    }

    public void saveBuyedCharacter(List<bool> buyedCharacter)
    {
        for (int i = 0; i < buyedCharacter.Count; i++)
        {
            PlayerPrefs.SetInt("buyedCharacter" + i, buyedCharacter[i] ? 1 : 0);
        }
    }

    public void saveVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void saveSfx(float sfx)
    {
        PlayerPrefs.SetFloat("sfx", sfx);
    }

    // load data per object
    public void loadCoin()
    {
        coin = PlayerPrefs.GetInt("coin");
    }

    public void loadLevel()
    {
        level = PlayerPrefs.GetInt("level");
    }

    public void loadSelectedCharacter()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
    }

    public void loadBuyedCharacter()
    {
        for (int i = 0; i < buyedCharacter.Count; i++)
        {
            buyedCharacter[i] = PlayerPrefs.GetInt("buyedCharacter" + i) == 1 ? true : false;
        }
    }

    public void loadVolume()
    {
        volume = PlayerPrefs.GetFloat("volume");
    }

    public void loadSfx()
    {
        sfx = PlayerPrefs.GetFloat("sfx");
    }

    // load all data
    public void loadAllData()
    {
        loadCoin();
        loadLevel();
        loadSelectedCharacter();
        loadBuyedCharacter();
        loadVolume();
        loadSfx();
    }
}