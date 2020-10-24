﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCFlyAction : SSAction
{
    float gravity;          //重力加速度
    float speed;            //水平速度
    Vector3 direction;      //飞行方向
    float time;             //时间

    public static CCFlyAction GetSSAction(Vector3 direction, float speed)
    {
        CCFlyAction action = ScriptableObject.CreateInstance<CCFlyAction>();
        action.gravity = 4.5f; 
        action.time = 0;
        action.speed = speed;
        action.direction = direction;
        return action;
    }

    public override void Start()
    {

    }

    public override void Update()
    {
        time += Time.deltaTime;
        transform.Translate(Vector3.down * gravity * time * Time.deltaTime);
        transform.Translate(direction * speed * Time.deltaTime);
        if (this.transform.position.y < -6)
        {
            this.destroy = true;
            this.enable = false;
            this.callback.SSActionEvent(this);
        }

    }
}

