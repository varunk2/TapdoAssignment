using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {
    private VideoPlayer _videoPlayer;
    [SerializeField] private bool _isActivity1Started = false;
    [SerializeField] private bool _isActivity2Started = false;

    public AudioSource swoosh;
    public AudioSource line;
    public AudioSource correctAnswerAudio;
    public AudioSource wrongAnswerAudio;
    public AudioSource wheelAudio;
    public AudioSource sirenAudio;
    public AudioSource splashAudio;
    public AudioSource bellAudio;

    private float _activity1StartTime = 17f;
    private float _activity2StartTime = 46f;

    public GameObject activity1Panel;
    public GameObject activity2Panel;

    private void Awake() {
        _videoPlayer = GetComponent<VideoPlayer>();
    }

    void Start() {
        _videoPlayer.playOnAwake = false;
        _videoPlayer.waitForFirstFrame = false;
    }

    void Update() {

        Debug.Log(_videoPlayer.time);

        if ((Input.GetKeyDown(KeyCode.Space)) && (_videoPlayer.isPlaying == true)) {
            _videoPlayer.Pause();
        } else if ((Input.GetKeyDown(KeyCode.Space)) && (_videoPlayer.isPlaying == false)) {
            _videoPlayer.Play();
        }

        StartActivity1();
        StartActivity2();
    }   

    private void StartActivity1() {
        if ((_videoPlayer.time >= _activity1StartTime) && (_isActivity1Started == false)) {
            _videoPlayer.Pause();

            _isActivity1Started = true;

            swoosh.Play();
            activity1Panel.SetActive(true);
            line.PlayDelayed(swoosh.clip.length);
        }
    }

    private void StartActivity2() {
        if ((_videoPlayer.time >= _activity2StartTime) && (_isActivity2Started == false)) {
            activity2Panel.SetActive(true);
        }
    }

    public void ToggleActivity1() {
        activity1Panel.SetActive(false);
        _videoPlayer.Play();
    }

    public void PlayCorrectAudio() {
        correctAnswerAudio.Play();
    }
    
    public void PlayWrongAudio() {
        wrongAnswerAudio.Play();
    }
}
