using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
        //    Debug.Log("CLICK");
            GetBall();

        }

        //   GetBall();

    }


    public Camera myCam;
    public float throwStrength = 10f;

    void GetBall()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position,myCam.transform.forward,out hit,Mathf.Infinity,1))
        {

        //    Debug.Log(hit.transform.name + "TEST");

            if (hit.collider.CompareTag("Ball"))
            {

                BallGrab myBall = hit.collider.GetComponent<BallGrab>();
                Rigidbody myBallRB = hit.collider.GetComponent<Rigidbody>();

                if (myBall.selected == true)
                {

                    myBall.selected = false;
                    myBall.thrown = true;
                    myBallRB.velocity = transform.forward * throwStrength;
                    myBall.transform.parent = null;
                }
                else if (myBall.selected == false)
                {

                    myBall.selected = true;

                }


            }


        }

        


    }



        

            
    

    


}
