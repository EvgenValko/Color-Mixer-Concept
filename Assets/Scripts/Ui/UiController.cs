using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private FruitsPanel _fruitsPanel;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private TextMeshProUGUI _winText;
    [SerializeField] private TextMeshProUGUI _failText;

    private LevelLauncher _levelLauncher;
    public FruitsPanel FruitsPanel { get => _fruitsPanel; }

    public void Init(LevelLauncher levelLauncher)
    {
        _levelLauncher = levelLauncher;
        _startButton.onClick.AddListener(LevelStart);
        _restartButton.onClick.AddListener(LevelReStart);
    }

    public void LevelWin(int matching)
    {
        _fruitsPanel.HideFruitsButton();
        _winText.gameObject.SetActive(true);
        _winText.text = $"Matching {matching} %";
        _startButton.gameObject.SetActive(true);
    }

    public void LevelFail(int matching)
    {
        _fruitsPanel.HideFruitsButton();
        _failText.gameObject.SetActive(true);
        _failText.text = $"Matching {matching} %";
        _restartButton.gameObject.SetActive(true);
    }

    private void LevelStart()
    {
        _levelLauncher.LevelStart();
        _startButton.onClick.RemoveAllListeners();
        _startButton.onClick.AddListener(NextLevelStart);
        _startButton.gameObject.SetActive(false);
    }

    private void LevelReStart()
    {
        _levelLauncher.LevelStart();
        _restartButton.gameObject.SetActive(false);
        _failText.gameObject.SetActive(false);
    }

    private void NextLevelStart()
    {
        _levelLauncher.NextLevelStart();
        _startButton.gameObject.SetActive(false);
        _winText.gameObject.SetActive(false);
    }
}
