using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeGrinder : MonoBehaviour {

    public InteractableButton grindCoffeeButton;
    public GameObject groundCoffeeObject;

    [SerializeField]
    public Vector2 groundCoffeePosition = new Vector2 (0, 0);

    bool isClicked = false;
    bool isGrinding = false;

    public float grindTime = 4;

	// Use this for initialization
	void Start () {
        grindCoffeeButton.OnClicked += OnGrindCoffeeClicked;
        grindCoffeeButton.OnReleased += OnGrindCoffeeReleased;
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OnGrindCoffeeClicked() {
        if (!isGrinding && !isClicked) {
            isGrinding = true;
            isClicked = true;
            GetComponentInChildren<ParticleSystem>().Play();
            Invoke("Dispense", grindTime);
        }
    }

    public void OnGrindCoffeeReleased() {
        isClicked = false;
    }

    public void Dispense() {
        GameObject go = Instantiate(groundCoffeeObject);
        Vector2 pos = transform.position;
        go.transform.position = pos + groundCoffeePosition;
        isGrinding = false;
        GetComponentInChildren<ParticleSystem>().Stop();
    }

    public void OnDrawGizmos() {
        Vector3 off = new Vector3(groundCoffeePosition.x, groundCoffeePosition.y, 0);
        Gizmos.DrawCube(transform.position+off, new Vector3(0.25f, 0.25f, 0.25f));
    }
}
