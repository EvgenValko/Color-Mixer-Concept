using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlenderButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float _moveDown;
    [SerializeField] private float _durition;
    private Vector3 _startPos;

    public event Action OnClick;

    private void Start()
    {
        _startPos = transform.position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOMove(_startPos - transform.up * _moveDown, _durition);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOMove(_startPos, _durition);
    }
}