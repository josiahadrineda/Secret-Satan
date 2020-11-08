using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public Text nameText;
    public Text statusText;
    public Text descriptionText;
    public Text characterTypeText;

    public Image artworkImage;

    void Start()
    {
        nameText.text = card.name;
        statusText.text = card.status;
        descriptionText.text = card.description;
        characterTypeText.text = card.characterType;

        artworkImage.sprite = card.artwork;
    }
}
