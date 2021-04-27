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
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    int state = 0;

    Seek seekScr;
    Arrive arriveScr;



    void RunStateMachine()
    {


        switch (state)
        {


            case 0:

                

                break;


            case 1:

                break;

            case 2:

                break;


        }

    }



}
