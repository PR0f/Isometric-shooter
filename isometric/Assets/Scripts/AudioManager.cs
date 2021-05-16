using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static float soundVolume, musicVolume;
    private GameObject muzyka, dzwiek;

    private void Start()
    {
        muzyka = transform.GetChild(0).gameObject;
        dzwiek = transform.GetChild(1).gameObject;

        if (dzwiek != null)
        {
            dzwiek.transform.GetChild(0).GetComponent<AudioSource>().volume = soundVolume;
            dzwiek.transform.GetChild(1).GetComponent<AudioSource>().volume = soundVolume;
        }
        if (muzyka != null)
            muzyka.GetComponent<AudioSource>().volume = musicVolume;
    }

    public void playSound()
    {
        if (dzwiek != null)
            dzwiek.GetComponent<AudioSource>().Play();
    }
}
