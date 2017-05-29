using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Collectable {
   
    protected virtual void OnRabitHit(HeroRabbit rabit)
    {
        
        hideAnimation = true;
        if (!rabit.isBigRabbit && rabit != null )
        {
            LevelController.current.onRabitDeath(rabit);
            CollectedHide();
        }
        else if (rabit.isBigRabbit && rabit != null)
        {
            rabit.isBigRabbit = false;
            CollectedHide();
            rabit.canHit = false;
            rabit.GetComponent<SpriteRenderer>().sprite = Resources.Load("pain_000", typeof(Sprite)) as Sprite;
        }
        

    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!this.hideAnimation)
        {
            
            if (rabit != null&& rabit.canHit)
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
