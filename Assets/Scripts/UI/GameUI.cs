using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private LevelInstantiator levelInstantiator;

    [SerializeField]
    private GameObject winPanel;

    [SerializeField]
    private GameObject losePanel;

    [SerializeField]
    private Button nextLevelButton;

    [SerializeField]
    private Button quitButton;

    [SerializeField]
    private TMP_Text currentLevelText;

    [SerializeField]
    private TMP_Text nextLevelText;

    private void Start()
    {
        EventManager.FloorHit.AddListener(LevelFinished);
        EventManager.UnbreakableHit.AddListener(LevelFailed);

        nextLevelButton.onClick.AddListener(CreateNextLevel);
        quitButton.onClick.AddListener(() => { Application.Quit(); });

        UpdateTextFields();
    }

    private void LevelFinished()
    {
        winPanel.SetActive(true);
    }

    private void LevelFailed()
    {
        losePanel.SetActive(true);
    }

    private void CreateNextLevel()
    {
        EventManager.CreateNextLevel();

        UpdateTextFields();

        winPanel.SetActive(false);
    }

    private void UpdateTextFields()
    {
        currentLevelText.text = levelInstantiator.CurrentLevel.ToString();
        nextLevelText.text = (levelInstantiator.CurrentLevel + 1).ToString();
    }
}
