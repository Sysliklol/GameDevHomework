using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class ClosePopup : MonoBehaviour {

    public UI2DSprite Settings;
    public ClosePopup playButton;
    public UnityEvent signalOnClick = new UnityEvent();
    public void _onClick()
    {
        this.signalOnClick.Invoke();

    }

    void Start()
    {
        Settings.enabled = false;
        Settings.UpdateVisibility(false, false);
        playButton.signalOnClick.AddListener(this.onPlay);
    }
    public void onPlay()
    {
        Settings.UpdateVisibility(false, false);
       // Settings.enabled = false;
    }

    public void onLeave()
    {
        SceneManager.LoadScene("mainmenu");
    }
    public void onRestart()
    {
        SceneManager.LoadScene("scene1");
    }
}
