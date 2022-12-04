using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] float movement = 15;
	[SerializeField] int speed = 15;
	[SerializeField] bool isFacingRight = true;
	[SerializeField] Vector2 balloonPos;
	[SerializeField] Vector2 balloonScale;
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
		
		movement = 1;
		InvokeRepeating("MakeBigger", .1f, 0.1f);
	}

    // Update is called once per frame
    //good for user input
    void Update()
    {
	balloonPos = transform.position;
		//if the balloon becomes bigger than .5, the balloon pops and no points are gained.
		if (transform.localScale.x > 40.0f)
		{
			//if a balloon times out, this value increments
			controller.GetComponent<Scorekeeper>().BalloonTimedOut();
			Pop();
		}

	}
	

    //called potentially multiple times per frame
    //use for physics/movement
    void FixedUpdate()
	{
		rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
		
		if ((balloonPos.x < -10 && !isFacingRight) || (balloonPos.x > 10 && isFacingRight)){
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

   private void OnTriggerEnter2D (Collider2D other){

		if(other.tag == "Pin"){
			Pop();
			controller.GetComponent<Scorekeeper>().AddPoints();

		}


    }

	void MakeBigger()
	{
		Vector2 sizeIncrease = new Vector2(transform.localScale.x * 1.01f, transform.localScale.y * 1.01f);
		transform.localScale = sizeIncrease;
	}

	void Pop()
    {
		AudioSource.PlayClipAtPoint(audio.clip, balloonPos);
		Destroy(gameObject);
	}
}

