using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text scoreText;
    public Text healthText;
    public GameObject settingButton;


    public GameObject gameOverMenu;
    public GameObject settingMenu;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }

    public void startMenu(int score, int health)
    {
        scoreText.text = score.ToString();
        healthText.text = health.ToString();
    }

    public void changeScoreUI(int score)
    {
        scoreText.text = score.ToString();
    }

    public void GetHitUI(int health)
    {
        healthText.text = health.ToString();
    }

    public void GameOverUI()
    {
        gameOverMenu.SetActive(true);
        settingButton.SetActive(false);
    }

    public void RestartUI(int score, int health)
    {
        scoreText.text = score.ToString();
        healthText.text = health.ToString();
        gameOverMenu.SetActive(false);
        settingButton.SetActive(true);
    }

    public void BackToMenuUI()
    {
        settingButton.SetActive(true);
    }

    public void OpenSettingMenuUI()
    {
        settingMenu.SetActive(true);
        settingButton.SetActive(false);
    }

    public void CloseSettingMenuUI()
    {
        settingMenu.SetActive(false);
        settingButton.SetActive(true);
    }
}
