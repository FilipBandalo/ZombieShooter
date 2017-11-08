using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float runSpeed;
    public float walkSpeed;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpPower;

    private bool facingRight = true;
    private bool isGrounded = false;
    private float groundCheckRadius = 0.2f;

    Collider[] groundCollision;
    Rigidbody _rigidbody;
    Animator _animator;
 


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if(isGrounded && Input.GetAxis("Jump") > 0)
        {
            Jump();
        }

        groundCollision = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if(groundCollision.Length > 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        _animator.SetBool("isGrounded", isGrounded);

        float move = Input.GetAxis("Horizontal");
        _animator.SetFloat("speed", Mathf.Abs(move));


        float sneaking = Input.GetAxisRaw("Fire3");
        _animator.SetFloat("sneaking", sneaking);

        float firing = Input.GetAxis("Fire1");
        _animator.SetFloat("shooting", firing);


        if ((sneaking > 0 || firing > 0) && isGrounded)
        {
            _rigidbody.velocity = new Vector3(move * walkSpeed, _rigidbody.velocity.y, 0);
        }
        else
        {
            _rigidbody.velocity = new Vector3(move * runSpeed, _rigidbody.velocity.y, 0);
        }
       


        if(move > 0 && !facingRight)
        {
            Flip();
        }else if(move<0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 smjer = transform.localScale;
        smjer.z *= -1;
        transform.localScale = smjer;
    }
    void Jump()
    {
        isGrounded = false;
        _animator.SetBool("isGrounded", isGrounded);
        _rigidbody.AddForce(new Vector3(0, jumpPower, 0));
    }

    public float GetFacing()
    {
        if (facingRight) { return 1; } else { return -1; }
    }
}