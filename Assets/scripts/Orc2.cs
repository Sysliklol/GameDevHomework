using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc2 : MonoBehaviour
{
    Animator animator;
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
    float last_carrot = 0;
    bool still = false;
    public GameObject prefabCarrot;
    void launchCarrot()
    {
        //Створюємо копію Prefab
        GameObject obj = GameObject.Instantiate(this.prefabCarrot);
        //Розміщуємо в просторі
      //  obj.transform.position = this.transform.position;
        Vector3 pos_car = this.transform.position;
        pos_car.y += 0.6f;
        obj.transform.position = pos_car;
        //Запускаємо в рух
        Carrot carrot = obj.GetComponent<Carrot>();
        
    }

    // Use this for initialization
    void Start()
    {
        this.pointA = this.transform.position;
        this.pointB.x = this.pointA.x + MoveBy;
        firstVel = vel;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vel == 0)
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Idle", true);

        }
        else
        {
            animator.SetBool("Walk", true);
            animator.SetBool("Idle", false);
        }
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
    void getDirection()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Bx = value;
        Vector3 rabit_pos = HeroRabbit.lastRabit.transform.position;
        my_pos = this.transform.position;
        going_for_rabit = false;
        if (Mathf.Abs(rabit_pos.x - this.transform.position.x) < 5.0f) kek = 1;
        else kek = 0;
        if (kek==1)
        {

            if (rabit_pos.x < this.transform.position.x&&value==1)
            {

                sr.flipX = false;
            }
            else
            {
                

            }
            
            //check launch time
            if (Time.time - last_carrot > 2.0f)
            {
                animator.SetTrigger("Attack");
                launchCarrot();
                last_carrot = Time.time;
            }
            if (!still)
            {
                StartCoroutine(movelater(1.0f));
            }
            
        }
        else if (rabit_pos.x > pointA.x && rabit_pos.x < this.transform.position.x && value > 0 && rabit_pos.y < this.transform.position.y + 0.85)
        {
            vel = firstVel; 
            vel *= -1;
            value = -1;
            
        }
        else if (rabit_pos.x < pointB.x && rabit_pos.x > this.transform.position.x && value < 0 && rabit_pos.y < this.transform.position.y + 0.85)
        {
            vel = firstVel; 
            value = 1;
            
        }
        else if (my_pos.x > pointB.x && !going_for_rabit)
        {
            vel = firstVel; 
            vel *= -1; //Move left
            value = -1;
        }
        else if (my_pos.x < pointA.x && !going_for_rabit)
        {
            vel = firstVel; 
           //Move right
            value = 1;
        }
        
    }
     IEnumerator movelater(float duration)
    {
        //Perform action ...
        //Wait

        vel = 0;
        still = true;
        yield return new WaitForSeconds(duration);
        //Continue excution in few seconds
        //Other actions...

        still = false;
        vel = firstVel;
    }
    public bool hideAnimation = false;
    protected virtual void OnRabitHit(HeroRabbit rabit)
    {
        animator = GetComponent<Animator>();
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
            StartCoroutine(dielater(1.0f, rabit));

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
