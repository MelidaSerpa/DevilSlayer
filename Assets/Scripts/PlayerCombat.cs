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

    public int attack1Damg = 30;
    public int attack2Damg = 20;
    public int attack3Damg = 22;


    void Update()
    {
        //ATTACK 2
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //Play Attack2 (Standard attack)
            anim.SetTrigger("Attack2");
            Attack2();
            Debug.Log("Attack2 anim executed");
        }
        //ATTACK 3
        if (Input.GetKey(KeyCode.Mouse0) && Mathf.Abs(myBody.velocity.x) > 0)
        {
            //Play Attack3 (Side attack while walking)
            anim.SetTrigger("Attack3");
            Attack3();
            Debug.Log("Attack3 anim executed");
        }
        //ATTACK 1
        if (Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.LeftControl) || 
            Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKeyDown(KeyCode.LeftControl))
        {
            //Play Attack1 (Special attack)
            anim.SetTrigger("Attack1");
            Attack1();
            Debug.Log("Attack1 anim executed");
        }

        RayCasting();

    }

    void Attack2()
    {
        //Detect monsters in range attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        //Damage monsters
        foreach (Collider2D Enemy in hitEnemies) 
        {
            Debug.Log("Attack 2");
            Enemy.GetComponent<EnemyStats>().TakeDamage(attack2Damg);
        }
    }

    void Attack3()
    {
        //Detect monsters in range attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        //Damage monsters
        foreach (Collider2D Enemy in hitEnemies)
        {
            Debug.Log("Attack 3");
            Enemy.GetComponent<EnemyStats>().TakeDamage(attack3Damg);
        }
    }


    void Attack1()
    {
        //Detect monsters in range attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        //Damage monsters
        foreach (Collider2D Enemy in hitEnemies)
        {
            Debug.Log("Attack 1");
            Enemy.GetComponent<EnemyStats>().TakeDamage(attack1Damg);
        }
    }

    void RayCasting()
    {
        Physics2D.IgnoreLayerCollision(3, 7);
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
