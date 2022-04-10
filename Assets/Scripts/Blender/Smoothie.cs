using DG.Tweening;
using UnityEngine;

public class Smoothie : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    public void ShowSmoothie(Color color, float duration)
    {
        color.a = 0;

        _renderer.material.color = color;
        _renderer.material.DOFade(1, duration);
        gameObject.SetActive(true);
    }

    public void HideSmoothie()
    {
        gameObject.SetActive(false);
    }
}
