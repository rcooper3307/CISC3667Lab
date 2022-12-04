using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distractor : MonoBehaviour
{
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] float movement = 1;
	[SerializeField] int speed = 15;
	[SerializeField] bool isFacingRight = true;
	[SerializeField] Vector2 distractorPos;
	[SerializeField] AudioSource audio;
	[SerializeField] GameObject controller;

	// Start is called before the first frame update
	void Start()
	{
		if (controller == null)
		{
			controller = GameObject.FindGameObjectWithTag("GameController");
		}
		if (rigid == null)
			rigid = GetComponent<Rigidbody2D>();
		if (audio == null)
			audio = GetComponent<AudioSource>();

	}

	// Update is called once per frame
	//good for user input
	void Update()
	{
		distractorPos = transform.position;
	}

	//called potentially multiple times per frame
	//use for physics/movement
	void FixedUpdate()
	{
		rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);

		if ((distractorPos.x < -10 && !isFacingRight) || (distractorPos.x > 10 && isFacingRight))
		{
			Flip();
		}


	}

	void Flip()
	{
		transform.Rotate(0, 180, 0);
		isFacingRight = !isFacingRight;
		if (isFacingRight)
			movement = 1;
		else
			movement = -1;
	}

	void OnCollisionEnter2D(Collision2D other)
	{

		if (other.gameObject.tag == "Player")
		{


			Hit();
			controller.GetComponent<Scorekeeper>().Damage();

		}


	}
	void Hit()
	{
		AudioSource.PlayClipAtPoint(audio.clip, distractorPos);
	}
}
