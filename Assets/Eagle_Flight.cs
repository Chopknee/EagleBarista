using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle_Flight : MonoBehaviour {
    [SerializeField]
    public Vector2 mouseOffset;

    public float speed;
 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 direction = new Vector2();

        if (Input.GetAxis("Horizontal") != 0)
        {
            direction = new Vector2(Input.GetAxis("Horizontal"), direction.y);
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            direction = new Vector2(direction.x, Input.GetAxis("Vertical"));
        }

        direction.Normalize();

        if (Input.GetButtonDown("Jump"))
        {
            direction += new Vector2(0, 70);
        }
        //Debug.Log(direction);
        direction = direction * speed;
        gameObject.GetComponent<Rigidbody2D>().AddForce(direction);
        //transform.position = new Vector3(transform.position.x + direction.x, transform.position.y + direction.y, transform.position.z);
    }
}
