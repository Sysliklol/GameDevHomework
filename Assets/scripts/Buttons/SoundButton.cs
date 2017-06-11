using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class SoundButton : MonoBehaviour {

    public UI2DSprite Button;
    public SoundButton playButton;
    public UnityEvent signalOnClick = new UnityEvent();


    public void _onClick()
    {
        this.signalOnClick.Invoke();

    }

    void Start()
    {
        if (!SoundManager.Instance.isSoundOn())
        {
            Button.enabled = false;
        }
        playButton.signalOnClick.AddListener(this.onPlay);
    }
    public void onPlay()
    {
        SoundManager.Instance.setSoundOn(false);
        Button.enabled = false;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
