using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button worldSpaceButton;
    [SerializeField] Text worldSpaceText;
    [SerializeField] private Button activateScreenSpaceCameraCanvasButton;
    [SerializeField] private GameObject screenSpaceCameraCanvas;
    [SerializeField] private Button screenSpaceCameraButton;
    private void Start()
    {
        worldSpaceButton.onClick.AddListener(() =>
        {
            worldSpaceText.text = "World Space Canavs\nButton Clicked";
        });
        activateScreenSpaceCameraCanvasButton.onClick.AddListener(() =>
        {
            screenSpaceCameraCanvas.SetActive(true);
        });

        screenSpaceCameraButton.onClick.AddListener(() =>
        {
            screenSpaceCameraCanvas.SetActive(false);
        });
    }
}
