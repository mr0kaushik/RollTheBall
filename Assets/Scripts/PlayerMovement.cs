using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float m_YAxisGameOverPoint = 0f;

    [SerializeField]
    private float m_Speed = 20f;
    [SerializeField]
    public float m_ForwardForce = 500f;
    public float m_MapWidth;
    private Rigidbody rb;

    private GameManager m_GameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_GameManager = FindObjectOfType<GameManager>();
    }

    void FixedUpdate()
    {


        rb.AddForce(0, 0, m_ForwardForce * Time.deltaTime);
        float _xAxisMovement = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * m_Speed;

        Vector3 newPosition = rb.position + Vector3.right * _xAxisMovement;

        // newPosition.x = Mathf.Clamp(newPosition.x, -m_MapWidth, m_MapWidth);
        rb.MovePosition(newPosition);

        if (rb.position.y < m_YAxisGameOverPoint)
        {
            m_GameManager.GameOver();
        }

    }


}
