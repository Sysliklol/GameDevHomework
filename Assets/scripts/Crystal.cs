using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Collectable
{
    public bool Crystal1 = false;
    public bool Crystal2 = false;
    public bool Crystal3 = false;
    public UI2DSprite CrystalSprite1;
    public UI2DSprite CrystalSprite2;
    public UI2DSprite CrystalSprite3;
    
    protected virtual void OnRabitHit(HeroRabbit rabit)
    {
        hideAnimation = true;
        CollectedHide();
        if (Crystal1) CrystalSprite1.enabled = true;
        if (Crystal2) CrystalSprite2.enabled = true;
        if (Crystal3) CrystalSprite3.enabled = true;
        
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
        CrystalSprite1.enabled = false;
        CrystalSprite2.enabled = false;
        CrystalSprite3.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
