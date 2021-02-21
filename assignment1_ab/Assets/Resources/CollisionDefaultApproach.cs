using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDefaultApproach : MonoBehaviour
{
    // Start is called before the first frame update
    

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(gameObject.name);
        }
    }
    //If your GameObject starts to collide with another GameObject with a Collider
    void OnCollisionEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        if (collision.collider.name == "Earth")
        {
            Debug.Log(gameObject.name+" Collision with " + collision.collider.name);
        }     
    }
    void OnTriggerEnter(Collider collider)
    {
        //Output the Collider's GameObject's name
        if (collider.name == "Earth")
        {
            Debug.Log(gameObject.name + " Collision with " + collider.name);
        }
    }
}
