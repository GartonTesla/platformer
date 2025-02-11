using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // это параметры для движения
    public float _speed;
    public float _jumpForce;
    public float _jumpTime;
    private Vector2 move;
    private Rigidbody2D rb;
    private Vector3 _input;
    private Animator animator;
    private string currentAnim = "";
    private PlayerAttack playerAttack;

    //параметры для проверки чтоит ли игрок на земле
    public Transform feetPosition;
    public LayerMask isGround;
    public bool isGrounded;
    public float checkRadius;

    //вспомогательные параметры
    private Rigidbody2D playerRB;
    private float inputX;
    private float inputY;
    private float jumpTimeCounter;
    [SerializeField] private bool jumping;
    [SerializeField] private Animator anim;
    [SerializeField] private bool flip;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool isAnimActive;
    [SerializeField] private float checkDisDown;
    void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        ChangeAnimation("Idle");
        CheckAnimation();
    }

    private void CheckAnimation()
    {
        if (playerAttack.flag == true && currentAnim == "Attack")
        {
            return;
        }
        if (currentAnim == "Jump" && jumping == true) 
        {
            return;
        }
        if (_input.x != 0)
        {
            ChangeAnimation("Run");
        }
        else
        {
            ChangeAnimation("Idle");
        }
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(transform.localPosition, transform.TransformDirection(Vector2.down), checkDisDown);
            Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - checkDisDown, transform.position.z), Color.red);
            foreach (var hited in hit)
            {
                if (hited.collider.tag == "Ground")
                {
                    if (!jumping)
                    {
                        Jump();
                    }
                }
            }

        }
        CheckAnimation();
    }

    void FixedUpdate()
    {
        walk();
    }
    void walk()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), 0);
        anim.SetFloat("Run", Mathf.Abs(_input.x));
        transform.position += _input * _speed * Time.deltaTime;
        if (_input.x > 0)
        {
            flip = false;
            spriteRenderer.flipX = flip;
        }
        else if (_input.x < 0)
        {
            flip = true;
            spriteRenderer.flipX = flip;
        }
    }
    void Jump()
    {
        if (jumping == false)
        {
            rb.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
            jumping = true;
            ChangeAnimation("Jump");
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            jumping = false;
        //    anim.SetBool("Jump", jumping);
         //   isAnimActive = false;
        }
    }
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    jumping = true;
    // //   StartCoroutine(JumpingCD());
    //}
    public void ChangeAnimation(string anim, float crossFade = 0.1f)
    {
        if (anim != currentAnim)
        {
            currentAnim = anim;
            animator.CrossFade(anim, crossFade);
        }
    }
    //private IEnumerator JumpingCD()
    //{
    //    yield return new WaitForSeconds(1f);
    //    jumping = false;
    //}
}
