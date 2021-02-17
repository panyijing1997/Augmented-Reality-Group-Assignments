using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class PositionTransformation : MonoBehaviour
{

    public GameObject SpaceShuttle;
    public GameObject LandingStrip;
    public GameObject signallight;
    public GameObject nose;
    Vector3 pos=new Vector3(0,0,0);
    private float updateCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
     
    // Update is called once per frame
    void Update()
    {
        
        Vector3 nose_Position=nose.transform.localPosition;
        Matrix4x4 mat = SpaceShuttle.transform.localToWorldMatrix;
        Matrix4x4 invMat = LandingStrip.transform.worldToLocalMatrix;
        updateCount++;
        if(updateCount==150)
        {
        Matrix4x4 result=invMat*mat;
        pos=result.MultiplyPoint3x4(nose_Position);
        updateCount=0;
        }

        // Vector3 nose_Position=nose.transform.position;
        // Matrix4x4 mat = SpaceShuttle.transform.localToWorldMatrix;
        // Matrix4x4 invMat = LandingStrip.transform.worldToLocalMatrix;
        // updateCount++;
        // if(updateCount==30)
        // {
        // pos=nose_Position;
        // updateCount=0;
        // }
        
    }

    private void OnGUI()
    {
    // values might need to be adjusted
    
    GUI.skin.label.fontSize = 30;
    GUI.color = Color.red;
    GUI.Label(new Rect(10, 10, 1000, 300), $"Local position: {pos.x}, {pos.y}, {pos.z}");
    //GUI.Label(new Rect(10, 90, 1000, 300), $"{SpaceShuttle.GetComponent<Renderer>().bounds.size}");
    if(pos.y<0.1&&Math.Abs(pos.x)<0.03&&Math.Abs(pos.z)<0.2)
    {
    GUI.Label(new Rect(10, 50, 1000, 300), $"Prepare for landing");
    }
    else if(Math.Abs(pos.x)<0.03&&Math.Abs(pos.z)<0.2)
    {
    GUI.Label(new Rect(10, 50, 1000, 300), $"Please approach runway");
    }
    
    }


    // public static Matrix4x4 T(float x, float y, float z)
    // {
    //     Matrix4x4 m = new Matrix4x4();

    //     m.SetRow(0, new Vector4(1, 0, 0, x));
    //     m.SetRow(1, new Vector4(0, 1, 0, y));
    //     m.SetRow(2, new Vector4(0, 0, 1, z));
    //     m.SetRow(3, new Vector4(0, 0, 0, 1));

    //     return m;
    // }

    // public static Matrix4x4 Rx(float a)
    // {
    //     Matrix4x4 m = new Matrix4x4();

    //     m.SetRow(0, new Vector4(1, 0, 0, 0));
    //     m.SetRow(1, new Vector4(0, Mathf.Cos(a), -Mathf.Sin(a), 0));
    //     m.SetRow(2, new Vector4(0, Mathf.Sin(a), Mathf.Cos(a), 0));
    //     m.SetRow(3, new Vector4(0, 0, 0, 1));

    //     return m;
    // }

    // public static Matrix4x4 Ry(float a)
    // {
    //     // TODO: implement
    // }

    // public static Matrix4x4 Rz(float a)
    // {
    //     // TODO: implement
    // }


    // public static Matrix4x4 S(float sx, float sy, float sz)
    // {
    //     // TODO: implement
    // }
}
