using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidStorage : MonoBehaviour {
    //String - Name of the liquid
    //Float - Percentage of vessel volume taken by this liquid.

    public Vessel v;
    [SerializeField]
    public Vector2 barSize;
    [SerializeField]
    public Vector2 barOffset;

    public Color backgroundColor;
    private Texture2D backTexture;
    public void Start() {
        v = new Vessel();
        backTexture = new Texture2D(1, 1);
        backTexture.SetPixel(1, 1, backgroundColor);
        backTexture.Apply();
    }

    public void OnGUI() {

        Vector2 screen = Camera.main.WorldToScreenPoint(transform.position);
        screen.y = Screen.height - screen.y;
        Vector2 pos = screen;

        // draw the background:
        GUI.BeginGroup(new Rect(pos.x+barOffset.x, pos.y+barOffset.y, barSize.x, barSize.y));
        GUI.DrawTexture(new Rect(0, 0, barSize.x, barSize.y), backTexture);

        float barPos = 0;
        foreach (KeyValuePair<string, Fluid> liq in v.getFluids()) {
            GUI.DrawTexture(new Rect(barPos * barSize.x, 0, barPos + liq.Value.volume*barSize.x, barSize.y), liq.Value.getTexture());
            barPos += liq.Value.volume;
        }
        
        GUI.EndGroup();

    }

    public void Update() {
    }

}
