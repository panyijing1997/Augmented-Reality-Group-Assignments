using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class signal_light : MonoBehaviour
{

    public GameObject SpaceShuttle;
    public GameObject LandingStrip;
    public GameObject signallight;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    float t=1;
    void Update()
    {

    // check if all three axis are aligned
    bool aligned=ifAligned(SpaceShuttle,LandingStrip);
    if(aligned)
    {
      t=0;
    }
    else
    {
      t=1;
    }
    // switch the color based on result
    Color lerpedColor = Color.Lerp(Color.green, Color.red,t);
    signallight.GetComponent<Renderer>().material.color=lerpedColor;
    }

    public bool ifAligned(GameObject a, GameObject b){
      bool if_X_Aligned=Vector3.SqrMagnitude(a.transform.right - b.transform.right) < 0.1;
      bool if_Y_Aligned=Vector3.SqrMagnitude(a.transform.up - b.transform.up) < 0.1;
      bool if_Z_Aligned=Vector3.SqrMagnitude(a.transform.forward - b.transform.forward) < 0.1;
    return if_X_Aligned&&if_Y_Aligned&&if_Z_Aligned;
 }
}
