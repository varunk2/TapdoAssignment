using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    private VideoPlayer _videoPlayer;
    [SerializeField] private bool _isPlaying = false;
    [SerializeField] private AudioSource swoosh;
    [SerializeField] private AudioSource line;

    public GameObject optionPanel;

    private void Awake() {
        _videoPlayer = GetComponent<VideoPlayer>();
    }

    void Start()
    {
        _videoPlayer.playOnAwake = false;
        _videoPlayer.waitForFirstFrame = false;
    }

    void Update() {

        Debug.Log(_videoPlayer.clockTime);

        if ((Input.GetKeyDown(KeyCode.Space)) && (_videoPlayer.isPlaying == true)) {
            _videoPlayer.Pause();
        } else if ((Input.GetKeyDown(KeyCode.Space)) && (_videoPlayer.isPlaying == false)) {
            _videoPlayer.Play();
        }

        if (_videoPlayer.clockTime >= 17.1f) {
            _videoPlayer.Pause();

            if (!swoosh.isPlaying && (_isPlaying == false)) {
                _isPlaying = true;
                swoosh.Play();
                line.PlayDelayed(swoosh.clip.length);
            }

            optionPanel.SetActive(true);
        }

    }
}
