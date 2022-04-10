using System.Collections.Generic;
using UnityEngine;

public class FruitsPanel : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;

    private Queue<FruitButton> _fruitButtons = new Queue<FruitButton>();
    private List<FruitButton> _activeFruitButtons = new List<FruitButton>();

    public void CreateFruitsButton(LevelConfig levelConfig, Config config, Blender blender)
    {
        gameObject.SetActive(true);
        float step = 1080f / (levelConfig.Fruits.Length + 1);
        float xPos = -540;

        foreach (var fruit in levelConfig.Fruits)
        {
            FruitButton fruitButton;
            if (_fruitButtons.Count > 0)
                fruitButton = _fruitButtons.Dequeue();
            else
                fruitButton = Instantiate(config.FruitButtonPrefab, _rectTransform);

            _activeFruitButtons.Add(fruitButton);
            xPos += step;

            fruitButton.Init(fruit, xPos, blender);
        }
    }

    public void HideFruitsButton()
    {
        foreach (var fruitButton in _activeFruitButtons)
        {
            fruitButton.Hide();
            _fruitButtons.Enqueue(fruitButton);
        }
        _activeFruitButtons.Clear();
        gameObject.SetActive(false);
    }
}
