using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private GameObject options;
    private GameObject soundSlider;
    private GameObject musicSlider;

    void Start()
    {
        soundSlider = GameObject.Find("soundSlider");
        musicSlider = GameObject.Find("musicSlider");

        AudioManager.soundVolume = 0.6f;
        AudioManager.musicVolume = 0.1f;

      options = GameObject.Find("Options");
        if (options != null)
            options.SetActive(false);

        
    }

    public void startGame()
    {
        GameManager.Instance.setScenes(1,0);
        if (musicSlider != null)
            AudioManager.soundVolume = soundSlider.GetComponent<Slider>().value;
        if (soundSlider != null)
            AudioManager.musicVolume = musicSlider.GetComponent<Slider>().value;
    }

    public void exitGame()
    {
        GameManager.Instance.quitGame();
    }

    public void optionGame(bool isActive)
    {
        if(options!=null)
            options.SetActive(isActive);
    }

    public void backToMenu()
    {
        GameManager.Instance.setScenes(0,0);
    }
}
