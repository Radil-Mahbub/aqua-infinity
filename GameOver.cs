using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{

	public GameObject gameOverScreen;
	public Text secondsSurvivedUI;
	bool gameOver;

	void Start()
	{   
		//will find the player controller script and tell it to die
		FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver;
	}

	void Update()
	{

		if (gameOver)//if the player gets destroyed
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				SceneManager.LoadScene(2);
			}
		}
	}

	void OnGameOver()
	{
		//Sets the game over screen and displays your score
		gameOverScreen.SetActive(true);
		secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
		gameOver = true;
	}
}
