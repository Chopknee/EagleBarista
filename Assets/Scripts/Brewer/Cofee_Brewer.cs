using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofee_Brewer : MonoBehaviour {

    public BrewerButton buttonScript;
    public CupTrigger cupInsertedTrigger;
    public CupTrigger puckInsertedTrigger;

    public bool brewing = false;
	
	void Start () {
        if (buttonScript != null) {
            buttonScript.OnClicked += OnBrewButtonClicked;
        }
	}
	
	
	void Update () {
        
	}

    void OnBrewButtonClicked() {
        
        if (brewing) {
            return;
        }

        //The cup is not inserted.

        bool coffee = false;
        if (puckInsertedTrigger.insertedObject == null) {
            GetComponentInChildren<ParticleSystem>().startColor = new Color(0, 0, 1);
        } else {
            coffee = true;
            GetComponentInChildren<ParticleSystem>().startColor = new Color(0.168f, 0.152f, 0.102f);
            Destroy(puckInsertedTrigger.insertedObject);
        }

        if (cupInsertedTrigger.insertedObject != null) {
            GameObject cup = cupInsertedTrigger.insertedObject;
            if (cup.GetComponent<LiquidStorage>() != null) {
                if (coffee) {
                    cup.GetComponent<LiquidStorage>().AddFluid("Cofee", 1);
                } else {
                    cup.GetComponent<LiquidStorage>().AddFluid("Water", 1);
                }
            }
        }

        GetComponentInChildren<ParticleSystem>().Play();
        Invoke("StopBrewing", 5);
        brewing = true;
    }

    void StopBrewing() {
        GetComponentInChildren<ParticleSystem>().Stop();
        brewing = false;
    }
}
