using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator playerAnim;

    public string attackAction;

    public GameObject attackCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown(attackAction))
        {
            playerAnim.SetTrigger("Attack");
        }


    }

    public void AttackTriggerOn()
    {
        attackCollider.SetActive(true);
    }
    public void AttackTriggerOff()
    {
        attackCollider.SetActive(false);
    }

}
