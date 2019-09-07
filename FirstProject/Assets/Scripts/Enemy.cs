using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform Player;
    public float Attack_range;
    public float Chase_range;
    public float Distance;
    public float health = 12f;

    public float stoppingDistance;
    private Rigidbody2D rb2d;
    public float speed = 5.0f;
    private bool facingRight;
    public float hInput = 0;
    public bool doItAttack;
    public bool anime;
    public float knockbackX = 20f;
    public float knockbackY;
    public float knockbackLenght = 0.2f;
    public float knockbackCount;
    public bool knockFromRight;
    public bool damageTake;


    private Animator anim;

    private CharState State
    {
        get { return (CharState)anim.GetInteger("State"); }
        set { anim.SetInteger("State", (int)value); }
    }

    private void Awake()
    {
        anime = false;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Distance = (Player.transform.position.x - transform.position.x);

        if (Distance > 0) hInput = 1;
        if (Distance < 0) hInput = -1;
        if (Mathf.Abs(Distance) <= Attack_range) doItAttack = true;
        if (anime)
        {
            doItAttack = false;
            if (doItAttack == false) anime = false;
        }
        if (damageTake) State = CharState.Hit;
        if (doItAttack && !damageTake)
        {
            hInput = 0;
            State = CharState.Attack;
        }
        if (hInput != 0 && !damageTake)
        {
            State = CharState.Run;
        }
        if (Distance <= Chase_range && Distance > Attack_range)
        {
            //Vector2 Direction = Player.position - transform.position;
            //Direction.y = 0;


        }

        if (knockbackCount <= 0)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);
            damageTake = false;

        }
        else
        {
            if (knockFromRight) rb2d.velocity = new Vector2(-knockbackX, knockbackY);

            if (!knockFromRight) rb2d.velocity = new Vector2(knockbackX, knockbackY);

            knockbackCount -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("damage TAKEN" + health);
            damageTake = true;
            
            health = health - 5f;
            knockbackCount = knockbackLenght;
            if (other.transform.position.x < transform.position.x) knockFromRight = true;
            else knockFromRight = false;
        }
    }

    void FixedUpdate()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (hInput > 0 && facingRight && !!anime)
            Flip();
        else if (hInput < 0 && !facingRight && !anime)
            Flip();
        Move(hInput);
    }
    void Move(float hInput)
    {
        Vector2 moveVel = rb2d.velocity;
        moveVel.x = hInput * speed;
        rb2d.velocity = moveVel;

    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public enum CharState
    {
        Idle,
        Run,
        Attack,
        Hit
    }
}
