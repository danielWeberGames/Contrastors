using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public string moveAxis;
    public string jumpAction;

    public float speed;
    public float jumpForce;

    Rigidbody2D rb;
    Animator anim;

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
        float movement = speed * inputDir * Time.deltaTime;

        rb.MovePosition(transform.position + transform.right * movement);

    }

    private void FixedUpdate()
    {
        inputDir = Input.GetAxis(moveAxis);

        if(inputDir != 0)
        {
            anim.SetFloat("Speed", Mathf.Abs(inputDir));
            if(Mathf.Sign(inputDir) != Mathf.Sign(transform.localScale.x))
            {
                transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
            }
        }

        if (Input.GetButtonDown(jumpAction))
        {
            rb.AddForce(transform.up * jumpForce);
        }

    }

}
