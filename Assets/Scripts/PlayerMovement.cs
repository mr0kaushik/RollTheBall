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


    void Update()
    {
        
        rb.AddForce(0, 0, m_ForwardForce * Time.deltaTime);

        Debug.Log("Touch Count " + Input.touchCount);

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Debug.Log("Touch Position : " + touch.position.ToString());

            Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);

            Debug.Log("Touch With Camera Position : " + pos.ToString());
            
            Debug.Log("Rigid Body Positoin " + rb.position.ToString());
            Debug.Log("Value " + (Vector3.right * pos.x * Time.deltaTime * m_Speed).ToString());

            
            if( pos.x > 0){
    
                rb.MovePosition(rb.position + (Vector3.right * pos.x * Time.deltaTime * m_Speed));
                // rb.position + (Vector3.right * touchPosition.x * Time.deltaTime * m_Speed)                
            } else {
                rb.MovePosition(rb.position + (Vector3.right * pos.x * Time.deltaTime * m_Speed));
            }

            if (rb.position.y < m_YAxisGameOverPoint)
        {
            m_GameManager.GameOver();
        }

            //     rb.MovePosition();
            // } else {
            //     rb.MovePosition();
            // }
        }
    }

    /* void FixedUpdate()
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
 */

}
