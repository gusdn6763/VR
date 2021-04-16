using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    public GameObject menuButton;
    public GameObject chooseStage;

    public SettingView setting;

    private void Start()
    {
        GameManager.instance.MenuScene();
        setting.MusicOn(SoundManager.instance.bgmIsOn);
        setting.SoundOn(SoundManager.instance.soundIsOn);
    }

    public void StartButton()
    {
        menuButton.SetActive(false);
        chooseStage.SetActive(true);
    }

    public void StartCancleButton()
    {
        menuButton.SetActive(true);
        chooseStage.SetActive(false);
    }

    public void SettingButton()
    {
        setting.Open();
    }


    public void Quit()
    {
        Application.Quit();
    }
}
