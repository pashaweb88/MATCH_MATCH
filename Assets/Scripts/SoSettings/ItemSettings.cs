using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Item", fileName = "Item")]
public class ItemSettings : ScriptableObject
{
    [SerializeField] private Sprite image;
    [SerializeField] private Sprite effectImage;
    [SerializeField] private string tag;
    public Sprite GetImage()
    {
        return image;
    }

    public Sprite GetEffectImage()
    {
        return effectImage;
    }

    public string GetTag()
    {
        return tag;
    }
}
