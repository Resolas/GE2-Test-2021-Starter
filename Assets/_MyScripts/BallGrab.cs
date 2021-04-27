using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGrab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        myRB = GetComponent<Rigidbody>();

    }


    public bool selected;
    public Transform gotoPoint;
    public Rigidbody myRB;
    public float mytime = 1;

    // Update is called once per frame
    void Update()
    {

        if (selected)
        {

            transform.position =  Vector3.Lerp(transform.position, gotoPoint.position, mytime * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation,gotoPoint.rotation,mytime*2 * Time.deltaTime);
            myRB.useGravity = false;
        }
        else
        {
            myRB.useGravity = true;


        }


    }
}