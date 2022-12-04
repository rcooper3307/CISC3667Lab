using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMovement : MonoBehaviour
{
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] float movement;
	[SerializeField] int speed = 15;
	[SerializeField] bool isFacingRight = true;
	[SerializeField] bool jumpPressed = false;
	[SerializeField] float jumpForce = 500.0f;
	[SerializeField] bool isGrounded = true;
	[SerializeField] GameObject controller;
	private float nextFire = 0.5F;
	private float myTime = 0.0F;
	private float fireDelta = 0.5F;
	[SerializeField] Animator animator;
	const int IDLE = 0;
	const int RUN = 1;
	const int JUMP = 2;

    // Start is called before the first frame update
    void Start()
    {
		if (rigid == null)
			rigid = GetComponent<Rigidbody2D>();
		if (controller == null)
			controller = GameObject.FindGameObjectWithTag("GameController");
		if (animator == null)
			animator = GetComponent<Animator>();
		animator.SetInteger("motion", IDLE);
    }

    // Update is called once per frame
    //good for user input
    void Update()
    {
	myTime = myTime + Time.deltaTime;
	movement = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
			jumpPressed = true;

	if(Input.GetButton("Fire1") && myTime > nextFire){ //if firebutton is pressed, use the shoot function from gamecontroller
		nextFire = myTime + fireDelta;
		controller.GetComponent<ShootScript>().Shoot(transform.position.x, transform.position.y);
		nextFire = nextFire - myTime;
		myTime = 0.0F;
	}
		
		
		
    }

    //called potentially multiple times per frame
    //use for physics/movement
    void FixedUpdate()
	{
		rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
		//if the player isnt jumping and is on the ground, if their movement speed is greater than 0, then set animation to run, if not then idle
		if (!jumpPressed && isGrounded)
			if (movement > 0 || movement < 0)
			{
				animator.SetInteger("motion", RUN);
			}
            else
            {
				animator.SetInteger("motion", IDLE);
            }



		if ((movement < 0 && isFacingRight) || (movement > 0 && !isFacingRight))
				Flip();

		if (jumpPressed && isGrounded)
			Jump();
	}

    void Flip()
	{
		transform.Rotate(0, 180, 0);
		isFacingRight = !isFacingRight; 
	}

    void Jump()
	{
		rigid.velocity = new Vector2(rigid.velocity.x, 0);
		rigid.AddForce(new Vector2(0, jumpForce));
		jumpPressed = false;
		isGrounded = false;
		animator.SetInteger("motion", JUMP);
	}

    void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			isGrounded = true;
			animator.SetInteger("motion", IDLE);
		}

	}

}
