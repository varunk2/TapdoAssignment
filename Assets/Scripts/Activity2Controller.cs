using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Activity2Controller : MonoBehaviour {
    public Sprite newWheelSprite;
    public Sprite newSirenSprite;
    public Sprite newSplashSprite;
    public Sprite newBellSprite;
    public VideoController videoController;

    [SerializeField] private Button wheelButton;
    [SerializeField] private Button sirenButton;
    [SerializeField] private Button splashButton;
    [SerializeField] private Button bellButton;


    public void OnClick(string buttonName) {
        switch (buttonName) {
            case "Wheel":
                wheelButton.image.sprite = newWheelSprite;
                StartCoroutine(PlayAudio(wheelButton, buttonName));
                break;

            case "Siren":
                sirenButton.image.sprite = newSirenSprite;
                StartCoroutine(PlayAudio(sirenButton, buttonName));
                break;

            case "Splash":
                splashButton.image.sprite = newSplashSprite;
                StartCoroutine(PlayAudio(splashButton, buttonName));
                break;

            case "Bell":
                bellButton.image.sprite = newBellSprite;
                StartCoroutine(PlayAudio(bellButton, buttonName));
                break;
        }
    }

    IEnumerator PlayAudio(Button button, string buttonName) {

        switch (buttonName) {

            case "Wheel":
                videoController.wheelAudio.Play();
                yield return new WaitForSeconds(videoController.wheelAudio.clip.length);
                break;

            case "Siren":
                videoController.sirenAudio.Play();
                yield return new WaitForSeconds(videoController.sirenAudio.clip.length);
                break;

            case "Splash":
                videoController.splashAudio.Play();
                yield return new WaitForSeconds(videoController.splashAudio.clip.length);
                break;

            case "Bell":
                videoController.bellAudio.Play();
                yield return new WaitForSeconds(videoController.bellAudio.clip.length);
                break;
        }
    }
}
