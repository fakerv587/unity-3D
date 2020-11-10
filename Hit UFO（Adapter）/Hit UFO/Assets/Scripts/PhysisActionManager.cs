﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysisActionManager : SSActionManager, ISSActionCallback, IActionManager
{
    PhysisFlyAction flyAction;
    FirstController controller;

    protected new void Start()
    {
        controller = (FirstController)SSDirector.GetInstance().CurrentScenceController;
    }

    public void Fly(GameObject disk, float speed, Vector3 direction)
    {
        flyAction = PhysisFlyAction.GetSSAction(direction, speed);
        RunAction(disk, flyAction, this);
    }

    public void SSActionEvent(SSAction source,
    SSActionEventType events = SSActionEventType.Competed,
    int intParam = 0,
    string strParam = null,
    Object objectParam = null)
    {
        controller.FreeDisk(source.gameObject);
    }
}