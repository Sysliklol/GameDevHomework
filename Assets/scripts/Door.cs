using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour {

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
	
}
