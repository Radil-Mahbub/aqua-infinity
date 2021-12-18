using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingBlock : MonoBehaviour
{
	public Vector2 speedMinMax;
	float speed;

	float visibleHeightThreshold;

	void Start()
	{
		//spawn rocks with speed in refence to difficulty amount
		speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, difficulty.GetDifficultyPercent());

		//sets the amount of visible screen area the player can see
		visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
	}

	void Update()
	{
		transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);

		if (transform.position.y < visibleHeightThreshold)
		{
			Destroy(gameObject);
		}
	}
}
