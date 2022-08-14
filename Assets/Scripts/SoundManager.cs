using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public bool isSound
    {
        get { return _isSound; }
        set { _isSound=value; bg.mute=value;}
    }
    private bool _isSound;
    public bool isVibration;
    public float music, sound;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public AudioSource click, bg, gameOver, gameWin, air, startGame;

    void Start()
    {
        isSound = PlayerPrefs.GetInt("Sound") == 1;
        click.Play();
    }
    void OnSoundVolumeChange()
    {
        startGame.volume = click.volume * sound;
        gameWin.volume = click.volume * music;
        gameOver.volume = click.volume * music;
        click.volume = click.volume * sound;
    }
    void OnMusicVolumeChange()
    {
        bg.volume = click.volume * music;
        // click.volume = click.volume*music;
        // click.volume = click.volume*music;

    }
}
