using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayButton : MonoBehaviour
{
    public PlayButton playButton;
    public UnityEvent signalOnClick = new UnityEvent();
    public void _onClick()
    {
        this.signalOnClick.Invoke();

    }

    void Start()
    {

        playButton.signalOnClick.AddListener(this.onPlay);
    }
    public void onPlay()
    {
        SceneManager.LoadScene("scene0");
    }
}