using UnityEngine;

[CreateAssetMenu(menuName = "Config", fileName = "Config")]
public class Config : ScriptableObject
{
    [SerializeField] private LevelConfig[] _levels;  
    [SerializeField] private BlenderConfig _blenderConfig;
    [Space]
    [SerializeField] private FruitButton _fruitButtonPrefab;
    [SerializeField] private float _fruitMoveDuration;
    [SerializeField] private int _matchingToWin;

    public LevelConfig[] Levels { get => _levels; }
    public BlenderConfig BlenderConfig { get => _blenderConfig; }
    public FruitButton FruitButtonPrefab { get => _fruitButtonPrefab; }
    public float FruitMoveDuration { get => _fruitMoveDuration; }
    public int MatchingToWin { get => _matchingToWin; }
}