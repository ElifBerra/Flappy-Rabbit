using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbit : MonoBehaviour
{

    Rigidbody2D _rb;
    [SerializeField]
    private float _speed;
    int angle;
    int maxAngle = 20;
    int minAngle = -60;
    public Score score;
    bool touchedGround;

    public GameManager gameManager;
    public Sprite rabbitDied; 
    SpriteRenderer sp;
    Animator anim;

    public pipespawner pipespawner;
    [SerializeField] private AudioSource wing,point,die;


    // Start is called before the first frame update
    void Start()
    {
        
        _rb = GetComponent<Rigidbody2D>(); 
        _rb.gravityScale = 0;
        //_rbgravityScale = -1 (...) ; kullanarak yerçekimi ayarlayabilirim.
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RabbitJump();
    }

    private void FixedUpdate()
    {
        RabbitRotation();
    }

    void RabbitJump()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            wing.Play();
            if(GameManager.gameStarted == false)
            {
                _rb.gravityScale = 2f;
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
                pipespawner.InstantiatePipe();
                gameManager.GameHasStarted();
            }
            else
            {
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x,_speed);
            }
          
        }

    }

    void RabbitRotation()
    {
        if (_rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (_rb.velocity.y < -1.2)
        {
            if(angle > minAngle)
            {
                angle = angle - 2;
            }
        }

        if(touchedGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("pipe"))
        {
          //Debug.Log("Scored!..");
          score.Scored();
          point.Play();
        }
        else if(collision.CompareTag("column") && GameManager.gameOver == false)
        {
            // game over
            FishDieEffect();
            gameManager.GameOver();
        }
    }

    void FishDieEffect()
    {
        die.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("base"))
        {
            if(GameManager.gameOver == false)
            {
                //game over
                FishDieEffect();
                gameManager.GameOver();
                GameOver();
            }
            else
            {
                //game over(rabbit)
                GameOver();
            }
        }
    }

    void GameOver()
    {
        touchedGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sp.sprite = rabbitDied;
        anim.enabled = false;
    }


}
