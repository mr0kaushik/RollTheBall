using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{

    public void PlayAgain()
    {
        Debug.Log("Play Again");

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


}
