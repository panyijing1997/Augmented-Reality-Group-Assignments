using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    Mesh myMesh;
    Vector3[] vertices;
    int[] triangles;
    static float d=3; // wings on y axis
    int direction = -1; //moving direction of wings;
   // int direction2 = 1;//moving direction for the spaceship;
    private Vector3 pos1; //position of target 1
    private Vector3 pos2; //position of target 2
    static float alpha = 0; // decide the position between target1 and target2, alpha approxmately range from [0,1]
    static int n =0; // # of frames

    void Start()
    {
        pos1 = new Vector3(0, 0, 0);
        pos2 = new Vector3(0, 0, 0);
        myMesh = new Mesh();
        GetComponent<MeshFilter>().mesh = myMesh;
    }

    // Update is called once per frame
    void Update()
    {
        n++;
        //
        d = d + direction * 0.05f;
        if (n % 80 == 0) direction = -direction;

        //position of two targets
        //pos1 = new Vector3(0, 0, -5);
        //pos2 = new Vector3(0, 0, 5);
        pos1 = GameObject.Find("Target1").transform.position;
        pos2 = GameObject.Find("Target2").transform.position;


        //compute alpha, deicide the position between two targets.
        /*
        if (alpha <= 0) direction2 = 1;
        else if (alpha >= 1) direction2 = -1;
        alpha = alpha + Time.deltaTime * direction2;
        Debug.Log(alpha);
        */
        alpha = Mathf.PingPong(Time.time, 1);
        //compute position between two targets
        Vector3 pos = pos1 + (pos2 - pos1) * alpha;
        Matrix4x4 t = T(pos[0],pos[1],pos[2]);
        transform.position = t.MultiplyPoint3x4(new Vector3(0,0,0));
        //forward
        transform.forward =Vector3.Normalize(pos2 - pos1);
        CreateSpaceship(d);
    }
    void CreateMesh(float d)
    {
        vertices = new Vector3[]
        {
            new Vector3 (0, 0, 0),

            new Vector3 (-0.3f,0,0.5f),
            new Vector3 (0.3f, 0, 0.5f),
            new Vector3 (-0.55f, 0, 1.25f),
            new Vector3 (0.55f, 0, 1.25f),
            new Vector3 (-1, 0, 2),

            new Vector3 (-0.8f, 0, 2),
            new Vector3 (0.8f, 0, 2),
            new Vector3 (1, 0, 2),
            new Vector3 (-1, 0, 3),
            new Vector3 (1, 0, 3),

            new Vector3 (-3, d, 6),
            new Vector3 (3, d, 6),
            new Vector3 (-1.5f, 0.5f*d, 6),
            new Vector3 (-1, 0, 6),
            new Vector3 (1, 0, 6),

            new Vector3 (1.5f, 0.5f*d, 6),
            new Vector3 (0, 0, 5),
            new Vector3 (0, 0, 7),
            new Vector3 (0, 0.5f, 6.5f),
            new Vector3 (-1, 0, 7),

            new Vector3 (1, 0, 7),
            new Vector3 (-1, 0, 7.3f),
            new Vector3 (-0.2f, 0, 7.3f),
            new Vector3 (0.2f, 0, 7.3f),
            new Vector3 (1, 0, 7.3f),

            new Vector3 (-0.2f, 0,7),
            new Vector3 (0.2f, 0, 7),
            new Vector3 (0, 0, 7.1f),


        };
        triangles = new int[]
        {
            0,1,2,
            1,6,2,
            2,6,7,
            3,5,6,
            4,7,8,
            5,20,21,

            5,21,8,
            17,18,19,
            9,11,14,
            10,15,12,
            13,20,14,

            15,21,16,
            20,22,23,
            20,23,26,
            27,24,25,
            27,25,21,

            26,27,28,
            17,19,18
         };
    }
    void CreateSpaceship(float d)
    {
        myMesh.Clear(); //clear old 
        CreateMesh(d);
        myMesh.vertices = vertices;
        myMesh.triangles = triangles;
        Color[] colors = new Color[vertices.Length];
     
        for (int i = 0; i < vertices.Length; i++)
            colors[i] = Color.yellow;
        // Color Lerp(Color a, Color b, float t): Linearly interpolates between colors a and b by t.
        Color color_blink = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(5 * Time.time, 1));
        //wings and tails changing colors;
        colors[15]=colors[19]=colors[18] = colors[17] = colors[12]  = colors[11] = colors[14] =color_blink;



        myMesh.colors = colors;
        myMesh.RecalculateNormals();
    }
    public static Matrix4x4 T(float x, float y, float z)
    {
        Matrix4x4 m = new Matrix4x4();

        m.SetRow(0, new Vector4(1, 0, 0, x));
        m.SetRow(1, new Vector4(0, 1, 0, y));
        m.SetRow(2, new Vector4(0, 0, 1, z));
        m.SetRow(3, new Vector4(0, 0, 0, 1));

        return m;
    }
}
