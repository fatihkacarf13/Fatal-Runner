using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorType

{
    Red, Yellow, Green
}

public class BaseColorable : MonoBehaviour
{
    public Material Red;
    public Material Green;
    public Material Yellow;
    [SerializeField]private ColorType colorType;
    public Renderer renderer;

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
                renderer.material = Red;
                break;
            case ColorType.Yellow:
                renderer.material = Yellow;
                break;
            case ColorType.Green:
                renderer.material = Green;
                break;
            default:
                break;
        }
    }

}
