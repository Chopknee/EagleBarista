using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeCupDispensory : MonoBehaviour {

    public CupTrigger trig;
    public GameObject cupPrefab;
    public Vector2 cupSpawnOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (trig.insertedObject == null) {
            GameObject go = Instantiate(cupPrefab);
            Vector2 pos = transform.position;
            go.transform.position = pos + cupSpawnOffset;
        }
    }

    public void OnDrawGizmos() {
        Vector3 off = new Vector3(cupSpawnOffset.x, cupSpawnOffset.y, 0);
        Gizmos.DrawCube(transform.position + off, new Vector3(0.25f, 0.25f, 0.25f));
    }
}
