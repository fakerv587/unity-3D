using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodValue : MonoBehaviour
{
   public float bloodValue;

    private float tmpValue;

    void Start()
    {
        tmpValue = 0.0f;
        bloodValue = 0.0f;
    }

    void OnGUI()
    {    
        if (GUI.Button(new Rect(250, 20, 40, 20), "+"))
        {
            if(tmpValue < 0.9f){
                tmpValue += 0.1f;
            }
            else{
                tmpValue = 1.0f;
            }
        }

        if (GUI.Button(new Rect(250, 50, 40, 20), "-"))
        {
            if(tmpValue > 0.1f){
                tmpValue -= 0.1f;
            }
            else{
                tmpValue = 0.0f;
            }
        }

        bloodValue = Mathf.Lerp(bloodValue, tmpValue, 0.01f);

        GUI.color = Color.red;
        GUI.HorizontalScrollbar(new Rect(20, 20, 200, 20), 0.0f, bloodValue,0.0f, 1.0f, GUI.skin.GetStyle("HorizontalScrollbar"));

    }
}
