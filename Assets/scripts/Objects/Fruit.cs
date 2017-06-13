using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Collectable
{
    
   
    protected virtual void OnRabitHit(HeroRabbit rabit)
    {
        hideAnimation = true;
       
        CollectedHide();
        rabit.fruitCounter++;
        rabit.fruitsLabel.text = rabit.fruitCounter + "/12";
        rabit.fruitsLabelwon.text = rabit.fruitCounter + "/12";
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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
