using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private int level;

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

    public void nextLevel()
    {
        if (level <= 5)
        {
            level += 1;
            GameManager.instance.spawnSeconds *= 0.8f;
        }
    }
}
