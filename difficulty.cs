using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class difficulty
{

	static float secondsToMaxDifficulty = 120;

	public static float GetDifficultyPercent()
	{
		return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty); //it will take 60 seconds from the start of the game to reach max difficulty
	}

}
