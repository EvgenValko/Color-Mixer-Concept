using UnityEngine;

[CreateAssetMenu(menuName = "Fruit", fileName = "Fruit")]
public class Fruit : ScriptableObject
{
    [SerializeField] private Color _color;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private FruitView _prefab;

    public Color Color { get => _color; }
    public Sprite Sprite { get => _sprite; }
    public FruitView Prefab { get => _prefab; }
}
