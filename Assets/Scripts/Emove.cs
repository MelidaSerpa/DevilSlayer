using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emove : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rb;
    GameObject target;
    float moveSpeed;
    Vector3 directionToTarget;


    
    void Start()
    {
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(4f, 10f);
    }

    void Update()
    {
        MoveMonster();
    }

    void MoveMonster()
    {
        if (target != null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed,
                                        directionToTarget.y * moveSpeed);
        }
        else 
        {
            rb.velocity = Vector3.zero;
        }
    }
















}