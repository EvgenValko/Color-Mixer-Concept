using DG.Tweening;
using UnityEngine;

public class FruitView : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Renderer _renderer;
    private Bezier _bezier;
    private Config _config;

    public void Init(Bezier bezier, Config config)
    {
        _config = config;
        _bezier = bezier;
        Move();
    }

    public void EnableKinematic()
    {
        _rigidbody.isKinematic = true;
    }

    public void Disappear(float duration)
    {
        _renderer.material.DOFade(0, duration).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }

    private void Move()
    {
        transform.position = _bezier.GetStartPos;
        transform.DOPath(_bezier.GetPass(), _config.FruitMoveDuration).OnComplete(() =>
        {
            _rigidbody.isKinematic = false;
        });
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out FruitView fruitView))
        {
            transform.DOKill();
            _rigidbody.isKinematic = false;
        }
    }
}
