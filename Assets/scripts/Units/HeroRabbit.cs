using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HeroRabbit : MonoBehaviour {
    
    public AudioClip music = null;
    AudioSource musicSource = null;

    public Animator animator;
    public float speed = 1;
    public bool isGrounded = true;
    
    internal Rigidbody2D myBody = null;
    
    bool JumpActive = false;

    public float JumpTime = 0f;
    public float MaxJumpTime = 2f;
    public float JumpSpeed = 2f;
    Transform heroParent = null;
    
    public bool isBigRabbit = false;
    bool grew = false;
    public float time_to_wait = 1.0f;
    public bool canHit = true;
    
    public float start_time_to_wait;
    
    public static HeroRabbit lastRabit = null;
    
    public float numberOfLives = 3f;
    
    public UI2DSprite live1;
    public UI2DSprite live2;
    public UI2DSprite live3;

    public UILabel fruitsLabel;
    public UILabel fruitsLabelwon;
    public UILabel coinsLabel;
    public float fruitCounter = 0f;
    public float coinsCounter = 0f;

    public bool inMenu = false;
    public bool inChoosing = false;

    public double crystalsCollected = 0;
    
    public UI2DSprite lost;
    public AudioClip lostSound = null;
    AudioSource lostSource = null;


    public AudioClip move = null;
    AudioSource moveSource = null;
    public AudioClip groundedSound = null;
    AudioSource groundedSource = null;

    public AudioClip attackSound1 = null;
    public AudioSource attackSource1 = null;

    public AudioClip respawn = null;
    public AudioSource respawnSource = null;
    
    void Awake()
    {
        lastRabit = this;
    }
	// Use this for initialization
	void Start () {
        LevelStat.Instance.read();
        myBody = this.GetComponent<Rigidbody2D>();
        if(!inMenu&&!inChoosing)LevelController.current.setStartPosition(transform.position);
        this.heroParent = this.transform.parent;
        start_time_to_wait = time_to_wait;
        fruitsLabel.text = fruitCounter + "/12";
        fruitsLabelwon.text = fruitCounter + "/12";
        if (coinsCounter / 10 < 1) coinsLabel.text = "000" + coinsCounter.ToString();
        else if (coinsCounter / 100 < 1) coinsLabel.text = "00" + coinsCounter.ToString();
        else if (coinsCounter / 1000 < 1)coinsLabel.text = "0" + coinsCounter.ToString();
        else if (coinsCounter / 10000 < 1) coinsLabel.text = "" + coinsCounter.ToString();
        lostSource = gameObject.AddComponent<AudioSource>();
        lostSource.clip = lostSound;


        groundedSource = gameObject.AddComponent<AudioSource>();
        groundedSource.clip = groundedSound;

        moveSource = gameObject.AddComponent<AudioSource>();
        moveSource.clip = move;
        if (SoundManager.Instance.isSoundOn()) moveSource.Play();
        moveSource.loop = true;

        attackSource1 = gameObject.AddComponent<AudioSource>();
        attackSource1.clip = attackSound1;

        respawnSource = gameObject.AddComponent<AudioSource>();
        respawnSource.clip = respawn;
	}
	
	// Update is called once per frame
	void Update () {
       
        if (isBigRabbit&&!grew)
        {
            transform.localScale += new Vector3(0.3F, 0.3F, 0);
            grew = true;
        }
        else if (!isBigRabbit && grew)
        {
            transform.localScale -= new Vector3(0.3F, 0.3F, 0);
            grew = false;
           
 
            

        }
        if (numberOfLives == 3f) { live3.enabled = true; }
        else if (numberOfLives == 2f) { live3.enabled = false; live2.enabled = true; }
        else if (numberOfLives == 1f) { live2.enabled = false; live1.enabled = true; }
        else if (numberOfLives == 0f) { lostT(); lost.enabled = true; }
        if (!canHit) wait();

        
	}
    void lostT()
    {
        if (SoundManager.Instance.isSoundOn()) lostSource.Play();
    }
    void FixedUpdate(){
        float value = Input.GetAxis("Horizontal");
        animator = GetComponent<Animator>();
        if (Mathf.Abs(value) > 0)
        {
            Vector2 vel = myBody.velocity;
            vel.x = value * speed;
            myBody.velocity = vel;
        }

        if (Mathf.Abs(value) > 0)
        {
            if (SoundManager.Instance.isSoundOn()) moveSource.UnPause();
            animator.SetBool("Run", true);
        }
        else
        {
            moveSource.Pause();
            animator.SetBool("Run", false);
        }
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (!inMenu)
        {
            if (value < 0)
            {
                sr.flipX = true;
            }
            else if (value > 0)
            {
                sr.flipX = false;
            }
        }
        Vector3 from = transform.position + Vector3.up * 0.3f;
        Vector3 to = transform.position + Vector3.down * 0.1f;
        int layer_id = 1 << LayerMask.NameToLayer("Ground");
        RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
        if (hit)
        {
            //Перевіряємо чи ми опинились на платформі
            if (hit.transform != null
            && hit.transform.GetComponent<MovingPlatform>() != null)
            {
                //Приліпаємо до платформи
                SetNewParent(this.transform, hit.transform);
                if (SoundManager.Instance.isSoundOn()) groundedSource.Play();
            }
        }
        else
        {
            //Ми в повітрі відліпаємо під платформи
            SetNewParent(this.transform, this.heroParent);
        }
        
        if (hit)
        {
            
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            moveSource.Pause();
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            this.JumpActive = true;
        }
        if (this.JumpActive)
        {
           if (Input.GetButton("Jump"))
            {
                this.JumpTime += Time.deltaTime;
                if (this.JumpTime < this.MaxJumpTime)
                {
                    Vector2 vel = myBody.velocity;
                    vel.y = JumpSpeed * (1.0f - JumpTime / MaxJumpTime);
                    myBody.velocity = vel;
                }
            }
            else
            {
               
                this.JumpActive = false;
                this.JumpTime = 0;
            }
        }

        
        if (this.isGrounded)
        {
            animator.SetBool("Jump", false);
        }
        else
        { 
            animator.SetBool("Jump", true);
        }
        Debug.DrawLine(from, to, Color.red);

    }
    static void SetNewParent(Transform obj, Transform new_parent)
    {
        if (obj.transform.parent != new_parent)
        {
            //Засікаємо позицію у Глобальних координатах
            Vector3 pos = obj.transform.position;
            //Встановлюємо нового батька
            obj.transform.parent = new_parent;
            //Після зміни батька координати кролика зміняться
            //Оскільки вони тепер відносно іншого об’єкта
            //повертаємо кролика в ті самі глобальні координати
            obj.transform.position = pos;
        }
    }
    public void wait()
    {
        time_to_wait -= Time.deltaTime;
        if (time_to_wait <= 0)
        {
            canHit = true;
            time_to_wait = start_time_to_wait;
        }
    }
    
    

}
