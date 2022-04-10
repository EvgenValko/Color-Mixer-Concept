using UnityEngine;
using UnityEngine.UI;

public class FruitButton : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Button _button;
    [SerializeField] private RectTransform _rectTransform;

    private Fruit _fruit;
    private Blender _blender;
    private float _timeBlock;

    public void Init(Fruit fruit, float xPos, Blender blender)
    {
        _blender = blender;
        gameObject.SetActive(true);
        _fruit = fruit;
        _image.sprite = _fruit.Sprite;
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(AddFruit);
        _rectTransform.localPosition = new Vector3(xPos, 0, 0);
    }

    private void Update()
    {
        _timeBlock -= Time.deltaTime;
    }

    private void AddFruit()
    {
        if (_timeBlock < 0)
        {
            _blender.AddFruit(_fruit);
            _timeBlock = 0.2f;
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
