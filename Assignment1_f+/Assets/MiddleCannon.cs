using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleCannon : MonoBehaviour
{
    // Start is called before the first frame update
    public float lineLength = 0.15f;
    private bool shoot = false;
    public LineRenderer lineRenderer;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 boomIniPos = new Vector3(10, 10, 10);
        Vector3 position = transform.position;
        Vector3 direction = transform.forward;
        GameObject boom = GameObject.Find("Explosion");
        if (Input.GetKeyDown("space"))
        {
            if (shoot)
                shoot = false;
            else
                shoot = true;
        }

        if (shoot)
        {
            RaycastHit hit;

            DrawLine(position, direction * lineLength + position, 0.005f);
            if (Physics.Raycast(transform.position, direction, out hit, lineLength))
            {
                boom.transform.position = hit.point;
                Debug.Log("Did Hit");
            }
            else
            {
                boom.transform.position = boomIniPos;
            }
        }
        else
        {

            DrawLine(position, position);
            boom.transform.position = boomIniPos;
        }


    }
    void DrawLine(Vector3 start, Vector3 end, float lineWidth = 0.01f)
    {

        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}

