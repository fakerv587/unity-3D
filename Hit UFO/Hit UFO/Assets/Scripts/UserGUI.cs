using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    private IUserAction userAction;
    public string gameMessage;
    public int points;
    void Start()
    {
        points = 0;
        gameMessage = "";
        userAction = SSDirector.GetInstance().CurrentScenceController as IUserAction;
    }

    void OnGUI()
    {
        //小字体初始化
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.white;
        style.fontSize = 30;

        //大字体初始化
        GUIStyle bigStyle = new GUIStyle();
        bigStyle.normal.textColor = Color.white;
        bigStyle.fontSize = 50;

        GUI.Label(new Rect(300, 30, 50, 200), "Hit UFO Game", bigStyle);
        GUI.Label(new Rect(20, 0, 100, 50), "得分: " + points, style);
        GUI.Label(new Rect(310, 100, 50, 200), gameMessage, style);
        if (GUI.Button(new Rect(20, 50, 100, 40), "重新游戏"))
        {
            userAction.Restart();
        }
        if (GUI.Button(new Rect(20, 100, 100, 40), "正常模式(默认)"))
        {
            userAction.SetMode(false);
        }
        if (GUI.Button(new Rect(20, 150, 100, 40), "无尽模式"))
        {
            userAction.SetMode(true);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            userAction.Hit(Input.mousePosition);
        }
    }
}