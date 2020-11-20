using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoreText;
    public Transform player;

    public GameManager m_GameManager;
    void Start()
    {
        m_GameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (!m_GameManager.HasGameOver())
            scoreText.text = player.position.z.ToString("0");
    }
}
