using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGameOrDead : MonoBehaviour
{
    public SceneFlow sceneFlow;
    public ToggleOutlines toggleOutlines;
    public UIBehavior uiBehavior;

    public void ContinueGameOrDeadHelper()
    {
        if (Reputation.reputation == 0)
        {
            sceneFlow.Invoke("GameOver", 0f);
        }
        else
        {
            toggleOutlines.Invoke("EnableOutlines", 0f);
            uiBehavior.Invoke("HideIncorrectPanel", 0f);
            uiBehavior.Invoke("EnableOptionsTrigger", 0f);
            uiBehavior.Invoke("EnableOptionsButton", 0f);
            uiBehavior.Invoke("EnableQuitButton", 0f);
            uiBehavior.Invoke("DisplayThoughtPanel", 0f);
            uiBehavior.Invoke("DisplayHoveredPanel", 0f);
        }
    }
}
