using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardInfo", menuName = "Scriptable Objects/CardInfo")]
public class CardInfo : ScriptableObject
{
    public Texture2D FrontTexture = null;
    public Texture2D BackTexture = null;
    public string Name = "card";
    public Sprite cardImage;
    [TextArea] public string Description = "really awesome playing card";
    [SerializeField] public List<CardEffect> Effects = new List<CardEffect>();

    public Color Flash = new Color(1, 1, 1, 0.15f);

    public float FlashDecaySpeed = 10;

    public void Apply(GameState gameState)
    {
        FlashOverlay.Flash(Flash, FlashDecaySpeed);

        foreach (var effect in Effects)
        {
            effect.Apply(gameState);
        }
    }
}
