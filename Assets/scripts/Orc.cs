using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour
{
    Vector3 my_pos;
    Vector3 pointA;
    Vector3 pointB;
    float firstVel;
    public float kek;
    public float Bx;
    public float Ax;
    public float orcX;
    public float vel = 9.0f;
    public float MoveBy = 10.0f;
    float value = 1;
    bool going_for_rabit = false;
    bool dying = false;
    // Use this for initialization
    void Start()
    {
        this.pointA = this.transform.position;
        this.pointB.x = this.pointA.x + MoveBy;
        firstVel = vel;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (!dying)
        {
            Vector3 rabit_pos = HeroRabbit.lastRabit.transform.position;
            Ax = rabit_pos.y;

            orcX = this.transform.position.y;
            getDirection();
            transform.Translate(vel * Time.deltaTime, 0, 0);
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (vel > 0)
            {
                sr.flipX = true;
            }
            else if (vel < 0)
            {
                sr.flipX = false;
            }
        }
    }
    void getDirection() {
        
        Bx = value;
        Vector3 rabit_pos = HeroRabbit.lastRabit.transform.position;
        my_pos = this.transform.position;
        going_for_rabit = false;
        if (rabit_pos.x > pointA.x && rabit_pos.x < this.transform.position.x && value > 0 && rabit_pos.y < this.transform.position.y + 0.85)
        {
            vel *= -1;
            value = -1;
           
        }
        else if (rabit_pos.x < pointB.x && rabit_pos.x > this.transform.position.x && value < 0 && rabit_pos.y < this.transform.position.y + 0.85)
        {
            vel *= -1;
            value = 1;
            
        }
        else if(my_pos.x > pointB.x&&!going_for_rabit) {
        vel*=-1; //Move left
        value = -1;
        }
        else if (my_pos.x < pointA.x&&!going_for_rabit)
        {
            vel *=-1; //Move right
            value = 1;
        }
       
}

    public bool hideAnimation = false;
    protected virtual void OnRabitHit(HeroRabbit rabit)
    {
        Animator animator = GetComponent<Animator>();
        //hideAnimation = true;
        if (rabit.transform.position.y > this.transform.position.y + 1.05)
        {
            dying = true;
            animator.SetTrigger("die");
            animator.SetBool("Run", false);
            Destroy(this.GetComponent<Rigidbody2D>());
            Destroy(this.GetComponent<BoxCollider2D>());
            StartCoroutine(dielater(0.65f));
        }
        else
        {
            animator.SetTrigger("attack");
            StartCoroutine(dielater(1.0f,rabit));
           
        }

    }
    IEnumerator dielater(float duration, HeroRabbit rabit)
    {
        //Perform action ...
        //Wait

        vel = 0;
        rabit.animator.SetTrigger("Die");
        yield return new WaitForSeconds(duration);
        //Continue excution in few seconds
        //Other actions...
       
        LevelController.current.onRabitDeath(rabit);
        vel = firstVel;
    }
    IEnumerator dielater(float duration)
    {
        //Perform action ...
        //Wait
        yield return new WaitForSeconds(duration);
        //Continue excution in few seconds
        //Other actions...
        OgreIsDead();
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

    public void OgreIsDead()
    {
        Destroy(this.gameObject);
    }
}
