using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fluid
{

    public string name;
    //public float tempurature;
    public float volume;

    public Fluid(string name, float tempurature, float amount)
    {
        this.name = name;
        //this.tempurature = tempurature;
        this.volume = amount;
    }

    public Fluid(Fluid fluid)
    {
        name = fluid.name;
        volume = fluid.volume;
    }
}
