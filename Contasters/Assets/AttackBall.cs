using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBall : MonoBehaviour
{
    Rigidbody2D rb;
    public float hitForce;

    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "AttackTrigger")
        {
            direction = transform.position - other.gameObject.transform.position;
            rb.AddForce(direction * hitForce);
        }
    }


}
