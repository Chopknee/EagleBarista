using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupTrigger : MonoBehaviour {

    public GameObject insertedObject;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerStay2D(Collider2D collision) {
        insertedObject = collision.gameObject;
    }

    public void OnTriggerExit2D(Collider2D collision) {
        insertedObject = null;
    }
}
