using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    #region singleton
    public static UiManager instance;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;

        }
    }
    #endregion
    public GameObject settingPnl,playButton;
    private void Start() {
        Time.timeScale=0;
    }
    public void SettingButton()
    {
        if (settingPnl.activeInHierarchy)
        {
            settingPnl.SetActive(false);
        }
        else
        {
            settingPnl.SetActive(true);
        }
    }
    public void StartButton()
    {
        playButton.SetActive(false);
        Time.timeScale=1;
    }
    public void SoundButton()
    {
        GameManager.Instance.SoundONOFF();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}