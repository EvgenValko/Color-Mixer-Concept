using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Blender : MonoBehaviour
{
    [SerializeField] private BlenderButton _blenderButton;
    [SerializeField] private BlenderCover _blenderCover;
    [SerializeField] private Transform _rotateTransform;
    [SerializeField] private Smoothie _smoothie;

    private Config _config;
    private LevelConfig _levelConfig;
    private GameManager _gameManager;
    private BlenderConfig _blenderConfig;
    private List<Color> _colors = new List<Color>();
    private Queue<FruitView> _fruitViews = new Queue<FruitView>();
    public Color ColorResult;
    private Bezier _bezier;
    private bool _isBleding;

    public void Init(Bezier bezier, Config config, GameManager gameManager)
    {
        _gameManager = gameManager;
        _config = config;
        _bezier = bezier;
        _blenderConfig = _config.BlenderConfig;
        _blenderButton.OnClick += Blend;
    }

    public void InitNewLevel(LevelConfig levelConfig)
    {
        _levelConfig = levelConfig;
        _smoothie.HideSmoothie();
        _colors.Clear();
        _isBleding = false;
    }

    private void Blend()
    {
        if (!_blenderCover.IsOpen && !_isBleding)
        {
            _isBleding = true;
            foreach (var fruitView in _fruitViews)
            {
                fruitView.EnableKinematic();
                fruitView.Disappear(_blenderConfig.BlendDuration /2);
            }
            _smoothie.ShowSmoothie(ColorResult, _blenderConfig.BlendDuration);
            _fruitViews.Clear();
            _rotateTransform.DORotate(Vector3.up * _blenderConfig.BlendSpeed, _blenderConfig.BlendDuration, RotateMode.FastBeyond360)
                .OnComplete(() =>
                {
                    float matching = ColorUtil.ColorMatching(ColorResult, _levelConfig.Color);
                    _gameManager.Match((int)(matching * 100));
                });
        }
    }

    public void AddFruit(Fruit fruit)
    {
        if (!_isBleding)
        {
            _smoothie.HideSmoothie();
            _blenderCover.Open();
            _colors.Add(fruit.Color);
            ColorResult = ColorUtil.MixColor(_colors.ToArray());
            FruitView fruitView = Instantiate(fruit.Prefab, _rotateTransform);
            fruitView.Init(_bezier, _config);
            _fruitViews.Enqueue(fruitView);

            if (_fruitViews.Count > _blenderConfig.MaxFruitsInBlender)
                Destroy(_fruitViews.Dequeue().gameObject);
        }
    }
}