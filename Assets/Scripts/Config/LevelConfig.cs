using System;
using UnityEngine;

[Serializable]
public class LevelConfig
{
    [SerializeField] private Fruit[] _fruits;
    [SerializeField] private Color _color;

    public Fruit[] Fruits { get => _fruits; }
    public Color Color { get => _color; }
}
