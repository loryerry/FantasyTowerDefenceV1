using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GraphicsSettings : MonoBehaviour
{
    public TMP_Dropdown resolutionDropDown;
    Resolution[] resolutions;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetResolustion(int reslustionIndex)
    {
        Resolution resolution = resolutions[reslustionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);


    }
    public void SetQuality(int QualityIndex)
    {

        QualitySettings.SetQualityLevel(QualityIndex);

    }

    public void SetFullScreen(bool FullScreen)
    {

        Screen.fullScreen = FullScreen;

    }
}
