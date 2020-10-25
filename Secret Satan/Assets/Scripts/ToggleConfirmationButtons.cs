using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleConfirmationButtons : MonoBehaviour
{
    public Button yesButton;
    public Button noButton;

    public void toggleButtons()
    {
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
    }
}
