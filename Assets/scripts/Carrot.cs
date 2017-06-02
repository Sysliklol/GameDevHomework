﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour {
    public float vel = 3.0f;
    float launched;
	// Use this for initialization
	void Start () {
        launch();
        launched = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(vel * Time.deltaTime, 0, 0);
        if (Time.time - launched > 2.0f)
        {
            hideAnimation = true;
            Destroy(this.gameObject);
        }
	}

    public bool hideAnimation = false;
    protected virtual void OnRabitHit(HeroRabbit rabit)
    {
        hideAnimation = true;
        StartCoroutine(dielater(1.0f, rabit));
        CollectedHide();
    }

    IEnumerator dielater(float duration, HeroRabbit rabit)
    {
        //Perform action ...
        //Wait

       
        rabit.animator.SetTrigger("Die");
        yield return new WaitForSeconds(duration);
        //Continue excution in few seconds
        //Other actions...

        LevelController.current.onRabitDeath(rabit);
       
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!this.hideAnimation)
        {
            HeroRabbit rabit = collider.GetComponent<HeroRabbit>();
            if (rabit != null)
            {
                this.OnRabitHit(rabit);
            }
        }
    }

    public void CollectedHide()
    {
        Destroy(this.gameObject);
    }


    public void wait()
    {



    }

    public void launch()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 rabit_pos = HeroRabbit.lastRabit.transform.position;
        if (rabit_pos.x < this.transform.position.x)
        {
            vel *= -1;
            sr.flipX = true;
           
        }
        else
        {

        }


    }
}
