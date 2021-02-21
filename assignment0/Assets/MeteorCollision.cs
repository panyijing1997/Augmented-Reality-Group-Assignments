using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 meteorPosition = GameObject.FindGameObjectWithTag("Meteor").transform.position;
        Vector3 meteorScale = GameObject.FindGameObjectWithTag("Meteor").transform.lossyScale;
        Vector3 earthPosition = GameObject.FindGameObjectWithTag("Earth").transform.position;
        Vector3 earthScale = GameObject.FindGameObjectWithTag("Earth").transform.lossyScale;
        float distance = Vector3.Distance(meteorPosition, earthPosition);
        float radiusSum = meteorScale[0] + earthScale[0]; // sum of radius
        if (distance < radiusSum)
        {
            Debug.Log("Distance:"+ distance + "     RadiusSum:" + radiusSum);
            Debug.Log("Collision!");
        }
    }


}
