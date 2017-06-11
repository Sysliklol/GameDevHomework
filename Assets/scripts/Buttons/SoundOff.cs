using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class SoundOff : MonoBehaviour {

	public UI2DSprite Button;
    public SoundOff playButton;
    public UnityEvent signalOnClick = new UnityEvent();


    public void _onClick()
    {
        this.signalOnClick.Invoke();

    }

    void Start()
    {
        if (SoundManager.Instance.isSoundOn())
        {
            Button.enabled = true;
        }
        playButton.signalOnClick.AddListener(this.onPlay);
    }
    public void onPlay()
    {
        SoundManager.Instance.setSoundOn(true);
        Button.enabled = true;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
