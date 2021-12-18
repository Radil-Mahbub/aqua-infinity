using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

	public GameObject fallingBlockPrefab;
	public Vector2 secondsBetweenSpawnsMinMax;
	float nextSpawnTime;

	public Vector2 spawnSizeMinMax;
	public float spawnAngleMax;

	Vector2 screenHalfSizeWorldUnits;

	// Use this for initialization
	void Start()
	{
		screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
	}

	// Update is called once per frame
	void Update()
	{

		if (Time.time > nextSpawnTime)
		{
			//will change the amount of rock spawns * difficulty
			float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, difficulty.GetDifficultyPercent());
			nextSpawnTime = Time.time + secondsBetweenSpawns;

			//will spawn the rocks at a randonm size and angle
			float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
			float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);

			//random spawn position
			Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);

			//spawns the block based on the above data
			GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
			newBlock.transform.localScale = Vector3.one * spawnSize;
		}

	}
}
