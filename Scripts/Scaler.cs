using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    private Vector2 targetResoultion = new Vector2(1920, 1080); //can be changed here or elsewhere
    private bool matchWidth = true; //0=width, 1=height  used to maintain aspect ratio
    // Start is called before the first frame update
    void Start()
    {
        float difference = CalculateDifference();
        ScaleObj(difference);
    }

    void ScaleObj(float diff)
    {
        gameObject.transform.localScale += (gameObject.transform.localScale * (diff / 100));
    }

    private float CalculateDifference()
    {
        Vector2 actualResolution = new Vector2(Screen.width, Screen.height);
        Vector2 change = actualResolution - targetResoultion;
        Vector2 percentChange = (change / targetResoultion) * 100;

        //match width/height
        if (matchWidth)
        {
            return percentChange.x;
        }
        else
        {
            return percentChange.y;
        }
    }
}