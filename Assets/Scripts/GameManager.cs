using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int lives;
    private int score;
    private int level;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        NewGame();
    }

    void NewGame()
    {
        lives = 3;
        score = 0;

        LoadLevel(1);
    }

    void LoadLevel(int index) 
    {
        level = index;
        SceneManager.LoadScene(level);

        Camera camera = Camera.main;

        if(camera != null) 
        {
            camera.cullingMask = 0;
        }

        Invoke(nameof(LoadScene), 1f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(level);
    } 

    public void LevelComplete()
    {
        score += 1000;
        int nextLevel = level + 1;
        LoadLevel(nextLevel);

        if(nextLevel < SceneManager.sceneCountInBuildSettings)
        {
            LoadLevel(nextLevel);
        }
        else {
            LoadLevel(1);
        }
    }

    public void LevelFailed()
    {
        lives--;

        if(lives <= 0)
        {
            NewGame();
        }
        else {
            LoadLevel(level);
        }
    }
}
