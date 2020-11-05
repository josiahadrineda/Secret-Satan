using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Reputation
{
    public static int reputation = 3;

    public static GameObject answer;
    public static GameObject selection;

    public static bool eventInProgress;
    public static bool tutorialHoveredException;
    public static bool tutorialOutlineException;
    public static bool tutorialSideTriggerException;

    public static bool allowSelection = false;
    public static bool selectedTableOnce = false;

    public static bool toggleMusic = true;
    public static bool toggleSfx = true;

    public static bool fade = false;
}