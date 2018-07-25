using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewerButton : MonoBehaviour {

    public GameObject litButton;
    public GameObject dimButton;

    public delegate void ClickedEvent();
    public ClickedEvent OnClicked;

    bool down = false;

    private void OnTriggerStay2D(Collider2D collision) {
        //The eagle is inside, is it trying to click?
        if (Input.GetButton("Fire1") && !down) {
            down = true;
            litButton.SetActive(false);
            dimButton.SetActive(true);
            OnClicked();
        }
        if (Input.GetButtonUp("Fire1") && down) {
            down = false;
            litButton.SetActive(true);
            dimButton.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        down = false;
        litButton.SetActive(true);
        dimButton.SetActive(false);
    }
}
