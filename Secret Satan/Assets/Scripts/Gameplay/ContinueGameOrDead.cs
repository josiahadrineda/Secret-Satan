using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGameOrDead : MonoBehaviour
{
    public GameManager gameManager;
    public UIManager uiManager;

    public ToggleOutlines toggleOutlines;

    public void ContinueGameOrDeadHelper()
    {
        if (GlobalVars.reputation == 0)
        {
            gameManager.GameOver();
        }
        else
        {
            toggleOutlines.EnableOutlines();

            uiManager.HideIncorrectPanel();
            uiManager.EnableOptionsTrigger();
            uiManager.EnableOptionsButton();
            uiManager.EnableQuitButton();
            uiManager.DisplayThoughtPanel();
            uiManager.DisplayHoveredPanel();
        }
    }
}
