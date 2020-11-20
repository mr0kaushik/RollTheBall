using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement m_PlayerMovement;


    public GameManager m_GameManager;
    void Start()
    {
        m_GameManager = FindObjectOfType<GameManager>();
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            m_PlayerMovement.enabled = false;
            m_GameManager.GameOver();
        }
    }
}
