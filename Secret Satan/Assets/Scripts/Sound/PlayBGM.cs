using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    void Update()
    {
        if (GlobalVars.toggleMusic)
        {
            GetComponent<BGM>().PlayMusic();
        }
        else
        {
            GetComponent<BGM>().PauseMusic();
        }
    }
}
