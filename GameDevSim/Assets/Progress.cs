using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public enum ScreenLocation { topMid, topLeft, topRight, bottomMid }

    public ScreenLocation screenLocation;
    value barDisplay;
    public Vector2 pos = new Vector2(20, 40);
    public Vector2 size = new Vector2(60, 20);
    public Texture2D emptyTex;
    public Texture2D fullTex;
    float percentFull = 0;
    public GUIStyle progress_empty, progress_full;

    public float leftConstraint = 0.0f;
    public float rightConstraint = 0.0f;
    public float topConstraint = 0.0f;
    public float bottomConstraint = 0.0f;
    float distanceZ = 10.0f;
    private void Start()
    {

        barDisplay = GetComponent<value>();
        leftConstraint = 0;
        rightConstraint = Screen.width - size.x;

        bottomConstraint = Screen.height - size.y;
        topConstraint = 0;

        switch (screenLocation)
        {
            case ScreenLocation.topMid:
                pos = new Vector2(rightConstraint / 2, 5);
                break;
            case ScreenLocation.topLeft:
                pos = new Vector2(rightConstraint / 3, 5);
                break;
            case ScreenLocation.topRight:
                pos = new Vector2(rightConstraint / 3 * 2, 5);
                break;
            case ScreenLocation.bottomMid:
                pos = new Vector2(rightConstraint / 2, bottomConstraint -5);
                break;
            default:
                break;
        }
    }
    void OnGUI()
    {
        //draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex, progress_empty);

        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay.currValue / 100f, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex, progress_full);
        GUI.EndGroup();
        GUI.EndGroup();
    }

    void Update()
    {
        //for this example, the bar display is linked to the current time,
        //however you would set this value based on your desired display
        //eg, the loading progress, the player's health, or whatever.


    }
}
