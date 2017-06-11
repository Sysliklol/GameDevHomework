using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

using UnityEngine;

public class MusicOn : MonoBehaviour {

    public UI2DSprite Button;
    public MusicOn playButton;
    public UnityEvent signalOnClick = new UnityEvent();


    public void _onClick()
    {
        this.signalOnClick.Invoke();

    }

    void Start()
    {
        if (!MusicManager.Instance.isSoundOn())
        {
            Button.enabled = false;
        }
        playButton.signalOnClick.AddListener(this.onPlay);
    }
    public void onPlay()
    {
        MusicManager.Instance.setSoundOn(true);
        MusicOff.Instance.musicSource.Play();
        Button.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
