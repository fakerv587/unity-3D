using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    FirstController controller;
    IActionManager actionManager;
    DiskFactory diskFactory;
    Score Score;
    UserGUI userGUI;
    int[] roundDisks;
    bool isInfinite;
    int round;
    int sendCnt;
    float sendTime;

    void Start()
    {
        controller = (FirstController)SSDirector.GetInstance().CurrentScenceController;
        actionManager = Singleton<CCActionManager>.Instance;
        diskFactory = Singleton<DiskFactory>.Instance;
        Score = new Score();
        userGUI = Singleton<UserGUI>.Instance;
        sendCnt = 0;
        round = 0;
        sendTime = 0;
        isInfinite = false;
        roundDisks = new int[] { 3, 5, 8, 13, 21 };
    }

    public void Reset()
    {
        sendCnt = 0;
        round = 0;
        sendTime = 0;
        Score.Reset();
    }

    public void Record(Disk disk)
    {
        Score.Record(disk);
    }

    public int GetPoints()
    {
        return Score.GetPoints();
    }

    public void SetMode(bool isInfinite)
    {
        this.isInfinite = isInfinite;
    }

    public void SetFlyMode(bool isPhysis)
    {
        actionManager = isPhysis ? Singleton<PhysisActionManager>.Instance : Singleton<CCActionManager>.Instance as IActionManager ;
    }

    public void SendDisk()
    {
        //从工厂生成一个飞碟
        GameObject disk = diskFactory.GetDisk(round);
        //设置飞碟的随机位置
        disk.transform.position = new Vector3(-disk.GetComponent<Disk>().direction.x * 7, UnityEngine.Random.Range(0f, 8f), 0);
        disk.SetActive(true);
        //设置飞碟的飞行动作
        actionManager.Fly(disk, disk.GetComponent<Disk>().speed, disk.GetComponent<Disk>().direction);
    }

    // Update is called once per frame
    void Update()
    {
        sendTime += Time.deltaTime;
        //每隔1s发送一次飞碟
        if (sendTime > 1)
        {
            sendTime = 0;
            //每次发送至多5个飞碟
            for (int i = 0; i < 5 && sendCnt < roundDisks[round]; i++)
            {
                sendCnt++;
                SendDisk();
            }
            //判断是否需要重置轮次，不需要则输出游戏结束
            if (sendCnt == roundDisks[round] && round == roundDisks.Length - 1)
            {
                if (isInfinite)
                {
                    round = 0;
                    sendCnt = 0;
                    userGUI.SetMessage("");
                }
                else
                {
                    userGUI.SetMessage("Game Over!");
                }
            }
            //更新轮次
            if (sendCnt == roundDisks[round] && round < roundDisks.Length - 1)
            {
                sendCnt = 0;
                round++;
            }
        }
    }
}