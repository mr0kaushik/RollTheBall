using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{

    public GameObject m_CompleteLevelUI;
    public GameObject m_GameOverUI;


    public TextMeshProUGUI m_FinalScoreText;
    public Text m_ScoreText;
    public Transform player;


    public int m_CurrenLevel = -1;
    private float m_RestartDelay = 3f;
    private float m_GameOverUIDelay = 1f;

    private bool m_HasGameOver = false;

    private float score;

    private bool isCoroutineExecuting = false;

    public PlayerMovement m_PlayerMovement;


    public bool HasGameOver()
    {
        return m_HasGameOver;
    }


    public void GameStart()
    {
        Debug.Log("Game Start");
        m_HasGameOver = false;

    }

    public void GameOver()
    {
        if (!m_HasGameOver)
        {
            m_HasGameOver = true;
            Invoke("ShowGameOverUI", m_GameOverUIDelay);
            Invoke("Restart", m_RestartDelay);
        }
    }

    void ShowGameOverUI()
    {
        m_GameOverUI.SetActive(true);
        m_FinalScoreText.text = "Score : " + score.ToString("0");
        m_ScoreText.gameObject.SetActive(false);
    }

    void Restart()
    {
        Debug.Log("Game Re-Start");
        m_HasGameOver = false;
        m_GameOverUI.SetActive(false);
        m_ScoreText.gameObject.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void CompleteLevel()
    {
        Debug.Log("Game Complete level");
        m_PlayerMovement.enabled = false;
        m_CompleteLevelUI.SetActive(true);
        Invoke("LoadNextLevel", m_RestartDelay);        
    }

    void LoadNextLevel()
    {
        Debug.Log("Game Load Next level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update()
    {
        if (!m_HasGameOver)
        {
            score = player.position.z;
            m_ScoreText.text = score.ToString("0");
        }
    }


    IEnumerator ExecuteAfterTime(float time, Action task)
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        task();
        isCoroutineExecuting = false;
    }



}




// public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
// {
//     // Check to see if we're about to be destroyed.
//     private static bool m_ShuttingDown = false;
//     private static object m_Lock = new object();
//     private static T m_Instance;
 
//     /// <summary>
//     /// Access singleton instance through this propriety.
//     /// </summary>
//     public static T Instance
//     {
//         get
//         {
//             if (m_ShuttingDown)
//             {
//                 Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
//                     "' already destroyed. Returning null.");
//                 return null;
//             }
 
//             lock (m_Lock)
//             {
//                 if (m_Instance == null)
//                 {
//                     // Search for existing instance.
//                     m_Instance = (T)FindObjectOfType(typeof(T));
 
//                     // Create new instance if one doesn't already exist.
//                     if (m_Instance == null)
//                     {
//                         // Need to create a new GameObject to attach the singleton to.
//                         var singletonObject = new GameObject();
//                         m_Instance = singletonObject.AddComponent<T>();
//                         singletonObject.name = typeof(T).ToString() + " (Singleton)";
 
//                         // Make instance persistent.
//                         DontDestroyOnLoad(singletonObject);
//                     }
//                 }
 
//                 return m_Instance;
//             }
//         }
//     }
 
 
//     private void OnApplicationQuit()
//     {
//         m_ShuttingDown = true;
//     }
 
 
//     private void OnDestroy()
//     {
//         m_ShuttingDown = true;
//     }
// }
