using UnityEngine;
using UnityEngine.UI;

public class ColorSquare : MonoBehaviour
{
    public Image image;
    public ColorType currentColor;

    public Color yellow, green, blue, red;

    void Start()
    {
        SetColor(ColorType.Yellow);
    }

    public void CycleColor()
    {
        currentColor = (ColorType)(((int)currentColor + 1) % 4);
        SetColor(currentColor);
    }

    void SetColor(ColorType type)
    {
        Color c = Color.white;

        switch (type)
        {
            case ColorType.Yellow:
                c = yellow;
                break;
            case ColorType.Green:
                c = green;
                break;
            case ColorType.Blue:
                c = blue;
                break;
            case ColorType.Red:
                c = red;
                break;
        }

        c.a = 1f;
        image.color = c;
    }
}
