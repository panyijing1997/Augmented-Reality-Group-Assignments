using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_0 : MonoBehaviour
{
    // Start is called before the first frame update

    public float lineLength = 0.15f;
    private bool pressed = false;
    void Start()
    {
    }
    
    void Update()
    {
        Vector3 boomIniPos = new Vector3(100, 10, 10);
        Vector3 position = transform.position;
        Vector3 direction = transform.forward;
        GameObject boom = GameObject.Find("Explosion");
        if (Input.GetKeyDown("space"))
        {
            if (pressed)
                pressed = false;
            else
                pressed = true;
        }

        if (pressed)
        {
            DrawLine(position, direction * lineLength,0.005f);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, lineLength))
            {
                
                boom.transform.position = hit.point;
            }
            else
            {
                boom.transform.position = boomIniPos;
            }
        }
        else
        {

            boom.transform.position = boomIniPos;
        }
        
    }

    void DrawLine(Vector3 start, Vector3 end, float lineWidth = 0.005f)
    {
        GameObject myLine = new GameObject();
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        Material material = new Material(Shader.Find("Particles/Standard Unlit"));
        material.color = Color.blue;
        lr.material = material;
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth*0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        Destroy(myLine, Time.deltaTime);
    }

}
