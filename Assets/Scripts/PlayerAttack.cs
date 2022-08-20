using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator m_Animator;
    private GameObject attackArea = default;
    private bool attacking = false; 
    private float timeToAttack = 0.25f;
    private float timer = 0f;
    
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        attackArea = transform.GetChild(0).gameObject;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        if (attacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                m_Animator.SetBool("Punch", false);
                attackArea.SetActive(attacking);

            }
        }
    }   
    private void Attack()
    {
        attacking = true;
        m_Animator.SetBool("Punch", true);
        attackArea.SetActive(attacking);
    }
       
}

    