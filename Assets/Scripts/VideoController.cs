using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    private VideoPlayer _videoPlayer;
    [SerializeField] private bool _isPlaying = false;

    public GameObject optionPanel;

    private void Awake() {
        _videoPlayer = GetComponent<VideoPlayer>();
    }

    void Start()
    {
        //_videoPlayer.Stop();
        _videoPlayer.playOnAwake = false;
        _videoPlayer.waitForFirstFrame = false;
    }

    void Update() {

        Debug.Log(_videoPlayer.clockTime);

        if ((Input.GetKeyDown(KeyCode.Space)) && (_isPlaying == true)) {
            _isPlaying = false;
            _videoPlayer.Pause();
        } else if ((Input.GetKeyDown(KeyCode.Space)) && (_isPlaying == false)) {
            _isPlaying = true;
            _videoPlayer.Play();
        }

        if (_videoPlayer.clockTime >= 17.1f) {
            _isPlaying = false;
            _videoPlayer.Pause();
            optionPanel.SetActive(true);
        }

    }
}
