using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpScript : MonoBehaviour
{
    [SerializeField]
    public bool isGrounded = true;
    const float groundcheckRaduis = 0.2f;
    [SerializeField]
    LayerMask groundLayer;
    Rigidbody2D rb;
    [SerializeField]
    float JumpSpeed;
    bool jumpPressed;
    Transform groundcheckCollider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        groundcheckCollider = GetComponent<Transform>();
        
    }

    void Update()
    {
        Jump();
    }
      void FixedUpdate()
    {
        GroundCheck();
        JumpGravityMultiplier();
    }

    void Jump(){
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
        }
        if (Input.GetButton("Jump"))
        {
            jumpPressed =true;
        }else
        {
            jumpPressed = false;
        }
        
    }
      void JumpGravityMultiplier(){
        if (rb.velocity.y < 0)
    {
            rb.velocity += Vector2.up * Physics2D.gravity.y * 1.5f * Time.fixedDeltaTime;
        }
        else if (rb.velocity.y > 0 && !jumpPressed)
    {
            rb.velocity += Vector2.up * Physics2D.gravity.y * 1f * Time.fixedDeltaTime;
        }
    }

    void GroundCheck(){
        isGrounded =false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundcheckCollider.position, groundcheckRaduis, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
    }
    
    
}
