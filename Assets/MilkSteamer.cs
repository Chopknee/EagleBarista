using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkSteamer : MonoBehaviour {


    public ObjectsTrigger cupTrigger;
    public ToggleableButton steamerButton;

    public bool steaming = false;

    public float fluidPerSecond = 0.05f;
    public float fluidUpdateTime = 0.1f;

    private float flow = 0;

    void Start() {
        //Calculate the actual fluid flow rate.
        flow = fluidPerSecond * fluidUpdateTime;

        if (steamerButton != null) {
            steamerButton.OnToggled += OnBrewToggled;
        }
    }

    void OnBrewToggled(bool state) {
        if (state == true) {
            //On
            if (!steaming) {
                GetComponentInChildren<ParticleSystem>().Play();
                steaming = true;
                AddFluid();
            }
        } else {
            GetComponentInChildren<ParticleSystem>().Stop();
            steaming = false;
        }
    }

    void AddFluid() {
        if (cupTrigger.entangledGameObjects.Count != 0 && steaming) {
            //Check if the gameobject has a liquid storage script
            GameObject cup = cupTrigger.entangledGameObjects[0];
            if (cup.GetComponent<LiquidStorage>() != null) {
                cup.GetComponent<LiquidStorage>().v.ReplaceFluid("FoamedMilk", new Fluid("FoamedMilk", 1, flow, new Color(1, 0.824f, 0.757f)), "Milk");
            }
        }

        if (steaming) {
            Invoke("AddFluid", fluidUpdateTime);
        }
    }
}
