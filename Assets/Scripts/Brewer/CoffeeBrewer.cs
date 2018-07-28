using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeBrewer : MonoBehaviour {

    public ToggleableButton buttonScript;
    public ObjectsTrigger cupInsertedTrigger;
    public ObjectsTrigger puckInsertedTrigger;

    public bool brewing = false;
    public bool coffee = false;

    public float fluidPerSecond = 0.05f;
    public float fluidUpdateTime = 0.1f;

    private float flow = 0;

	void Start () {
        //Calculate the actual fluid flow rate.
        flow = fluidPerSecond * fluidUpdateTime;

        if (buttonScript != null) {
            buttonScript.OnToggled += OnBrewToggled;
        }
	}

    void OnBrewToggled(bool state) {
        if (state == true) {
            //On
            if (!brewing) {
                brewing = true;
                if (puckInsertedTrigger.entangledGameObjects.Count == 0) {
                    GetComponentInChildren<ParticleSystem>().startColor = new Color(0, 0, 1);
                } else {
                    coffee = true;
                    GetComponentInChildren<ParticleSystem>().startColor = new Color(0.168f, 0.152f, 0.102f);
                    puckInsertedTrigger.DestroyEnangledObjects();
                }
                GetComponentInChildren<ParticleSystem>().Play();
                brewing = true;
                AddFluid();
            }
        } else {
            GetComponentInChildren<ParticleSystem>().Stop();
            brewing = false;
            coffee = false;
        }
    }

    void AddFluid()
    {
        if (cupInsertedTrigger.entangledGameObjects.Count != 0 && brewing)
        {
            //Check if the gameobject has a liquid storage script
            GameObject cup = cupInsertedTrigger.entangledGameObjects[0];
            if (cup.GetComponent<LiquidStorage>() != null)
            {
                if (coffee)
                {
                    cup.GetComponent<LiquidStorage>().v.AddFluid("Coffee", new Fluid("Coffee", 1, flow, new Color(0.168f, 0.152f, 0.102f)));
                }
                else
                {
                    cup.GetComponent<LiquidStorage>().v.AddFluid("Water", new Fluid("Water", 1, flow, new Color(0, 0, 1)));
                }
            }
        }

        if (brewing)
        {
            Invoke("AddFluid", fluidUpdateTime);
        }
    }
}
