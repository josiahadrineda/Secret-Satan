using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Reputation.toggleMusic)
        {
            GameObject.FindGameObjectWithTag("BGM").GetComponent<BGM>().PlayMusic();
        }
        else
        {
            GameObject.FindGameObjectWithTag("BGM").GetComponent<BGM>().PauseMusic();
        }
    }
}
