using System.Collections;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{


    private float m_YAxisGameOverPoint = 0f;

    // [SerializeField]
    private float m_Speed = 1500f;
    // [SerializeField]
    private float m_ForwardForce = 1000f;
    public float m_MapWidth;
    private Rigidbody rb;

    private GameManager m_GameManager;

    private float m_HalfScreenWidth;

    private float delta_Y;

    void Start()
    {
        m_HalfScreenWidth = Screen.width / 2;
        rb = GetComponent<Rigidbody>();
        m_GameManager = FindObjectOfType<GameManager>();
    }


    void Update()
    {

        // rb.AddForce(0, 0, m_ForwardForce * Time.deltaTime);

        // Debug.Log("Touch Count " + Input.touchCount);


        // if (Input.touchCount > 0)
        // {
        //     Touch touch = Input.GetTouch(0);
        //     Vector3 tch = touch.position;
        //     Vector3 TouchToWorld = Camera.main.ScreenToWorldPoint(tch);

        //     switch (touch.phase)
        //     {
        //         case TouchPhase.Began:
        //             rb.MovePosition(new Vector3(rb.position.x, 0f, 0f));
        //             // delta_Y = TouchToWorld.y - rb.position.y;
        //             break;

        //         case TouchPhase.Stationary:

        //             rb.velocity = new Vector2(40f * m_Speed * Time.deltaTime, 0f);
        //             break;

        //         case TouchPhase.Moved:
        //             rb.MovePosition(new Vector3(rb.position.x + (m_Speed * Time.deltaTime), TouchToWorld.y - delta_Y, 0f));
        //             // rb.rotation = TouchToWorld.y * 10f;
        //             break;               

        //         case TouchPhase.Ended:
        //             // rb.rotation = 0f;
        //             rb.velocity = new Vector2(40f * m_Speed * Time.deltaTime, 0f);
        //             break;           
        //     }
        // }

        // for (int i = 0; i < Input.touchCount; i++)
        // {
        //     Touch touch = Input.GetTouch(0);
        //     Vector3 tch = touch.position;
        //     Vector3 TouchToWorld = Camera.main.ScreenToWorldPoint(tch);
        //     Debug.Log("Touch Position : " + tch.ToString());
        //     Debug.Log("Camera Respctive Position: " + TouchToWorld.ToString());
        //     if (Input.GetTouch(i).position.x > m_HalfScreenWidth)
        //     {
        //         MovePlayer(1.0f);
        //     }
        //     if (Input.GetTouch(i).position.x < m_HalfScreenWidth)
        //     {
        //         MovePlayer(-1.0f);
        //     }
        // }

        // if(Input.touchCount > 0)
        // {
        //     Touch touch = Input.GetTouch(0);


        //     Debug.Log("Touch Position : " + touch.position.ToString());

        //     Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);

        //     Debug.Log("Touch With Camera Position : " + pos.ToString());

        //     Debug.Log("Rigid Body Positoin " + rb.position.ToString());
        //     Debug.Log("Value " + (Vector3.right * pos.x * Time.deltaTime * m_Speed).ToString());


        //     if( pos.x > 0){

        //         rb.MovePosition(rb.position + (Vector3.right * pos.x * Time.deltaTime * m_Speed));
        //         // rb.position + (Vector3.right * touchPosition.x * Time.deltaTime * m_Speed)                
        //     } else {
        //         rb.MovePosition(rb.position + (Vector3.right * pos.x * Time.deltaTime * m_Speed));
        //     }

        // if (rb.position.y < m_YAxisGameOverPoint)
        // {
        //     m_GameManager.GameOver();
        // }

        //     rb.MovePosition();
        // } else {
        //     rb.MovePosition();
        // }
    }


    private void MovePlayer(float val)
    {

        rb.AddForce(new Vector3(val * m_Speed * Time.deltaTime, 0f, 0f));
    }

//     void FixedUpdate()
//     {
// #if UNITY_EDITOR
//         MovePlayer(Input.GetAxis("Horizontal"));
// #endif
//     }

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
