using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    //If AudioManager will be referenced frequently, make a reference from inspector like so:
    [SerializeField] AudioManager audioManager;

    private void Update()
    {
        //Run the Play() function using the audioManager reference
        //Use the same name from the Sounds array in the inspector
        //Example:
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioManager.Play("Collect Point");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //If AudioManager won't be referenced frequently, simply doing this is fine as well:
            FindObjectOfType<AudioManager>().Play("Win Jingle");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Try adding your own sound effect here:
        }
    }
}
