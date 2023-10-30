using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private LevelInstantiator levelInstantiator;

    [SerializeField]
    private Transform obstacleParent;

    [SerializeField]
    private GameObject winPanel;

    [SerializeField]
    private GameObject losePanel;

    [SerializeField]
    private Button nextLevelButton;

    [SerializeField]
    private Button restartLevelButton;

    [SerializeField]
    private Button quitButton;

    [SerializeField]
    private TMP_Text currentLevelText;

    [SerializeField]
    private TMP_Text nextLevelText;

    [SerializeField]
    private Slider progressSlider;

    private void Start()
    {
        EventManager.FloorHit.AddListener(() => ShowMenu(true));
        EventManager.UnbreakableHit.AddListener(() => ShowMenu(false));

        EventManager.BreakableHit.AddListener(UpdateSliderValue);

        nextLevelButton.onClick.AddListener(() => LoadLevel(true));
        restartLevelButton.onClick.AddListener(() => LoadLevel(false));
        quitButton.onClick.AddListener(() => { Application.Quit(); });

        UpdateTextFields();
    }

    private void ShowMenu(bool isLevelFinished)
    {
        if (isLevelFinished) winPanel.SetActive(true);
        else losePanel.SetActive(true);
    }

    private void LoadLevel(bool isLevelNew)
    {
        if (!isLevelNew)
        {
            var children = obstacleParent.GetComponentsInChildren<ObstacleCircle>();

            foreach (var child in children)
            {
                Destroy(child.gameObject);
            }
        }

        EventManager.CreateLevel(isLevelNew);

        UpdateTextFields();
        UpdateSliderValue();

        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    private void UpdateTextFields()
    {
        currentLevelText.text = levelInstantiator.CurrentLevel.ToString();
        nextLevelText.text = (levelInstantiator.CurrentLevel + 1).ToString();
    }

    private void UpdateSliderValue()
    {
        progressSlider.minValue = 1;
        progressSlider.maxValue = ProgressTracker.ObstaclesAmount;
        progressSlider.value = ProgressTracker.ObstaclesBroken;
    }
}
