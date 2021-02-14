using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotate_1 : MonoBehaviour
{
    static float alpha;
    static float theta;
 
    void Start()
    {
        alpha = 0;
        theta = 0;
    }
    void Update()
    {
  
        Vector3 moonIniPos = new Vector3(-1, 0, 0);
        Vector3 earthIniPos = new Vector3(-2, 0, 0);
        alpha +=10 * Time.deltaTime; //speed for the Moon
        theta +=  Time.deltaTime; //Speed for the Earth

        // for the Earth
        GameObject earth = GameObject.Find("Earth");
        Matrix4x4 scalingEarth = S(1, 1, 2);
        Matrix4x4 rotateEarth =  Ry(theta);
        Matrix4x4 aEarth = scalingEarth * rotateEarth;
        earth.transform.position = aEarth*earthIniPos;
        earth.transform.Rotate(0,- 1, 0);
     

        //for the Moon
        Vector3 earthPos = GameObject.Find("Earth").transform.position;        
        Matrix4x4 translateMoon = T(earthPos[0], earthPos[1], earthPos[2]);
        Matrix4x4 rotateMoon = Ry(alpha);
        Matrix4x4 aMoon = translateMoon * rotateMoon;
        transform.position = aMoon.MultiplyPoint3x4(moonIniPos);
        /*
         note: if not using MultiplyPoint, moonInitPos should be expanded to Vector4 first, \
        otherwise the last colum of aMoon would not work for moonIniPos.
         Or: explicitly add the translation after rotation. see following:
       */

        /*
        transform.position = aMoon*moonIniPos;
        Vector3 tanslation = new Vector3(aMoon[0,3], aMoon[1,3], aMoon[2,3]);
       transform.position = transform.position + tanslation;
        */
        transform.Rotate(0, 1, 0);
        

        //For the Sun
        GameObject sun =GameObject.Find("Sun");
        sun.transform.Rotate(0,1,0);

        Debug.Log(Vector3.Distance(earth.transform.position, transform.position));
        
        /* Vector3 earthPos = GameObject.Find("Earth").transform.position;
         Matrix4x4 translate = T(earthPos[0], earthPos[1], earthPos[2]);
         Matrix4x4 a = translate * Ry(10 * Time.deltaTime) * translate.inverse;
         transform.position = a.MultiplyPoint(transform.position);
         float dist = Vector3.Distance(earthPos, transform.position);
         Debug.Log(dist);
        */
        //pivot approach. Prolem: earth not on the center of the moon's orbit.
    }

    public static Matrix4x4 S(float x, float y, float z)
     {
         Matrix4x4 m = new Matrix4x4();
        m.SetRow(0, new Vector4(x, 0, 0, 0));
        m.SetRow(1, new Vector4(0, y, 0, 0));
        m.SetRow(2, new Vector4(0, 0, z, 0));
        m.SetRow(3, new Vector4(0, 0, 0, 1));

        return m;

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

