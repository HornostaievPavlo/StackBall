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

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        ApplyColorPalette(true);

        EventManager.LevelRegenerated.AddListener(ApplyColorPalette);
    }

    private void ApplyColorPalette(bool isLevelNew)
    {
        if (!isLevelNew) return;

        int randomColor = Random.Range(0, colors.Length);

        StartCoroutine(ApplyColorForBreakables(randomColor));
        StartCoroutine(ApplyColorForFloor(randomColor));

        ApplyColorForCameraBackground(randomColor);

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

    private void ApplyColorForCameraBackground(int colorIndex)
    {
        Color.RGBToHSV(colors[colorIndex], out float h, out float s, out float v);
        float desaturationValueNormalized = 0.1f;
        s *= desaturationValueNormalized;

        var desaturatedColor = Color.HSVToRGB(h, s, v);

        mainCamera.backgroundColor = desaturatedColor;
    }

    private void ApplyColorForUI(int colorIndex)
    {
        foreach (var image in targetImages)
        {
            image.color = colors[colorIndex];
        }
    }
}
