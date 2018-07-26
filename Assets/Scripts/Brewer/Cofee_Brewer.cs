using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofee_Brewer : MonoBehaviour {

    public BrewerButton buttonScript;
    public CupTrigger cupInsertedTrigger;
    public CupTrigger puckInsertedTrigger;

    public bool brewing = false;

    public bool coffee = false;

    public float fluidPerSecond = 0.05f;

	void Start () {
        if (buttonScript != null) {
            buttonScript.OnClicked += OnBrewButtonClicked;
            buttonScript.OnReleased += OnBrewButtonReleased;
        }
	}

    void OnBrewButtonClicked() {
        
        if (brewing) {
            return;
        }

        //The cup is not inserted.

        if (puckInsertedTrigger.insertedObject == null) {
            GetComponentInChildren<ParticleSystem>().startColor = new Color(0, 0, 1);
        } else {
            coffee = true;
            GetComponentInChildren<ParticleSystem>().startColor = new Color(0.168f, 0.152f, 0.102f);
            Destroy(puckInsertedTrigger.insertedObject);
        }

        //if (cupInsertedTrigger.insertedObject != null) {
        //    GameObject cup = cupInsertedTrigger.insertedObject;
        //    if (cup.GetComponent<LiquidStorage>() != null) {
        //        if (coffee) {
        //            cup.GetComponent<Vessel>().AddFluid("Coffee", new Fluid("Coffee", 1, 1));
        //        } else {
        //            cup.GetComponent<Vessel>().AddFluid("Water", new Fluid("Water", 1, 1));
        //        }
        //    }
        //}

        GetComponentInChildren<ParticleSystem>().Play();
        brewing = true;
        Invoke("AddFluid", 0.2f);
    }

    void AddFluid()
    {
        if (cupInsertedTrigger.insertedObject != null)
        {
            GameObject cup = cupInsertedTrigger.insertedObject;
            if (cup.GetComponent<LiquidStorage>() != null)
            {
                if (coffee)
                {
                    cup.GetComponent<LiquidStorage>().v.AddFluid("Coffee", new Fluid("Coffee", 1, fluidPerSecond));
                }
                else
                {
                    cup.GetComponent<LiquidStorage>().v.AddFluid("Water", new Fluid("Water", 1, fluidPerSecond));
                }
            }
        }

        if (brewing)
        {
            Invoke("AddFluid", 0.2f);
        }
    }

    void OnBrewButtonReleased()
    {
        GetComponentInChildren<ParticleSystem>().Stop();
        brewing = false;
        coffee = false;
    }
}
