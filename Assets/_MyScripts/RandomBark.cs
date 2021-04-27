using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBark : MonoBehaviour
{

    public AudioClip[] barks;
    public AudioClip curBark;
    public AudioSource myAudio;

    float rngTimer = 5;

    // Update is called once per frame
    void FixedUpdate()
    {

        rngTimer -= 1 * Time.deltaTime;

        if (rngTimer < 0)
        {

            int chooseBark = Random.Range(0, barks.Length);
            curBark = barks[chooseBark];

            myAudio.clip = barks[chooseBark];

            myAudio.PlayOneShot(curBark);
            

            rngTimer = Random.Range(3,10);


        }




    }
}
