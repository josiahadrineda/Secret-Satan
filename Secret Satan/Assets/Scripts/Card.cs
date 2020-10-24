using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Card", menuName="Card")]
public class Card : ScriptableObject
{
    public new string name;
    public string status;
    public string description;
    public string characterType;

    public Sprite artwork;
}
