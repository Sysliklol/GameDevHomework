﻿using System.Collections;
using UnityEngine.Events;
using UnityEngine;
public class MyButton : MonoBehaviour
{
    public UI2DSprite Settings;
    public MyButton playButton;
    public UnityEvent signalOnClick = new UnityEvent();
    public void _onClick()
    {
        this.signalOnClick.Invoke();

    }
    
    void Start()
    {
        Settings.enabled = false;
        playButton.signalOnClick.AddListener(this.onPlay);
    }
    public void onPlay()
    {
        Settings.enabled = true;
    }
}