using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReputationText : MonoBehaviour
{
    public Text reputationText;

    // Update is called once per frame
    void Update()
    {
        reputationText.text = "x " + Reputation.reputation.ToString();
    }
}
