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
    private Slider progressSlider;

    [Header("Panels")]
    [SerializeField]
    private GameObject winPanel;

    [SerializeField]
    private GameObject losePanel;

    [Header("Buttons")]
    [SerializeField]
    private Button nextLevelButton;

    [SerializeField]
    private Button restartLevelButton;

    [SerializeField]
    private Button quitButton;

    [Header("Text fields")]
    [SerializeField]
    private TMP_Text currentLevelText;

    [SerializeField]
    private TMP_Text nextLevelText;

    private void Start()
    {
        EventManager.FloorHit.AddListener(() => ShowMenu(true));
        EventManager.UnbreakableHit.AddListener(() => ShowMenu(false));

        EventManager.BreakableHit.AddListener(UpdateSliderValue);

        nextLevelButton.onClick.AddListener(() => LoadLevel(true));
        restartLevelButton.onClick.AddListener(() => LoadLevel(false));

        quitButton.onClick.AddListener(() => { Application.Quit(); });

        UpdateTextFields();
        UpdateSliderValue();
    }

    private void ShowMenu(bool isLevelFinished)
    {
        quitButton.gameObject.SetActive(true);

        if (isLevelFinished)
        {
            progressSlider.value = progressSlider.maxValue;
            winPanel.SetActive(true);
        }
        else losePanel.SetActive(true);
    }

    private void LoadLevel(bool isLevelNew)
    {
        quitButton.gameObject.SetActive(false);

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
        progressSlider.minValue = 0;
        progressSlider.maxValue = ProgressTracker.ObstaclesAmount;
        progressSlider.value = ProgressTracker.ObstaclesBroken;
    }
}
