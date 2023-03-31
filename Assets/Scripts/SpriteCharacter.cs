using System.Collections;
using UnityEngine;

public class SpriteCharacter : MonoBehaviour
{
    public float hoz;
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

    public Rigidbody2D body;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    Animator animate;
    public AudioController controller;
    TrailRenderer trail;

    void Awake()
    {
        trail = GetComponent<TrailRenderer>();
        trail.enabled = false;
        animate = GetComponent<Animator>();
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
        // if player on ground and hgasnt jumped = no double jump
        if(grounded && !Input.GetButton("Jump"))
        {
            dJump = false;
        }

        //player jumps
        if (Input.GetButtonDown("Jump"))
        {
            //player is either on ground or mid air able to double jump
            if((grounded || dJump))
            {
                animate.SetBool("Grounded", false);
                body.velocity = new Vector2(body.velocity.x, dJump ? dJumpPower: jump); //applies jump force depending on if its double jump or not
                dJump = !dJump;
                if(!isCooldownJump)
                {
                    controller.Boombox("Jump");
                    StartCoroutine(JumpCooldown(cooldownTime));
                }
            }
        }

        // way of slowing player as jump continues
        if (Input.GetButtonUp("Jump") && body.velocity.y > 0f)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * 0.6f);
        }

        //plays walk sound
        if(!isCooldownWalk && grounded && (Input.GetKey(KeyCode.A)  || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
        {
            controller.Boombox("Walk");
            StartCoroutine(WalkCooldown());
        }

        //for speed boost 
        if(speed > 25)
        {
            trail.enabled = true;
            StartCoroutine(BuffCooldown());
        }

    }

    public void FixedUpdate()
    {
        if (knockCount <= 0)
        {
            //regular ewalking 
            body.velocity = new Vector2(hoz * speed, body.velocity.y);
        }
        else
        {
            //knocking the player back if enemy hits them by some units
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
        hoz = Input.GetAxisRaw("Horizontal"); //wasd + arrow keys
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.8f, groundLayer);
        animate.SetBool("Grounded", grounded); //used for jump animation 
        animate.SetFloat("speed", Mathf.Abs(hoz)); //used for walk animation 
        if (hoz > 0 && !isRight)
        {
            Flip();
        }
        if(hoz < 0 && isRight)
        {
            Flip();
        }
    }

    //flips player so faces right direction 
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        isRight = !isRight;
    }

    //cooldowns for different contexts
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
        trail.enabled = false;
    }

}
