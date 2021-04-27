using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailWag : MonoBehaviour
{
    

    public Boid GetBoid;
    public float wagSpeed = 100f;

    Quaternion myRotation;
    

    // Update is called once per frame
    void FixedUpdate()
    {

        WagTail();

    }

    void WagTail()
    {

        float getAccel = GetBoid.acceleration.magnitude;


        myRotation = new Quaternion(0,Mathf.Sin(Time.time) * wagSpeed,0,0);


        transform.rotation = myRotation;


   /*
        public float wagSpeed;
        private float wait;

        private void Update()
        {
            float angle = Mathf.Sin(Time.time) * 70;

            this.transform.rotation = Quaternion.Euler(0, angle, 0);

            Debug.Log(angle);
        }
    */

}
}
