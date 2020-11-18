﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager
{
    public static GameEventManager Instance = new GameEventManager();

    public delegate void ScoreEvent();
    public static event ScoreEvent ScoreChange;

    public delegate void GameoverEvent();
    public static event GameoverEvent GameoverChange;

    private GameEventManager() { }

    public void PlayerEscape()
    {
        if(ScoreChange != null)
        {
            ScoreChange();
        }
    }

    public void PlayerGameover()
    {
        if(GameoverChange != null)
        {
            GameoverChange();
        }
    }
}