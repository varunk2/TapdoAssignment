using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    public Sprite selectionBackground;
    public Sprite correctAnswer;
    public Sprite wrongAnswer;
    public Button doctorPanelButton;
    public Button policePanelButton;
    public Button fireFighterPanelButton;

    public void OnDoctorClick() {
        Debug.Log("Doctor");
        doctorPanelButton.image.sprite = selectionBackground;
        CreateAnswerImage(doctorPanelButton, "cross");
    }

    public void OnPoliceOfficerClick() {
        Debug.Log("PoliceO fficer");
        policePanelButton.image.sprite = selectionBackground;
        CreateAnswerImage(policePanelButton, "cross");
    }

    public void OnFireFighterClick() {
        Debug.Log("Fire Fighter");
        fireFighterPanelButton.image.sprite = selectionBackground;
        CreateAnswerImage(fireFighterPanelButton, "tick");
    }

    private void CreateAnswerImage(Button panel, string option) {
        GameObject newGameObject = new GameObject();
        Image cross = newGameObject.AddComponent<Image>();
        cross.sprite = option == "cross" ? wrongAnswer : correctAnswer;
        cross.GetComponent<RectTransform>().SetParent(panel.transform);
        cross.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        cross.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
}
