using UnityEngine;
using UnityEngine.UI;

public class TemplateColor : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void SetColor(Color color)
    {
        _image.color = color;
    }
}
