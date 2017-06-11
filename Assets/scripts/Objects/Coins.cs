using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Collectable {


   
   

    protected virtual void OnRabitHit(HeroRabbit rabit)
    {
        hideAnimation = true;

        CollectedHide();
        rabit.coinsCounter++;
        if (rabit.coinsCounter / 10 < 1) rabit.coinsLabel.text = "000" + rabit.coinsCounter.ToString();
        else if (rabit.coinsCounter / 100 < 1) rabit.coinsLabel.text = "00" + rabit.coinsCounter.ToString();
        else if (rabit.coinsCounter / 1000 < 1) rabit.coinsLabel.text = "0" + rabit.coinsCounter.ToString();
        else if (rabit.coinsCounter / 10000 < 1) rabit.coinsLabel.text = "" + rabit.coinsCounter.ToString();

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
    public void Start()
    {

       

    }
	
}
