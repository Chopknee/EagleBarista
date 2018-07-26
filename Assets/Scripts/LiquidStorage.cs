using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidStorage : MonoBehaviour {
    //String - Name of the liquid
    //Float - Percentage of vessel volume taken by this liquid.

    public Vessel v;

    public void Start()
    {
        v = new Vessel();
    }

}
