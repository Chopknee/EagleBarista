using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talons_Grabbing : MonoBehaviour {

    public bool grabbed = false;
    public GameObject grabbedObject = null;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (grabbed && Input.GetButtonDown("Fire2")) {
            grabbed = false;
            grabbedObject.transform.parent = null;
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {

    }

    private void OnTriggerStay2D(Collider2D collision) {
        
        if (Input.GetButton("Fire1") && !grabbed) {
            Debug.Log("TRIGGERED!");
            grabbed = true;
            grabbedObject  = collision.gameObject;
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
            grabbedObject.transform.parent = gameObject.transform;
        }


    }
}
