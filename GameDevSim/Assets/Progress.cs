﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{

    public value barDisplay; //current progress
    public Vector2 pos = new Vector2(20, 40);
    public Vector2 size = new Vector2(60, 20);
    public Texture2D emptyTex;
    public Texture2D fullTex;
    float percentFull = 0;
    public GUIStyle progress_empty, progress_full;
    void OnGUI()
    {
        //draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex, progress_empty);

        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay.currValue / 100f, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex, progress_full); GUI.EndGroup();
        GUI.EndGroup();
    }

    void Update()
    {
        //for this example, the bar display is linked to the current time,
        //however you would set this value based on your desired display
        //eg, the loading progress, the player's health, or whatever.
        
            
    }
}
