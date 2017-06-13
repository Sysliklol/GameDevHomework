using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{

    public SpriteRenderer crystals;
    public SpriteRenderer fruits;
    public SpriteRenderer completed;
    

    protected virtual void OnRabitHit(HeroRabbit rabit)
    {



    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        SceneManager.LoadScene("scene1");
        HeroRabbit rabit = collider.GetComponent<HeroRabbit>();
        if (rabit != null)
        {
            this.OnRabitHit(rabit);
        }

    }

    void Start()
    {

        crystals.enabled = false;
        fruits.enabled = false;
        completed.enabled = false;
        if (PlayerPrefs.GetInt("crystals", 0) == 1)
        {
            crystals.enabled = true;
        }

        if (PlayerPrefs.GetInt("fruits", 0) == 1)
        {
            fruits.enabled = true;
        }

        if (PlayerPrefs.GetInt("completed", 0) == 1)
        {
            completed.enabled = true;
        }
    }
}
