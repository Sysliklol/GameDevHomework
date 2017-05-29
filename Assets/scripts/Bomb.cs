using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Collectable {

    protected virtual void OnRabitHit(HeroRabbit rabit)
    {
        hideAnimation = true;
        if (!rabit.isBigRabbit && rabit != null)
        {
            LevelController.current.onRabitDeath(rabit);
        }
        else
        {
            rabit.isBigRabbit = false;
        }
        CollectedHide();

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
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
