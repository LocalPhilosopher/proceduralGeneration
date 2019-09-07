using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacter : MonoBehaviour
{
    [SerializeField]
    [Range(1, 100)]
    private float JumpVelocity;
    [HideInInspector]
    public bool jump = true;
    bool facingRight = true;
    public bool mbJump = false;
    public bool mbAttack = false;
    public float slopeFriction=1f;
    public float damage = 5f;

    public GameObject blood;


    [SerializeField]
    private Transform[] groundCheck;
    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsPlatform;

    public float maxSpeed = 5.0f;
    public float timeZeroMax = 2.5f;
    float accelRatePerSec;
    public float forwardVelocity;

    public Vector2 Velocity;
    public Transform GroundCheck;
    public bool isGrounded = false;
    public float fallVelocity;
    float hInput = 0;

    public float knockbackX;
    public float knockbackY;
    public float knockbackLenght;
    public float knockbackCount;
    public bool knockFromRight;


    private CharState State
    {
        get { return (CharState)anim.GetInteger("State"); }
        set { anim.SetInteger("State", (int)value); }
    }

    public Vector3 MoveDirection;
    public CharacterController charController;
    private Rigidbody2D rb2d;
    private Animator anim;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        accelRatePerSec = maxSpeed / timeZeroMax;
        forwardVelocity = 0f;
    }
    

    private bool IsPlatformed()
    {
        if (rb2d.velocity.y <= 0f)
        {
            foreach (Transform point in groundCheck)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsPlatform);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    private bool IsGrounded()
    {
        if (rb2d.velocity.y ==0f)
        {
            foreach (Transform point in groundCheck)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsPlatform);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        if (rb2d.velocity.y <= 0f || rb2d.velocity.y >= 0f)
            foreach (Transform point in groundCheck)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    return true;
                }
            }
        }
        return false;
    }
    private void Update()
    {
        
        if (HealthBarScript.health<=0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Castle");
        }
        if (hInput == 0) forwardVelocity = 0f;
        if (hInput == 0 && isGrounded && !mbAttack) State = CharState.Idle;
        if (mbAttack) State = CharState.Attack;
        if (isGrounded && (Input.GetButtonDown("Jump") || mbJump))
        {
            jump = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log(rb2d.velocity.y);
        }
        if (knockbackCount <= 0)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);

        }
        else 
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            State = CharState.Hit;
            if (knockFromRight) rb2d.velocity = new Vector2(-knockbackX, knockbackY);
        
            if (!knockFromRight) rb2d.velocity = new Vector2(knockbackX, knockbackY);

            knockbackCount -= Time.deltaTime;
        }
    }


    private void FixedUpdate()
    {
        isGrounded = IsGrounded();
        if (hInput > 0 && !facingRight)
            Flip();
        else if (hInput < 0 && facingRight)
            Flip();
        if (rb2d.velocity.y != 0f && !isGrounded) State = CharState.Jump;
        if (jump)
        {
            rb2d.velocity = Vector2.up * JumpVelocity;
            jump = false;
            mbJump = false;
        }
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        Move(hInput);
    }

    void Move(float horizontalInput)
    {
        if (knockbackCount <= 0)
        {
            forwardVelocity += accelRatePerSec * Time.deltaTime;
            forwardVelocity = Mathf.Min(forwardVelocity, maxSpeed);
            Vector2 moveVel = rb2d.velocity;
            moveVel.x = horizontalInput * forwardVelocity;
            rb2d.velocity = moveVel;
            if (isGrounded && (hInput > 0 || hInput < 0)) State = CharState.Run;
        }
    }

    public void StartMoving(float horizontalInput)
    {
        hInput = horizontalInput;
    }

    public void Attack()
    {
        mbAttack = true;
    }
    public void Jump()
    {
        if (isGrounded)
            mbJump = true;
    }
    public void UnJump()
    {
        mbJump = false;
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void NormalizeSlope()
    {
        // Attempt vertical normalization
        if (isGrounded)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1f, whatIsGround);

            if (hit.collider != null && Mathf.Abs(hit.normal.x) > 0.1f)
            {
                // Apply the opposite force against the slope force 
                // You will need to provide your own slopeFriction to stabalize movement
                rb2d.velocity = new Vector2(rb2d.velocity.x - (hit.normal.x * slopeFriction), rb2d.velocity.y);

                //Move Player up or down to compensate for the slope below them
                Vector3 pos = transform.position;
                pos.y += -hit.normal.x * Mathf.Abs(rb2d.velocity.x) * Time.fixedDeltaTime * (rb2d.velocity.x - hit.normal.x > 0 ? 1 : -1);
                transform.position = pos;
            }
        }

    }
}

public enum CharState
{
    Idle,
    Run,
    Jump,
    Attack,
    Hit
}