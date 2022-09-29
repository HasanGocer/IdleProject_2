using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    //oyunun tüm prefeblerinin ve oyunun hangi safhasýnda olduðu deðeri burada dönülür

    //Bools
    public bool startGame;
    public bool inPlacement;
    public bool inMerge;
    public bool inFight;
    public bool inMarket;
    public bool inFail;
    public bool inFinish;
    public bool inGameFinish;


    public int level;
    public int money, addedMoney;
    public int vibration;
    public int sound;

    private void Start()
    {
        startGame = true;

        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetInt("money");
        }
        else
        {
            PlayerPrefs.SetInt("money", 0);
        }

        if (PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
        }
        else
        {
            PlayerPrefs.SetInt("level", 1);
        }

        if (PlayerPrefs.HasKey("vibration"))
        {
            vibration = PlayerPrefs.GetInt("vibration");
        }
        else
        {
            PlayerPrefs.SetInt("vibration", 1);
        }

        if (PlayerPrefs.HasKey("sound"))
        {
            sound = PlayerPrefs.GetInt("sound");
        }
        else
        {
            PlayerPrefs.SetInt("sound", 1);
        }


    }

    public void SetLevel()
    {
        PlayerPrefs.SetInt("level", level);
    }

    public void SetMoney()
    {
        PlayerPrefs.SetInt("money", money);
    }

    public void SetSound()
    {
        PlayerPrefs.SetInt("sound", sound);
    }

    public void SetVibration()
    {
        PlayerPrefs.SetInt("vibration", vibration);
    }
}
