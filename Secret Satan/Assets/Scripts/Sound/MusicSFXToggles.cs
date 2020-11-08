using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MusicSFXToggles : MonoBehaviour
{
    public Sprite checkedSprite;
    public Sprite uncheckedSprite;

    GameObject musicToggleSprite;
    GameObject sfxToggleSprite;

    void Start()
    {
        if (gameObject.name == "Music Toggle")
        {
            musicToggleSprite = transform.GetChild(0).gameObject;
        }
        else
        {
            sfxToggleSprite = transform.GetChild(0).gameObject;
        }
    }

    void OnMouseDown()
    {
        if (gameObject.name == "Music Toggle")
        {
            GlobalVars.toggleMusic = !GlobalVars.toggleMusic;

            if (GlobalVars.toggleMusic)
            {
                musicToggleSprite.GetComponent<Image>().sprite = checkedSprite;
            }
            else
            {
                musicToggleSprite.GetComponent<Image>().sprite = uncheckedSprite;
            }
        }
        else
        {
            GlobalVars.toggleSfx = !GlobalVars.toggleSfx;

            if (GlobalVars.toggleSfx)
            {
                sfxToggleSprite.GetComponent<Image>().sprite = checkedSprite;
            }
            else
            {
                sfxToggleSprite.GetComponent<Image>().sprite = uncheckedSprite;
            }
        }
    }
}
