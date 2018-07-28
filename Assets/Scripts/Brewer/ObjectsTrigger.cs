using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Used to keep track of all gameobjects currently intersecting withe the
 *  attatched trigger collider 2D.
 * 
 */
public class ObjectsTrigger : MonoBehaviour {

    public List<GameObject> entangledGameObjects;
    // Use this for initialization
    void Start() {
        entangledGameObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (!entangledGameObjects.Contains(other.gameObject)) {
            entangledGameObjects.Add(other.gameObject);
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (entangledGameObjects.Contains(collision.gameObject)) {
            entangledGameObjects.Remove(collision.gameObject);
        }
    }

    public void DestroyEnangledObjects() {
        for (int i = entangledGameObjects.Count-1; i >= 0; i --) {
            Destroy(entangledGameObjects[i]);
        }
        
        entangledGameObjects.Clear();
    }
}
