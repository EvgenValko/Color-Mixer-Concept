using DG.Tweening;
using UnityEngine;

public class BlenderCover : MonoBehaviour
{
    [SerializeField] private float _openAngle;
    [SerializeField] private float _openDuration;
    [SerializeField] private float _closeDuration;
    [SerializeField] private float _closeTimeBlock;

    private Vector3 _startRotate;
    private float _timeBlock;
    private bool _isOpen;

    public bool IsOpen { get => _isOpen; }

    private void Start()
    {
        _startRotate = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        _timeBlock -= Time.deltaTime;
        Close();
    }

    public void Open()
    {
        transform.DOKill();
        transform.DORotate(_startRotate - Vector3.forward * _openAngle, _openDuration);
        _isOpen = true;
        _timeBlock = _closeTimeBlock;
    }

    private void Close()
    {
        if (_isOpen && _timeBlock < 0)
        {
            transform.DOKill();
            transform.DORotate(_startRotate, _closeDuration);
            _isOpen = false;
        }
    }
}
