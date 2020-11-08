using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ReputationText : MonoBehaviour
{
    public Text reputationText;

    void Update()
    {
        reputationText.text = "x " + GlobalVars.reputation.ToString();
    }
}
