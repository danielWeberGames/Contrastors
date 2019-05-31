using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public string moveAxis;
    public string jumpAction;

    public float speed;
    public float jumpForce;
    public float gravity;
    public float downGravity;
    bool grounded;

    Rigidbody2D rb;
    Animator anim;

    public Vector2 velocity;


    float inputDir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity.x = speed * inputDir * Time.deltaTime;

        if(Input.GetButtonDown(jumpAction))
        {
            velocity.y += jumpForce;
            grounded = false;
        }
        GravityMath();
        rb.MovePosition(rb.position + velocity);

    }

    private void FixedUpdate()
    {
        inputDir = Input.GetAxis(moveAxis);

        if(inputDir >0 || inputDir<0)
        {
            if(Mathf.Sign(inputDir) != Mathf.Sign(transform.localScale.x))
            {
                transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
            }
        }
        anim.SetFloat("Speed", Mathf.Abs(inputDir));

    }

    void GravityMath()
    {
        if (!grounded)
        {
            if(velocity.y > 0)
            {
                velocity.y -= gravity * Time.deltaTime;
            }
            else
            {
                velocity.y -= downGravity * Time.deltaTime;
            }

        }
        else
        {
            velocity.y = 0;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
    }

}
