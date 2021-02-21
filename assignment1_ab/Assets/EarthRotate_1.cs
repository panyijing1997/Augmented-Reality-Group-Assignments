using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRotate_1 : MonoBehaviour
{
    private Vector3 earthPosition;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position);
    }
 
    // Update is called once per frame
    void Update()
    {
        /*Vector3 iniPos = new Vector3(-2, 1, 0);
        alpha = alpha + 10 * Time.deltaTime;
        Matrix4x4 a = Ry(alpha);
        transform.position = a.MultiplyPoint(transform.position);

        transform.position = a.MultiplyPoint(iniPos);
        */

        
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

    public static Matrix4x4 Rx(float a)
    {
        Matrix4x4 m = new Matrix4x4();

        m.SetRow(0, new Vector4(1, 0, 0, 0));
        m.SetRow(1, new Vector4(0, Mathf.Cos(a), -Mathf.Sin(a), 0));
        m.SetRow(2, new Vector4(0, Mathf.Sin(a), Mathf.Cos(a), 0));
        m.SetRow(3, new Vector4(0, 0, 0, 1));

        return m;
    }

    public static Matrix4x4 Ry(float a)
    {
        Matrix4x4 m = new Matrix4x4();

        m.SetRow(0, new Vector4(Mathf.Cos(a), 0, Mathf.Sin(a),0));
        m.SetRow(1, new Vector4(0, 1, 0, 0));
        m.SetRow(2, new Vector4( -Mathf.Sin(a), 0, Mathf.Cos(a),0));
        m.SetRow(3, new Vector4(0, 0, 0, 1));

        return m;
    }

    public static Matrix4x4 Rz(float a)
    {
        Matrix4x4 m = new Matrix4x4();

        m.SetRow(0, new Vector4(Mathf.Cos(a), -Mathf.Sin(a), 0, 0));
        m.SetRow(1, new Vector4(Mathf.Sin(a), Mathf.Cos(a), 0, 0));
        m.SetRow(2, new Vector4(0, 0, 1, 0));
        m.SetRow(3, new Vector4(0, 0, 0, 1));

        return m;
    }
}
