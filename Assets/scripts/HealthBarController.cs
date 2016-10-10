using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    public Texture backgroundTexture;
    public Texture foregroundTexture;
    public Texture frameTexture;

    public int healthWidth ;
    public int healthHeight;
    private int initialHealthWidth ;

    public int healthMarginLeft ;
    public int healthMarginTop;

    public int frameWidth ;
    public int frameHeight;

    public int frameMarginLeft ;
    public int frameMarginTop ;

    void Start()
    {
     healthWidth = (175 * Screen.width) / 1061;
     healthHeight = 22 * Screen.height / 597;
     initialHealthWidth= (175 * Screen.width) / 1061;
     healthMarginLeft = 853 * Screen.width / 1061;
     healthMarginTop = 30 * Screen.height / 597;

     frameWidth = 217 * Screen.width / 1061;
     frameHeight = 55 * Screen.height / 597;

     frameMarginLeft = 540 * Screen.width / 1061;
     frameMarginTop = 5 * Screen.height / 597;

    }
    void OnGUI()
    {
    
        GUI.DrawTexture(new Rect(frameMarginLeft, frameMarginTop, frameMarginLeft + frameWidth, frameMarginTop + frameHeight), backgroundTexture, ScaleMode.ScaleToFit, true, 0);

        GUI.DrawTexture(new Rect(healthMarginLeft, healthMarginTop, healthWidth, healthHeight), foregroundTexture, ScaleMode.ScaleAndCrop, true, 0);

        GUI.DrawTexture(new Rect(frameMarginLeft, frameMarginTop, frameMarginLeft + frameWidth, frameMarginTop + frameHeight), frameTexture, ScaleMode.ScaleToFit, true, 0);

    }

    public int getInitialHealthWidth()
    {
        return initialHealthWidth;
    }
}