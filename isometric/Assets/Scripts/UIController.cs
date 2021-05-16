using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    static GameObject health, energy, score;
    static int _points;

    void Start()
    {
        health = GameObject.Find("Health");
        energy = GameObject.Find("Energy");
        score = GameObject.Find("Score");

        health.GetComponent<RectTransform>().sizeDelta = new Vector2(175, 26);
        energy.GetComponent<RectTransform>().sizeDelta = new Vector2(175, 26);
        score.GetComponent<Text>().text = "Score: 0";
        _points = 0;
    }


    static public void setHealth(float procent)
    {
        if (procent <= 0)
            procent = 0;
        else if (procent > 100)
            procent = 100;
        float x = procent * 1.75f;
        health.GetComponent<RectTransform>().sizeDelta = new Vector2(x, 26);
    }

    static public void setEnergy(float procent)
    {
        if (procent <= 0)
            procent = 0;
        else if (procent > 100)
            procent = 100;
        float x = procent * 1.75f;
        energy.GetComponent<RectTransform>().sizeDelta = new Vector2(x, 26);
    }

    static public float getHealth()
    {
        float x = health.GetComponent<RectTransform>().sizeDelta.x / 1.75f;
        return x;
    }

    static public float getEnergy()
    {
        float x = energy.GetComponent<RectTransform>().sizeDelta.x / 1.75f;
        return x;
    }

    static public void addScore(int points)
    {
        _points += points;
        score.GetComponent<Text>().text = "Score: "+ _points.ToString();

        if (_points == 110)
            GameManager.Instance.setScenes(2, 1);
    }
}
