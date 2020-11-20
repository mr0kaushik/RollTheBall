using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject m_ObstaclePrefab;
    public Transform[] m_SpwanPoints;


    // Start is called before the first frame update
    // private void SpwanObstacles()
    // {
    //     int blankIndex = Random.Range(0, m_SpwanPoints.Length);
    //     for (int i = 0; i < m_SpwanPoints.Length; i++)
    //     {
    //         if (blankIndex == i) continue;
    //         float xScale = Random.Range(1f, 2f);
    //         m_ObstaclePrefab.transform.localScale = new Vector3(xScale,
    //         m_ObstaclePrefab.transform.localScale.y, m_ObstaclePrefab.transform.localScale.z);
    //         Instantiate(m_ObstaclePrefab, m_SpwanPoints[i].position, Quaternion.identity);
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        // SpwanObstacles();
    }

    void Start()
    {
        // StartCoroutine(SpwanObstacles());
    }
    IEnumerator SpwanObstacles()
    {
        while (true)
        {
            int blankIndex = Random.Range(0, m_SpwanPoints.Length);
            for (int i = 0; i < m_SpwanPoints.Length; i++)
            {
                if (blankIndex == i) continue;
                float xScale = Random.Range(1f, 2f);
                m_ObstaclePrefab.transform.localScale = new Vector3(xScale,
                m_ObstaclePrefab.transform.localScale.y, m_ObstaclePrefab.transform.localScale.z);
                Instantiate(m_ObstaclePrefab, m_SpwanPoints[i].position, Quaternion.identity);
            }
            yield return new WaitForSeconds(3);
        }
    }
}
