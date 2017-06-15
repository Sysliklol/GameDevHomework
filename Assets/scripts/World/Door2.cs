using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door2 : MonoBehaviour {

    public SpriteRenderer crystals;
    public SpriteRenderer fruits;
    public SpriteRenderer completed;


    protected virtual void OnRabitHit(HeroRabbit rabit)
    {



    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (PlayerPrefs.GetInt("completed", 0) == 1) SceneManager.LoadScene("scene2");
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
        if (PlayerPrefs.GetInt("crystals2", 0) == 1)
        {
            crystals.enabled = true;
        }

        if (PlayerPrefs.GetInt("fruits2", 0) == 1)
        {
            fruits.enabled = true;
        }

        if (PlayerPrefs.GetInt("completed2", 0) == 1)
        {
            completed.enabled = true;
        }
    }
}
