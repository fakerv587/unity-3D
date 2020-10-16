using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction
{
    public CCActionManager actionManager;
    public DiskFactory diskFactory;
    int[] roundDisks;//每轮应该发送的飞碟
    bool isInfinite;//是否为无尽模式
    int points;//分数
    int round;//回合
    int UsedDisk;//已经使用过的飞碟
    int sendCnt;//未使用过的飞碟
    float sendTime;//发送飞碟的时间
    // Start is called before the first frame update
    void Start()
    {
        LoadResources();
    }
    public void LoadResources(){
        SSDirector.GetInstance().CurrentScenceController = this;
        gameObject.AddComponent<DiskFactory>();
        gameObject.AddComponent<CCActionManager>();
        gameObject.AddComponent<UserGUI>();
        diskFactory = Singleton<DiskFactory>.Instance;
        round = 0;
        points = 0;
        sendCnt = 0;
        sendTime = 0;
        isInfinite = false;
        roundDisks = new int[] {5,6,7,8,9};
    }
    public void SendDisk(){
        GameObject disk = diskFactory.GetDisk(round);
        disk.transform.position = new Vector3(-disk.GetComponent<Disk>().direction.x * 7, UnityEngine.Random.Range(0f, 8f), 0);
        disk.SetActive(true);
        actionManager.Fly(disk, disk.GetComponent<Disk>().speed, disk.GetComponent<Disk>().direction);
    }
    public void Hit(Vector3 position)
    {
        Camera ca = Camera.main;
        Ray ray = ca.ScreenPointToRay(position);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if (hit.collider.gameObject.GetComponent<Disk>() != null)
            {
                //将飞碟移至底端，触发飞行动作的回调
                hit.collider.gameObject.transform.position = new Vector3(0, -7, 0);
                //积分
                points += hit.collider.gameObject.GetComponent<Disk>().points;
                //更新GUI数据
                gameObject.GetComponent<UserGUI>().points = points;
            }
        }
    }

    public void Restart()
    {
        gameObject.GetComponent<UserGUI>().gameMessage = "";
        round = 0;
        sendCnt = 0;
        points = 0;
        gameObject.GetComponent<UserGUI>().points = points;
    }

    public void SetMode(bool isInfinite)
    {
        this.isInfinite = isInfinite;
    }

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
                    gameObject.GetComponent<UserGUI>().gameMessage = "";
                }
                else
                {
                    gameObject.GetComponent<UserGUI>().gameMessage = "Game Over!";
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
