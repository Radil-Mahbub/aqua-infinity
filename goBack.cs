using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goBack : MonoBehaviour
{
    public void newLevel()
    {
        //sets up the next scene when we press play.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
