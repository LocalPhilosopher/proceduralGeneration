using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    [HideInInspector]
    public Rigidbody2D rb2d;
    [HideInInspector]
    public Animator anim;
    [SerializeField]
    public float speed = 5.0f;
    [SerializeField]
    public Transform knifePos;
    [SerializeField]
    public int Lifes;
    [HideInInspector]
    public bool jump = true;
    public Transform GroundCheck;
    public bool isGrounded = false;
    [HideInInspector]
    public float hInput = 0;
    [HideInInspector]
    public bool facingRight;
    public CharState State
    {
        get { return (CharState)anim.GetInteger("State"); }
        set { anim.SetInteger("State", (int)value); }
    }
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isGrounded && hInput == 0 && rb2d.velocity.y == 0) State = CharState.Idle;
        if (Lifes == 0)
            Destroy(gameObject);
    }
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void Move(float horizontalInput)
    {
        Vector2 moveVel = rb2d.velocity;
        moveVel.x = horizontalInput * speed * Time.deltaTime;
        rb2d.velocity = moveVel;

        if (isGrounded && !jump && (hInput > 0 || hInput < 0)) State = CharState.Run;
    }
    public enum CharState
    {
        Idle,
        Run,
        Jump
    }
}
