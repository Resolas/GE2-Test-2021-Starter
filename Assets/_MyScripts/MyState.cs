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

            other.transform.parent = holdPoint;
            other.transform.position = holdPoint.transform.position;

            other.GetComponent<BallGrab>().thrown = false;

        }


    }


    public bool AIOn = true;

    void AIDecisionTree()
    {


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

            }

        }


    }


}
