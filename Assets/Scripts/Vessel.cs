using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vessel {

    float tempurature;

    Dictionary<string, Fluid> liquidContents;

    public Vessel() {
        liquidContents = new Dictionary<string, Fluid>();
    }

    public void AddFluid(string liquidName, Fluid fluid) {
        //Check if the liquid already exists in the cup
        if (liquidContents.ContainsKey(liquidName)) {
            liquidContents[liquidName].volume += fluid.volume;
            //The impact on the tempurature of fluid A with volume Va is what when mixed with fluid B
            //This requires some thermodynamics knowledge. VERSION 2!!
            //liquidContents[liquidName].tempurature = fluid.tempurature + liquidContents[liquidName].tempurature / 2;

        } else {
            liquidContents.Add(liquidName, new Fluid(fluid));
        }

        float totalLiquidContents = GetLiquidContentsTotal();

        //Overflow detection and mitigation
        if (totalLiquidContents >= 1) {
            Dictionary<string, Fluid> temp = new Dictionary<string, Fluid>(liquidContents);
            float overage = totalLiquidContents - 1;
            Debug.Log("Overflow by " + overage + " liquid units.");
            foreach (KeyValuePair<string, Fluid> liq in temp) {
                liquidContents[liq.Key].volume = liq.Value.volume - ((liq.Value.volume / totalLiquidContents) * overage);
            }
        }

        Debug.Log(liquidName + " has been added!");
    }

    public float GetLiquidContentsTotal() {
        float total = 0;
        foreach (KeyValuePair<string, Fluid> liq in liquidContents) {
            total += liq.Value.volume;
        }
        return total;
    }

    //Calculates the difference between this liquid storage and the given
    public Vessel GetDifference(Vessel other) {
        return new Vessel();
    }

    public Dictionary<string, Fluid> getFluids() {
        return liquidContents;
    }
}