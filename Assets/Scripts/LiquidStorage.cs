using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidStorage : MonoBehaviour {
    //String - Name of the liquid
    //Float - Percentage of vessel volume taken by this liquid.
    [SerializeField]
    Dictionary<string, float> liquidContents;

    public LiquidStorage() {
        liquidContents = new Dictionary<string, float>();
    }

    public void AddFluid(string liquidName, float percent) {
        //Adding fluid in, if over 100% some needs to be taken out.
        //Assuming fluids are homogeneous so equivalent amounts are "spilled" out when overfilled.
        //Working with percents because volumes would be too much effort.

        //Check if the liquid already exists in the cup
        if (liquidContents.ContainsKey(liquidName)) {
            liquidContents[liquidName] += percent;
        } else {
            liquidContents.Add(liquidName, percent);
        }
        float totalLiquidContents = GetLiquidContentsTotal();
        Dictionary<string, float> temp = new Dictionary<string, float>(liquidContents);
        if (totalLiquidContents >= 1) {
            //Overflow the cup.
            float overage = totalLiquidContents - 1;
            foreach (KeyValuePair<string, float> liq in temp) {
                liquidContents[liq.Key] = liq.Value - (liq.Value * overage);
            }
        }
        Debug.Log(liquidName + " has been added!");
    }

    public float GetLiquidContentsTotal() {
        float total = 0;
        foreach (KeyValuePair<string, float> liq in liquidContents) {
            total += liq.Value;
        }
        return total;
    }
}
