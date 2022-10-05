using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private Rigidbody2D myBody;

    [SerializeField]
    private Transform attackPoint;

    public float attackRange;
    public LayerMask enemyLayer;


    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0))
        {
            //Play Attack2 (Standard attack)
            anim.SetTrigger("Attack2");
            Debug.Log("Attack2 executed");
        }
        if (Input.GetKey(KeyCode.Mouse0) && Mathf.Abs(myBody.velocity.x) > 0)
        {
            //Play Attack3 (Side attack while walking)
            anim.SetTrigger("Attack3");
            Debug.Log("Attack3 executed");
        }
        if (Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.LeftControl) || 
            Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKeyDown(KeyCode.LeftControl))
        {
            //Play Attack1 (Special attack)
            anim.SetTrigger("Attack1");
            Debug.Log("Attack1 executed");
        }
    }

    void Attack()
    {
        //Detect monsters in range attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        //Damage monsters
        foreach (Collider2D Enemy in hitEnemies) 
        {
            Debug.Log("Enemy was hit");
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
