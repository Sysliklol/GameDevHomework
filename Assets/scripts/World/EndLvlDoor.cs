using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndLvlDoor : MonoBehaviour
{

    public UI2DSprite Won;
    public AudioClip wonSound = null;
    AudioSource wonSource = null;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (SoundManager.Instance.isSoundOn()) wonSource.Play();
       // LevelStat.Instance.read();
        PlayerPrefs.SetInt("completed", 1);
        Won.enabled= true;
        if (HeroRabbit.lastRabit.crystalsCollected > 2)
        {
          //  LevelStat.Instance.hasCrystals = true;
            PlayerPrefs.SetInt("crystals", 1);
        }
        if (HeroRabbit.lastRabit.fruitCounter > 11)
        {
            PlayerPrefs.SetInt("fruits", 1);
        }
       // LevelStat.Instance.save();
        PlayerPrefs.Save();
    }

    void Start()
    {


        wonSource = gameObject.AddComponent<AudioSource>();
        wonSource.clip = wonSound;
    }

}