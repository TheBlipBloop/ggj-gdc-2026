using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Scriptable Objects/Card")]
public class Card : ScriptableObject
{
    public Texture2D FrontTexture = null;
    public Texture2D BackTexture = null;
    public string Name = "card";
    public string Description = "really awesome playing card";
}
