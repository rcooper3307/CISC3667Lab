using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinScript : MonoBehaviour
{
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] float movement = 1;
	[SerializeField] int speed = 5;
	[SerializeField] Vector2 pinPos;

    // Start is called before the first frame update
    void Start()
    {
	if (rigid == null)
		rigid = GetComponent<Rigidbody2D>();
	
	movement = 1;
	
    }

    // Update is called once per frame
    //good for user input
    void Update()
    {
	pinPos = transform.position;
    }

    //called potentially multiple times per frame
    //use for physics/movement
    void FixedUpdate()
	{
		rigid.velocity = new Vector2(rigid.velocity.x, movement * speed); //the pin will move vertically
		
		if (pinPos.y > 6){ //if the pin goes out of bounds, it is destroyed.
			Destroy(gameObject);
		}
	}
}

