using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkDispenser : MonoBehaviour {

    public ObjectsTrigger cupTriggerArea;
    public InteractableButton dispenseButton;
    public float fluidPerSecond = 0.05f;
    public float fluidUpdateTime = 0.1f;

    private float flow = 0;

    public bool dispensing = false;

	// Use this for initialization
	void Start () {
        flow = fluidPerSecond * fluidUpdateTime;

        if (dispenseButton != null) {
            dispenseButton.OnClicked += OnButtonClicked;
            dispenseButton.OnReleased += OnButtonReleased;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonClicked() {
        dispensing = true;
        Dispense();
        GetComponentInChildren<ParticleSystem>().Play();
    }

    public void OnButtonReleased() {
        dispensing = false;
        GetComponentInChildren<ParticleSystem>().Stop();
    }

    public void Dispense() {
        if (dispensing) {
            //Trigger the repeat running
            Invoke("Dispense", fluidUpdateTime);
            //Check if there can be any addition to a vessel object
            if (cupTriggerArea.entangledGameObjects.Count != 0) {
                //Check if the gameobject has a liquid storage script
                GameObject cup = cupTriggerArea.entangledGameObjects[0];
                if (cup.GetComponent<LiquidStorage>() != null) {
                    cup.GetComponent<LiquidStorage>().v.AddFluid("Milk", new Fluid("Milk", 1, flow, new Color(1, 1, 1)));
                }
            }
        }
    }
}
