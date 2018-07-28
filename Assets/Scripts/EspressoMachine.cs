using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspressoMachine : MonoBehaviour {

    public InteractableButton brewEspressoButton;
    public ObjectsTrigger espressoCupArea;
    public ObjectsTrigger groundEspressoArea;

    public bool brewing = false;
    public bool coffee = false;

    public float fluidPerSecond = 0.05f;
    public float fluidUpdateTime = 0.1f;
    public float brewingTime = 3;

    private float flow = 0;

    


    // Use this for initialization
    void Start () {
        flow = fluidPerSecond * fluidUpdateTime;

        if (brewEspressoButton != null) {
            brewEspressoButton.OnClicked += OnBrewEspressoClicked;
            brewEspressoButton.OnReleased += OnBrewEspressoReleased;
        }
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void OnBrewEspressoClicked() {
        //Nothing should happen when initially clicked.
    }

    public void OnBrewEspressoReleased() {
        if (brewing) {
            return;
        }

        //The cup is not inserted.
        coffee = false;
        if (groundEspressoArea.entangledGameObjects.Count == 0) {
            GetComponentInChildren<ParticleSystem>().startColor = new Color(0, 0, 1);
        } else {
            coffee = true;
            GetComponentInChildren<ParticleSystem>().startColor = new Color(0.098f, 0.0431f, 0);
            groundEspressoArea.DestroyEnangledObjects();
        }

        brewing = true;
        AddFluid();
        Invoke("BrewingEnd", brewingTime);
        GetComponentInChildren<ParticleSystem>().Play();
    }

    public void AddFluid() {
        if (espressoCupArea.entangledGameObjects.Count != 0 && brewing) {
            //Check if the gameobject has a liquid storage script
            GameObject cup = espressoCupArea.entangledGameObjects[0];
            if (cup.GetComponent<LiquidStorage>() != null) {
                if (coffee) {
                    cup.GetComponent<LiquidStorage>().v.AddFluid("Espresso", new Fluid("Espresso", 1, flow, new Color(0.098f, 0.0431f, 0)));
                } else {
                    cup.GetComponent<LiquidStorage>().v.AddFluid("Water", new Fluid("Water", 1, flow, new Color(0, 0, 1)));
                }
            }
        }

        if (brewing) {
            Invoke("AddFluid", fluidUpdateTime);
        }
    }

    public void BrewingEnd() {
        brewing = false;
        GetComponentInChildren<ParticleSystem>().Stop();
    }
}
