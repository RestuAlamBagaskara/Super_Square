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
    public void saveCoin()
    {
        PlayerPrefs.SetInt("coin", coin);
    }

    public void saveLevel()
    {
        PlayerPrefs.SetInt("level", level);
    }

    public void saveSelectedCharacter()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
    }

    public void saveBuyedCharacter()
    {
        for (int i = 0; i < buyedCharacter.Count; i++)
        {
            PlayerPrefs.SetInt("buyedCharacter" + i, buyedCharacter[i] ? 1 : 0);
        }
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

    // save all data
    public void saveAllData()
    {
        saveCoin();
        saveLevel();
        saveSelectedCharacter();
        saveBuyedCharacter();
    }

    // load all data
    public void loadAllData()
    {
        loadCoin();
        loadLevel();
        loadSelectedCharacter();
        loadBuyedCharacter();
    }

    // reset all data
    public void resetAllData()
    {
        coin = 0;
        level = 0;
        selectedCharacter = 0;
        buyedCharacter = new List<bool>();
        saveAllData();
    }
}