using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fluid {

    public string name;
    public float volume;
    public Color fluidColor = new Color(1, 1, 1);

    private Texture2D guiTexture;

    public Fluid(string name, float tempurature, float amount, Color color) {
        this.name = name;
        
        volume = amount;
        fluidColor = color;
        GenerateTexture();
    }

    public Fluid(Fluid fluid) {
        name = fluid.name;
        volume = fluid.volume;
        fluidColor = fluid.fluidColor;
        GenerateTexture();
    }

    public Texture2D getTexture() {
        return guiTexture;
    }

    private void GenerateTexture() {
        guiTexture = new Texture2D(1, 1);
        guiTexture.SetPixel(1, 1, fluidColor);
        guiTexture.Apply();
    }
}
