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
    public UI2DSprite CrystalSprite1won;
    public UI2DSprite CrystalSprite2won;
    public UI2DSprite CrystalSprite3won;
    protected virtual void OnRabitHit(HeroRabbit rabit)
    {
        hideAnimation = true;
        CollectedHide();
        rabit.crystalsCollected += 1;
        if (Crystal1)
        {
            CrystalSprite1.enabled = true;
            CrystalSprite1won.enabled = true;
        }
        if (Crystal2)
        {
            CrystalSprite2.enabled = true;
            CrystalSprite2won.enabled = true;
        }
        if (Crystal3)
        {
            CrystalSprite3.enabled = true;
            CrystalSprite3won.enabled = true;
        }
        
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
        CrystalSprite1won.enabled = false;
        CrystalSprite2won.enabled = false;
        CrystalSprite3won.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
