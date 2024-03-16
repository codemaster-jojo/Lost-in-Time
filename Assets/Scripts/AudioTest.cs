using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    private void Update()
    {
        //Because the AudioManager is a singleton, simple use "AudioManager.instance" to call it
        //Run the Play() function
        //Use the same name from the Sounds array in the inspector
        //Example:
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.instance.Play("Collect Point");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            AudioManager.instance.Play("Win Jingle");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Try adding your own sound effect here:
        }
    }
}
