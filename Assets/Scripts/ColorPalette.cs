using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ColorPalette : MonoBehaviour
{
    [SerializeField]
    private Image[] targetImages;

    [SerializeField]
    private Color[] colors;

    private void Start()
    {
        EventManager.LevelRegenerated.AddListener(ApplyColorPalette);
    }

    private void ApplyColorPalette(bool isLevelNew)
    {
        if (!isLevelNew) return;

        int randomColor = Random.Range(0, colors.Length);

        StartCoroutine(ApplyColorForBreakables(randomColor));
        StartCoroutine(ApplyColorForFloor(randomColor));
        ApplyColorForUI(randomColor);
    }

    private IEnumerator ApplyColorForBreakables(int colorIndex)
    {
        yield return new WaitForEndOfFrame();

        var breakables = GetComponentsInChildren<Surface>().Where(a => a.surfaceType == SurfaceType.Breakable);

        foreach (var breakable in breakables)
        {
            var material = breakable.GetComponent<MeshRenderer>().material;
            material.color = colors[colorIndex];
        }
    }
    private IEnumerator ApplyColorForFloor(int colorIndex)
    {
        yield return new WaitForEndOfFrame();

        var floor = GameObject.Find("Floor(Clone)");
        var floorMat = floor.GetComponentInChildren<MeshRenderer>().material;

        floorMat.color = colors[colorIndex];
    }

    private void ApplyColorForUI(int colorIndex)
    {
        foreach (var image in targetImages)
        {
            image.color = colors[colorIndex];
        }
    }
}
