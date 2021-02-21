using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIghtCanno : MonoBehaviour
{
    public float lineLength = 0.15f;
    private bool shoot = false;
    public LineRenderer lr;
    public Vector3 localPos;
    private Vector3 boomIniPos;
    private Vector3 cannonPos;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        localPos = new Vector3(0.008f, 0, 0.030f); //w.r.t. the shooter
        boomIniPos = new Vector3(10, 10, 10);
    }

    // Update is called once per frame
    void Update()
    {

        //Find the position and rotation of the shooter;
        GameObject shooter = GameObject.Find("ShooterTarget");
        Vector3 shooterPos = shooter.transform.position;
        Quaternion shooterRotation = shooter.transform.rotation;
        Vector3 angles = shooterRotation.eulerAngles;

        //tanslation and rotation for left cannon
        Matrix4x4 t = T(shooterPos[0], shooterPos[1], shooterPos[2]);
        Matrix4x4 r = Matrix4x4.TRS(new Vector3(0, 0, 0), shooterRotation, new Vector3(1, 1, 1));
        Matrix4x4 m = t * r;
        cannonPos = m.MultiplyPoint3x4(localPos);

        //adjust the direction of the laser
        transform.eulerAngles = angles;
        Vector3 direction = transform.forward;

        GameObject boom = GameObject.Find("ExplosionR");
        if (Input.GetKeyDown("e"))
        {
            if (shoot)
                shoot = false;
            else
                shoot = true;
        }

        if (shoot)
        {
            RaycastHit hit;
            DrawLine(cannonPos, direction * lineLength + cannonPos, 0.005f);
            if (Physics.Raycast(cannonPos, direction, out hit, lineLength))
            {
                boom.transform.position = hit.point;
                // Debug.Log("Did Hit");
            }
            else
            {
                boom.transform.position = boomIniPos;

            }
        }
        else
        {
            DrawLine(cannonPos, cannonPos);
            boom.transform.position = boomIniPos;
        }


    }
    void DrawLine(Vector3 start, Vector3 end, float lineWidth = 0.01f)
    {

        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
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
