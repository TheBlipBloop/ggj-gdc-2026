using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Scriptable Objects/Card")]
public class Card : ScriptableObject
{
    public Texture2D FrontTexture { get; private set; }

    public Texture2D BackTexture { get; private set; }

    public int Name { get; private set; }

    public string Description { get; private set; }

}
