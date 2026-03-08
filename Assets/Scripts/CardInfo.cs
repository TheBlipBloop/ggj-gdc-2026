using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CardInfo", menuName = "Scriptable Objects/CardInfo")]
public class CardInfo : ScriptableObject
{
    public Texture2D FrontTexture = null;
    public Texture2D BackTexture = null;
    public string Name = "card";
    public string Description = "really awesome playing card";
}
