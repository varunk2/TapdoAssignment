using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Activity1Controller : MonoBehaviour {
    public Sprite selectionBackground;
    public Sprite correctAnswer;
    public Sprite wrongAnswer;

    public Button doctorPanelButton;
    public Button policePanelButton;
    public Button fireFighterPanelButton;

    public VideoController videoController;

    private float _imageScale = 1.5f;

    public void OnDoctorClick() {
        doctorPanelButton.image.sprite = selectionBackground;
        CreateAnswerImage(doctorPanelButton, "cross");
        StartCoroutine(PlayWrongAudio());
    }

    public void OnPoliceOfficerClick() {
        policePanelButton.image.sprite = selectionBackground;
        CreateAnswerImage(policePanelButton, "cross");
        StartCoroutine(PlayWrongAudio());
    }

    public void OnFireFighterClick() {
        fireFighterPanelButton.image.sprite = selectionBackground;
        CreateAnswerImage(fireFighterPanelButton, "tick");
        StartCoroutine(PlayCorrectAudio());
    }

    IEnumerator PlayWrongAudio() {
        videoController.PlayWrongAudio();
        yield return new WaitForSeconds(videoController.wrongAnswerAudio.clip.length);
    }

    IEnumerator PlayCorrectAudio() {
        videoController.PlayCorrectAudio();
        yield return new WaitForSeconds(videoController.correctAnswerAudio.clip.length);
        videoController.ToggleActivity1();
    }

    private void CreateAnswerImage(Button panel, string option) {
        GameObject newGameObject = new GameObject();
        Image cross = newGameObject.AddComponent<Image>();
        cross.sprite = option == "cross" ? wrongAnswer : correctAnswer;
        cross.GetComponent<RectTransform>().SetParent(panel.transform);
        cross.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        cross.GetComponent<RectTransform>().localScale = new Vector3(_imageScale, _imageScale, _imageScale);
    }
}
