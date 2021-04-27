using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyState : MonoBehaviour            // The AI
{
    // Start is called before the first frame update
    void Start()
    {
        seekScr = GetComponent<Seek>();
        arriveScr = GetComponent<Arrive>();

        StartCoroutine(RunAI(0.5f));

    }

    


    IEnumerator RunAI(float waitTime)
    {

        while (true)
        {

            yield return new WaitForSeconds(waitTime);

            AIDecisionTree();

            Debug.Log("TEST");

        }



    }


   // int state = 0;

   public Seek seekScr;
   public Arrive arriveScr;

   public GameObject myBall;
   public GameObject myPlayer;

    public Transform holdPoint;

    void ChangeState(int state)
    {


        switch (state)
        {


            case 0:         // go to ball

                seekScr.enabled = true;
                arriveScr.enabled = false;

                break;


            case 1:         // go to player

                seekScr.enabled = false;
                arriveScr.enabled = true;

                break;

            


        }

    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Ball") && myBall.GetComponent<BallGrab>().thrown)
        {
            var myRB = other.GetComponent<Rigidbody>();

            other.transform.parent = holdPoint;
            other.transform.position = holdPoint.transform.position;

            

            other.GetComponent<BallGrab>().thrown = false;
            myRB.useGravity = false;
            myRB.drag = 10;
            
        }


    }


    void DropBall()
    {

        myBall.transform.parent = null;

        var myRB = myBall.GetComponent<Rigidbody>();
        myRB.drag = 0;
        myRB.useGravity = true;

    }


    public bool AIOn = true;

    void AIDecisionTree()
    {

        float dist = Vector3.Distance(transform.position,myPlayer.transform.position);

        if (AIOn)
        {

            if (myBall.GetComponent<BallGrab>().thrown && myBall.transform.parent == null)  // chase ball
            {

                //  myBall.GetComponent<BallGrab>().thrown = false;

                ChangeState(0);

            }
            else    // go to player
            {

                ChangeState(1);


                if (dist < 7)   // if close enough drop ball
                {

                    DropBall();

                }



            }






        }


    }


}
