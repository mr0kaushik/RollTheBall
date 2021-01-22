
using UnityEngine.UI;

using UnityEngine;

public class TouchScript : MonoBehaviour
{
    public Text m_TouchText;
    public Text m_PlayerText;
    public Transform m_PlayerTransform;
    private Rigidbody rigidBody;
    // Start is called before the first frame update

    // Update is called once per frame

    private float m_Speed = 30f;
    private float m_ForwardForce = 1000f;

    private float m_ScreenXByTwo;
    void Start()
    {
        m_ScreenXByTwo = Screen.width / 2;
        rigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {

        rigidBody.AddForce(0f, 0f, m_ForwardForce * Time.deltaTime);

        string touchText = "";
        string playerText = "";

        playerText += "Player Position : " + m_PlayerTransform.position.ToString() + "\n";
        playerText += "Player SW Point: " + Camera.main.ScreenToWorldPoint(m_PlayerTransform.position).ToString() + " ";

        playerText += "\n";


        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                Debug.Log("Touch ToString : " + touch.ToString());

                touchText += "\n-----------*---------";
                touchText += "Touch ID : " + touch.fingerId + ",\n";
                touchText += "Altitude Angle : " + touch.altitudeAngle.ToString() + ",\n";
                touchText += "Delta Position : " + touch.deltaPosition.ToString() + ",\n";
                touchText += "Delta Time : " + touch.deltaTime.ToString() + ",\n";
                touchText += "Phase : " + touch.phase.ToString() + ",\n";
                touchText += "Position : " + touch.position.ToString() + ",\n";
                touchText += "Pressure : " + touch.pressure.ToString() + ",\n";
                touchText += "Radius : " + touch.radius.ToString() + ",\n";
                touchText += "Radius Variance : " + touch.radiusVariance.ToString() + ",\n";
                touchText += "Raw Position : " + touch.rawPosition.ToString() + ",\n";
                touchText += "Type : " + touch.type.ToString() + ",\n";
                touchText += "Touch SW Point : " + Camera.main.ScreenToWorldPoint(touch.position).ToString() + " ";
                touchText += "Touch SRay Point : " + Camera.main.ScreenPointToRay(touch.position).ToString() + " ";
                touchText += "Touch SViewPort Point : " + Camera.main.ScreenToViewportPoint(touch.position).ToString() + " ";



                touchText += "\n";

            

                float pt = touch.position.x - m_ScreenXByTwo;


                // pt / Screen.width / 2;
                Vector3 mp = new Vector3((pt / m_ScreenXByTwo * Time.deltaTime * m_Speed), 0f, 0f);


                playerText += "Player Position : " + m_PlayerTransform.position.ToString() + "\n";
                playerText += "New Position : " + mp + " \n";
                playerText += "Rigid Position : " + (mp + rigidBody.position).ToString() + "\n";

                // rigidBody.AddForce(mp);


                // m_ScoreText.text = touchText;

                playerText += "Difference : " + pt;
                rigidBody.MovePosition(rigidBody.position + mp);

                // if (pt > m_ScreenXByTwo)
                // {
                //     playerText += "Point : " + pt;
                // }

            }
            m_PlayerText.text = playerText;
            m_TouchText.text = touchText;

        }

    }

}
