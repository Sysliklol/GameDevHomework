using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    Vector3 pointA;
    Vector3 pointB;
    public float vel = 9.0f;
    public float kek ;
    public float lol ;
    public float lolkek;
    float firstVel;
    public float MoveBy = 10.0f;
    Vector3 my_pos;
    public float time_to_wait = 10.0f;
    public float start_time_to_wait;
    public bool moving_top = false;
    


	// Use this for initialization
	void Start () {
        this.pointA = this.transform.position;
        if(moving_top)this.pointB.y = this.pointA.y + MoveBy;
        else this.pointB.x = this.pointA.x + MoveBy;
        firstVel = vel;
        start_time_to_wait = time_to_wait;
       
	}
	
	// Update is called once per frame
	void Update () {

        
        my_pos = this.transform.position;
        if (moving_top)
        {

            if (my_pos.y > pointB.y)
            {
                wait();
                vel *= -1;
          
            }
            else if ( my_pos.y < pointA.y)
            {
                wait();


            }
            transform.Translate(0, vel * Time.deltaTime, 0);
        }
        else
        {
            
            if (my_pos.x > pointB.x)
            {
                
                wait();
                vel *= -1;

            }
            else if (my_pos.x  < pointA.x)
            {
               wait();
            }

            transform.Translate(vel * Time.deltaTime,0, 0);
        }
        
    }
    void wait()
    {
      
        vel = 0;
        time_to_wait -= Time.deltaTime;
        if (time_to_wait <= 0)
        {
            vel = firstVel;
            time_to_wait = start_time_to_wait;
        }
    }

  


    
}