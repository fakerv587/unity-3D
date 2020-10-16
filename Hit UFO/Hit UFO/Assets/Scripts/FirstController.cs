using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour
{
    int[] RoundDisk;//每轮应该发送的飞碟
    bool IsFinite;//是否为无尽模式
    int Points;//分数
    int Round;//回合
    int UsedDisk;//已经使用过的飞碟
    int FreeDisk;//未使用过的飞碟
    float SendTime;//发送飞碟的时间
    // Start is called before the first frame update
    void Start()
    {
        Load();
    }
    public void Load(){
        Round = 0;
        Points = 0;
        UsedDisk = 0;
        SendTime = 0;
        IsFinite = false;
        RoundDisk = new int[] {5,6,7,8,9};
    }
    public void SendDisk(){
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
