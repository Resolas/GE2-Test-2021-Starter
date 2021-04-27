using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailWag : MonoBehaviour
{
    

    public Boid GetBoid;
    public float wagSpeed = 100f;

    Quaternion myRotation;
    private float curAngle = 0;

    // Update is called once per frame
    void FixedUpdate()
    {

    //    WagTail();            // Forget it :L

    }

    void WagTail()
    {
        curAngle++;
        float getAccel = GetBoid.acceleration.magnitude;
        float angle = Mathf.Sin(curAngle * Mathf.PI)/180;

        myRotation = new Quaternion(0,angle + curAngle,0,0);


        transform.rotation = myRotation;


   

}
}
