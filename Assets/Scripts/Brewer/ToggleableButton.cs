using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleableButton: MonoBehaviour {

    public GameObject litButton;
    public GameObject dimButton;

    public delegate void ClickedEvent();
    public ClickedEvent OnClicked;

    public delegate void ReleasedEvent();
    public ReleasedEvent OnReleased;

    public delegate void ToggledEvent(bool state);
    public ToggledEvent OnToggled;

    bool down = false;

    private void OnTriggerStay2D(Collider2D collision) {
        if (Input.GetButtonUp("Fire1")) {
            if (down) {
                down = false;
                litButton.SetActive(true);
                dimButton.SetActive(false);
                //OnReleased();
                OnToggled(down);
            } else {
                down = true;
                litButton.SetActive(false);
                dimButton.SetActive(true);
                //OnClicked();
                OnToggled(down);
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        //if (down) {
        //    down = false;
        //    litButton.SetActive(true);
        //    dimButton.SetActive(false);
        //    //OnReleased();
        //    OnToggled(down);
        //}
    }
}
