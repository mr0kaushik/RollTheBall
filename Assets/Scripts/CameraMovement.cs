using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform m_PlayerPosition;
    public Vector3 m_Offset;

    // Update is called once per frame


    void Start()
    {
        
    }

    void Update()
    {

        // Quaternion rotation = transform.rotation;
        transform.position = m_PlayerPosition.position + m_Offset;    
        transform.LookAt(m_PlayerPosition);
    }

}
