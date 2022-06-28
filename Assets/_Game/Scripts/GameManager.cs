using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int score;

    public int fullHealth;
    private int health;

    //public GameObject player;

    public float spawnSeconds;
    public GameObject zombiePrefabs;
    public float zombieDistanceFromPlayer;

    public static GameManager instance;

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

    private void Start()
    {
        score = 0;
        health = fullHealth;
        UIManager.instance.startMenu(score, health);

        StartCoroutine(SpawnZombie());
    }

    public void ChangeScore()
    {
        score += 1;
        UIManager.instance.changeScoreUI(score);
    }

    public void GetHit()
    {
        health -= 1;
        if (health > 0)
        {
            UIManager.instance.GetHitUI(health);
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        UIManager.instance.GameOverUI();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        score = 0;
        health = fullHealth;
        UIManager.instance.RestartUI(score, health);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        UIManager.instance.BackToMenuUI();
    }

    public void OpenSettingMenu()
    {
        Time.timeScale = 0;
        UIManager.instance.OpenSettingMenuUI();
    }

    public void CloseSettingMenu()
    {
        Time.timeScale = 1;
        UIManager.instance.CloseSettingMenuUI();
    }

    IEnumerator SpawnZombie()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnSeconds);
            GameObject newZombie = Instantiate(zombiePrefabs) as GameObject;
            float randomYDegrees = Random.Range(0, Mathf.PI * 2);
            float randomX = Mathf.Sin(randomYDegrees) * zombieDistanceFromPlayer;
            float randomZ = Mathf.Cos(randomYDegrees) * zombieDistanceFromPlayer;

            newZombie.transform.position = new Vector3(randomX, 1, randomZ);
            newZombie.GetComponent<Zombie>().vectorDirection = new Vector3(randomX, 0f, randomZ) * -1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
