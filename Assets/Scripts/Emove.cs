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

	// Use this for initialization
	void Start()
	{
		target = GameObject.FindWithTag("Player");
		rb = GetComponent<Rigidbody2D>();
		moveSpeed = Random.Range(6f, 10f);
	}

	// Update is called once per frame
	void Update()
	{
		//float distToPlayer = Vector2.Distance(transform.position, target.transform.position);
		ChasePlayer();



	}



	void ChasePlayer()
	{
		if (target != null && transform.position.x < target.transform.position.x)
		{
			//Enemy is to the left side of the player, so move right

			rb.velocity = new Vector2(moveSpeed, 0);
			sr.flipX = true;
			Debug.Log("Enemy should move to the right");
		}
		else if (target != null && transform.position.x > target.transform.position.x)
		{
			//Enemy is to the right side of the player, so move left
			rb.velocity = new Vector2(-moveSpeed, 0);
			sr.flipX = false;
			Debug.Log("Enemy should move to the left");
		}
		else if (target == null)
		{
			Debug.Log("Player does not exist in the hierarchy");
			rb.velocity = Vector3.zero;
		}
	}

}