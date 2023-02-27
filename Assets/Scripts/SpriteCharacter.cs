using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCharacter : MonoBehaviour
{
    private float hoz;
    public float speed = 25f;
    public float jump = 40f;
    private bool isRight = true;
    private bool dJump;
    private float dJumpPower = 30f;
    public float knockForce;
    public float knockCount;
    public float knockTime;
    public bool knockRight;
    public float cooldownTime = 3f;
    public bool isCooldownJump, isCooldownWalk, isCooldownBuff;
    bool grounded = false;

    [SerializeField] private Rigidbody2D body;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    Transform playerRender;
    Animator animate;
    AudioController controller;

    void Awake()
    {
        animate = GetComponent<Animator>();
        playerRender = transform.Find("PlayerRenderer");
    }

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        controller = AudioController.controller;
        if(controller == null)
        {
            Debug.LogError("ahhhhhhhhhhhh");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(grounded && !Input.GetButton("Jump"))
        {
            dJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if((grounded || dJump))
            {
                animate.SetBool("Grounded", false);
                //controller.Boombox("Jump");
                body.velocity = new Vector2(body.velocity.x, dJump ? dJumpPower: jump);
                dJump = !dJump;
                if(!isCooldownJump)
                {
                    controller.Boombox("Jump");
                    StartCoroutine(JumpCooldown(cooldownTime));
                }
            }
        }

        if (Input.GetButtonUp("Jump") && body.velocity.y > 0f)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * 0.6f);
        }

        if(!isCooldownWalk && grounded && (Input.GetKey(KeyCode.A)  || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
        {
            controller.Boombox("Walk");
            StartCoroutine(WalkCooldown());

        }

        if(speed > 25)
        {
            StartCoroutine(BuffCooldown());
        }
    }

    private void FixedUpdate()
    {
        if (knockCount <= 0)
        {
            body.velocity = new Vector2(hoz * speed, body.velocity.y);

        }
        else
        {
            if (knockRight == true)
            {
                body.velocity = new Vector2(-knockForce + 5, knockForce/2);
            }
            if (knockRight == false)
            {
                body.velocity = new Vector2(knockForce + 5, knockForce/2);
            }

            knockCount -= Time.deltaTime;
        }
        hoz = Input.GetAxisRaw("Horizontal");
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        animate.SetBool("Grounded", grounded);
        animate.SetFloat("speed", Mathf.Abs(hoz));
        if (hoz > 0 && !isRight)
        {
            Flip();

        }
        if(hoz < 0 && isRight)
        {
            Flip();
        }

    }

    //private bool IsGrounded()
    //{
    //    return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    //}

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        isRight = !isRight;
    }

    IEnumerator JumpCooldown(float cooldownTime)
    {
        isCooldownJump = true;
        yield return new WaitForSeconds(cooldownTime);
        isCooldownJump = false;
    }

    IEnumerator WalkCooldown()
    {
        isCooldownWalk = true;
        yield return new WaitForSeconds(0.7f);
        isCooldownWalk = false;
    }
    
    IEnumerator BuffCooldown()
    {
        yield return new WaitForSeconds(5);
        speed = 25;
    }

}
