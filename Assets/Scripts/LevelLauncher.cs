public class LevelLauncher
{
    private Config _config;
    private int _currentLevelIndex;
    private FruitsPanel _fruitsPanel;
    private Blender _blender;
    private TemplateColor _templateColor;

    public LevelLauncher(Config config, FruitsPanel fruitsPanel, Blender blender, TemplateColor templateColor)
    {
        _templateColor = templateColor;
        _blender = blender;
        _fruitsPanel = fruitsPanel;
        _config = config;
    }

    public void LevelStart()
    {
        LevelConfig levelConfig = _config.Levels[_currentLevelIndex];
        _templateColor.SetColor(levelConfig.Color);
        _blender.InitNewLevel(levelConfig);
        _fruitsPanel.CreateFruitsButton(levelConfig, _config, _blender);
    }

    public void NextLevelStart()
    {
        if (_currentLevelIndex == _config.Levels.Length - 1)
            _currentLevelIndex = 0;
        else
            _currentLevelIndex++;

        LevelStart();
    }
}
