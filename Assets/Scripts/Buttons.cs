using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoSingleton<Buttons>
{
    //butonlarýn bulunduðu template bir koddur
    //marketin düzenlenmesi lazým ve market geliþtirilmeli

    [SerializeField] private GameObject _GlobalGame;
    public Text moneyText;
    public Text levelText;

    [SerializeField] private Button _startButton;
    public GameObject startGame;

    [SerializeField] private Sprite _red, _green;
    [SerializeField] private Button _settingBackButton;

    [SerializeField] private Button _soundButton, _vibrationButton;

    [SerializeField] private Button _settingButton;
    [SerializeField] private GameObject _settingGame;

    /*[SerializeField] private Button _marketButton;
    [SerializeField] private Button _archerArrowSpeedButton, _archerShotButton, _characterSpeedButton, _towerButton;
    [SerializeField] private Text _archerArrowSpeedText, _archerShotText, _characterSpeedText, _towerText;
    [SerializeField] private Text _archerArrowSpeedPriceText, _archerShotPriceText, _characterSpeedPriceText, _towerPriceText;
    [SerializeField] private List<Button> _marketSelectedButton = new List<Button>();
    [SerializeField] private List<GameObject> _marketSelectedGame = new List<GameObject>();
    [SerializeField] private Button backToGame;
    public GameObject marketGame;*/

    [SerializeField] private Button _finishButton;
    public GameObject finishGame;

    [SerializeField] private Button _failResumeButton, _failRetryButton;
    public GameObject failGame;

    [SerializeField] private Button _rewardButton;
    public GameObject mainChestGame, chestChoseGame, openChestGame;
    [SerializeField] private Button _chest1Button, _chest2Button, _chest3Button;
    [SerializeField] private Image _chestImage1, _chestImage2;
    [SerializeField] private Text _chestMoney;
    [SerializeField] private Button _rewardLastButton;

    private void Start()
    {
        levelText.text = GameManager.Instance.level.ToString();
        ButtonStart();

        TextStart();

        if (GameManager.Instance.sound == 1)
        {
            _soundButton.gameObject.GetComponent<Image>().sprite = _green;
            //SoundSystem.Instance.MainMusicPlay();
        }
        else
        {
            _soundButton.gameObject.GetComponent<Image>().sprite = _red;
        }

        if (GameManager.Instance.vibration == 1)
        {
            _vibrationButton.gameObject.GetComponent<Image>().sprite = _green;
        }
        else
        {
            _vibrationButton.gameObject.GetComponent<Image>().sprite = _red;
        }
    }

    private void ButtonStart()
    {
        _startButton.onClick.AddListener(StartButton);
        _soundButton.onClick.AddListener(SoundButton);
        _vibrationButton.onClick.AddListener(VibrationButton);
        /*_archerArrowSpeedButton.onClick.AddListener(ArcherArrowSpeedFactorPlus);
        _marketButton.onClick.AddListener(MarketButton);
        _rewardButton.onClick.AddListener(RewardOpen);
        _rewardLastButton.onClick.AddListener(RewardLastButton);
        backToGame.onClick.AddListener(MarketBackButton);*/
        _settingButton.onClick.AddListener(SettingButton);
        _settingBackButton.onClick.AddListener(SettingBackButton);
        _finishButton.onClick.AddListener(FinishButton);
        _failResumeButton.onClick.AddListener(FailResumeButton);
        _failRetryButton.onClick.AddListener(FailRetryButton);
        _chest1Button.onClick.AddListener(OpenChest);
        _chest2Button.onClick.AddListener(OpenChest);
        _chest3Button.onClick.AddListener(OpenChest);

    }

    private void TextStart()
    {
        /*_archerArrowSpeedText.text = RivalD.Instance.field.archerArrowSpeed.ToString();
        _archerArrowSpeedPriceText.text = "" + RivalD.Instance.fieldPrice.archerArrowSpeed;
        _archerShotText.text = RivalD.Instance.field.archerShot.ToString();
        _archerShotPriceText.text = "" + RivalD.Instance.fieldPrice.archerShot;
        _characterSpeedText.text = RivalD.Instance.field.characterSpeed.ToString();
        _characterSpeedPriceText.text = "" + RivalD.Instance.fieldPrice.characterSpeed;
        _towerText.text = RivalD.Instance.field.Tower.ToString();
        _towerPriceText.text = "" + RivalD.Instance.fieldPrice.Tower;*/
    }



    /* private void ArcherArrowSpeedFactorPlus()
     {
         if (RivalD.Instance.fieldPrice.archerArrowSpeed <= GameStart.Instance.money && RivalD.Instance.factor.archerArrowSpeed <= RivalD.Instance.maxFactor.archerArrowSpeed && RivalD.Instance.field.archerArrowSpeed != RivalD.Instance.max.archerArrowSpeed)
         {
             GameStart.Instance.money -= (int)RivalD.Instance.fieldPrice.archerArrowSpeed;
             GameStart.Instance.MoneySet();
             RivalD.Instance.fieldPrice.archerArrowSpeed = (int)((float)RivalD.Instance.fieldPrice.archerArrowSpeed * RivalD.Instance.fieldPriceFactor.archerArrowSpeed);
             RivalD.Instance.factor.archerArrowSpeed++;
             RivalD.Instance.ArrowSpeed();
             _archerArrowSpeedPriceText.text = "" + RivalD.Instance.fieldPrice.archerArrowSpeed;
             GameStart.Instance.SetArcherArrowSpeedFactor();
             GameStart.Instance.SetArcherArrowSpeedPrice();
             _archerArrowSpeedText.text = RivalD.Instance.field.archerArrowSpeed.ToString();
         }
     }*/




    /*public void MarketSelected()
    {
        for (int i = 0; i < _marketSelectedButton.Count; i++)
        {
            if (i == GameManager.Instance.MarketSelectWindow)
            {
                _marketSelectedGame[i].SetActive(true);
                continue;
            }
            _marketSelectedGame[i].SetActive(false);
        }
    }*/

    public void StartButton()
    {
        GameManager.Instance.startGame = false;
        GameManager.Instance.inPlacement = true;
        GameManager.Instance.inFight = true;
        startGame.SetActive(false);
    }

    private void SettingButton()
    {
        _settingGame.SetActive(true);
        _GlobalGame.SetActive(false);

        if (GameManager.Instance.inFinish == true)
        {
            finishGame.SetActive(false);
        }
        if (GameManager.Instance.startGame == true)
        {
            startGame.SetActive(false);
        }

    }

    private void SettingBackButton()
    {
        _settingGame.SetActive(false);
        _GlobalGame.SetActive(true);

        if (GameManager.Instance.inFinish == true)
        {
            finishGame.SetActive(true);
        }
        if (GameManager.Instance.startGame == true)
        {
            startGame.SetActive(false);
        }
    }

    private void SoundButton()
    {
        if (GameManager.Instance.sound == 1)
        {
            GameManager.Instance.sound = 0;
            _soundButton.gameObject.GetComponent<Image>().sprite = _red;
            SoundSystem.Instance.MainMusicStop();
            GameManager.Instance.SetSound();
        }
        else
        {
            GameManager.Instance.sound = 1;
            _soundButton.gameObject.GetComponent<Image>().sprite = _green;
            SoundSystem.Instance.MainMusicPlay();
            GameManager.Instance.SetSound();
        }
    }

    private void VibrationButton()
    {
        if (GameManager.Instance.vibration == 1)
        {
            GameManager.Instance.vibration = 0;
            _vibrationButton.gameObject.GetComponent<Image>().sprite = _red;
            GameManager.Instance.SetVibration();
        }
        else
        {
            GameManager.Instance.vibration = 1;
            _vibrationButton.gameObject.GetComponent<Image>().sprite = _green;
            GameManager.Instance.SetVibration();
        }
    }

    private void FinishButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void FailResumeButton()
    {
        //reklam
    }

    private void FailRetryButton()
    {
        SceneManager.LoadScene(0);
    }

    private void OpenChest()
    {
        int count = Random.Range(0, 10);

        if (count % 2 == 0)
        {
            chestChoseGame.SetActive(false);
            openChestGame.SetActive(true);
            _chestImage1.gameObject.SetActive(true);
            count = Random.Range(50, 100);
            _chestMoney.text = "+ " + count;
            GameManager.Instance.money += count;
            GameManager.Instance.SetMoney();
        }
        else
        {
            chestChoseGame.SetActive(false);
            openChestGame.SetActive(true);
            _chestImage2.gameObject.SetActive(true);
            count = Random.Range(30, 60);
            _chestMoney.text = "+ " + count;
            GameManager.Instance.money += count;
            GameManager.Instance.SetMoney();
        }
    }

    /*private void RewardOpen()
    {
        marketGame.SetActive(false);
        mainChestGame.SetActive(true);
        chestChoseGame.SetActive(true);
    }

    private void RewardLastButton()
    {
        mainChestGame.SetActive(false);
        openChestGame.SetActive(false);
        chestChoseGame.SetActive(true);
        marketGame.SetActive(true);
    }

    private void MarketButton()
    {
        _marketButton.gameObject.SetActive(false);
        GameManager.Instance.inMarket = true;
        marketGame.SetActive(true);
        _marketButton.gameObject.SetActive(false);

        if (GameManager.Instance.inFinish == true)
        {
            finishGame.SetActive(false);
        }
        if (GameManager.Instance.startGame == true)
        {
            startGame.SetActive(false);
        }

    }

    private void MarketBackButton()
    {
        _marketButton.gameObject.SetActive(true);
        GameManager.Instance.inMarket = false;
        marketGame.SetActive(false);
        _marketButton.gameObject.SetActive(true);

        if (GameManager.Instance.inFinish == true)
        {
            finishGame.SetActive(true);
        }
        if (GameManager.Instance.startGame == true)
        {
            startGame.SetActive(false);
        }
    }*/
}
