using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float speed = 10;
	public event System.Action OnPlayerDeath;

	float screenHalfWidthInWorldUnits;

	void Start()
	{
		float halfPlayerWidth = transform.localScale.x / 2f;
		screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
	}

	void Update()
	{
		//basic controls
		float inputX = Input.GetAxisRaw("Mouse X");
		float velocity = inputX * speed;
		transform.Translate(Vector3.right * velocity * Time.deltaTime);

		//teleports the player to the other side of the screen when they go off screen.
		if (transform.position.x < -screenHalfWidthInWorldUnits)
		{
			transform.position = new Vector3(screenHalfWidthInWorldUnits, transform.position.y);
		}

		if (transform.position.x > screenHalfWidthInWorldUnits)
		{
			transform.position = new Vector3(-screenHalfWidthInWorldUnits, transform.position.y);
		}

	}

	//when the player contacts a trigger rigidbody with the "Falling Block" tag.  
	void OnTriggerEnter(Collider triggerCollider)
	{
		if (triggerCollider.tag == "Falling Block")
		{
			if (OnPlayerDeath != null)
			{
				OnPlayerDeath();
            }
			Destroy(gameObject);

        }
    }
	
}
