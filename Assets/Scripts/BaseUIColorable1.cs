using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUIColorable : MonoBehaviour
{
    public Color Red;
    public Color Green;
    public Color Yellow;
    [SerializeField]private ColorType colorType;
    public  Image image;

    public void SetColor(ColorType c)
    {
        colorType = c;
        UpdateColorType(); 
    }

    public ColorType GetColor()
    {
        return colorType;
    }

    private void UpdateColorType()
    {
        switch (colorType)
        {
            case ColorType.Red:
                image.color = Red;
                break;
            case ColorType.Yellow:
                image.color = Yellow;
                break;
            case ColorType.Green:
                image.color = Green;
                break;
            default:
                break;
        }
    }

}
