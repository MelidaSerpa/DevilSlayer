using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emove : MonoBehaviour
{

	Rigidbody2D rb;
	GameObject target;
	float moveSpeed;
	Vector3 directionToTarget;
	[SerializeField]
	private SpriteRenderer sr;

	[SerializeField]
	private Animator anim;

	[SerializeField]
	private float agroRange;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		target = GameObject.FindWithTag("Player");
		moveSpeed = Random.Range(4f, 8f);
	}

	// Update is called once per frame
	void Update()
	{
		//float distToPlayer = Vector2.Distance(transform.position, target.transform.position);
	
		ChasePlayer();
		MonsterAnim();
		distDetection();

	}

    void MonsterAnim()
    {
		//Monster Run animation will start if the GameObject is moving
		if (rb.velocity.x > 0 || rb.velocity.x < 0)
		{
			anim.SetBool("Run", true);
		}

		//Animation will end if there is no movement
    }

    void ChasePlayer()
	{
		float distToPlayer = Vector2.Distance(transform.position, target.transform.position);

		if (distToPlayer > agroRange)
		{
			if (target != null && transform.position.x < target.transform.position.x)
			{
				//Enemy is to the left side of the player, so move right

				rb.velocity = new Vector2(moveSpeed, 0);
				sr.flipX = true;
			}
			if (target != null && transform.position.x > target.transform.position.x)
			{
				//Enemy is to the right side of the player, so move left
				rb.velocity = new Vector2(-moveSpeed, 0);
				sr.flipX = false;
			}
			else if (target == null)
			{
				Debug.Log("Player does not exist in the hierarchy");
				rb.velocity = Vector3.zero;
			}
		}
	}

	void distDetection()
	{
		float distToPlayer = Vector2.Distance(transform.position, target.transform.position);


		if (distToPlayer < agroRange)
		{
			anim.SetTrigger("Attack");
			moveSpeed = 5;
		}
		if (distToPlayer < 1)
		{
			anim.SetBool("Run", false);
			moveSpeed = 3;
		}
		else
		{
			anim.SetBool("Run", true);
			moveSpeed = Random.Range(4f, 8f); ;
		}

	}
	

}