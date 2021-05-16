using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    #region Singelton
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    #endregion 


    private int index;

    public GameObject prefabBullet;
    public GameObject prefabLine;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {      }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }




    

    private void waitAndChangeScene()
    {
        SceneManager.LoadScene(index);
    }

    public void setScenes(int index, float time)
    {
        this.index = index;
        InvokeRepeating("waitAndChangeScene", time, 0);
    }

    public int getScenes()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }


    public void quitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            quitGame();
    }
}
