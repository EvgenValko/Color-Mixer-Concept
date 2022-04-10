using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UiController _uiController;
    [SerializeField] private Config _config;
    [SerializeField] private Bezier _bezier;
    [SerializeField] private Blender _blender;
    [SerializeField] private TemplateColor _templateColor;

    private LevelLauncher LevelLauncher;

    private void Start()
    {
        _blender.Init(_bezier, _config, this);
        LevelLauncher = new LevelLauncher(_config, _uiController.FruitsPanel, _blender, _templateColor);
        _uiController.Init(LevelLauncher);
    }

    public void Match(int matching)
    {
        if (matching > _config.MatchingToWin)
            _uiController.LevelWin(matching);
        else
            _uiController.LevelFail(matching);
    }
}
