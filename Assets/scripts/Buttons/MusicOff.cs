using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

using UnityEngine;

public class MusicOff : MonoBehaviour {

    public AudioClip music = null;
    public AudioSource musicSource = null;
    public UI2DSprite Button;
    public MusicOff playButton;
    public UnityEvent signalOnClick = new UnityEvent();


    public void _onClick()
    {
        this.signalOnClick.Invoke();

    }

    void Start()
    {
        if (MusicManager.Instance.isSoundOn())
        {
            Button.enabled = true;
            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.clip = music;
            musicSource.loop = true;
            musicSource.Play();
        }
        playButton.signalOnClick.AddListener(this.onPlay);
    }
    public void onPlay()
    {
        MusicManager.Instance.setSoundOn(true);
        {
            MusicManager.Instance.setSoundOn(false);
            musicSource.Stop();
        }
        Button.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {

    }
    public static MusicOff Instance = new MusicOff();
}
