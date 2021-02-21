using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotate1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        Vector3 earthPos = GameObject.Find("Eerth").transform.position;
        Matrix4x4 translate = T(earthPos[0], earthPos[1], earthPos[2]);
        Matrix4x4 a =   translate * Ry(5 * Time.deltaTime);
        transform.position = a.MultiplyPoint(transform.position);

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

        m.SetRow(0, new Vector4(Mathf.Cos(a), 0, Mathf.Sin(a), 0));
        m.SetRow(1, new Vector4(0, 1, 0, 0));
        m.SetRow(2, new Vector4(-Mathf.Sin(a), 0, Mathf.Cos(a), 0));
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
