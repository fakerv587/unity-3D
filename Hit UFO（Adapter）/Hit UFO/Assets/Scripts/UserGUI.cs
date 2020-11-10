using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    IUserAction userAction;
    string gameMessage;
    int points;

    public void SetMessage(string gameMessage)
    {
        this.gameMessage = gameMessage;
    }

    public void SetPoints(int points)
    {
        this.points = points;
    }

    void Start()
    {
        points = 0;
        gameMessage = "";
        userAction = SSDirector.GetInstance().CurrentScenceController as IUserAction;
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.white;
        style.fontSize = 30;

        GUIStyle bigStyle = new GUIStyle();
        bigStyle.normal.textColor = Color.white;
        bigStyle.fontSize = 50;

        GUI.Label(new Rect(300, 30, 50, 200), "Hit UFO Game", bigStyle);
        GUI.Label(new Rect(20, 0, 100, 50), "Score: " + points, style);
        GUI.Label(new Rect(310, 100, 50, 200), gameMessage, style);

        if (GUI.Button(new Rect(20, 210, 100, 40), "Restart"))
        {
            userAction.Restart();
        }
        if (GUI.Button(new Rect(200, 260, 100, 40), "Normal mode"))
        {
            userAction.SetMode(false);
        }
        if (GUI.Button(new Rect(200, 310, 100, 40), "Nightmare"))
        {
            userAction.SetMode(true);
        }
        if (GUI.Button(new Rect(200, 360, 100, 40), "Kinematics"))
        {
            userAction.SetFlyMode(false);
        }
        if (GUI.Button(new Rect(200, 410, 100, 40), "Physics"))
        {
            userAction.SetFlyMode(true);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            userAction.Hit(Input.mousePosition);
        }
    }
}