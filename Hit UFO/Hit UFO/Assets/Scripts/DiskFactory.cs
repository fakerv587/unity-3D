using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskFactory : MonoBehaviour
{
    public GameObject disk_Prefab;              //飞碟预制
    private List<Disk> used;                //正被使用的飞碟
    private List<Disk> free;                //空闲的飞碟

    public void Start()
    {
        used = new List<Disk>();
        free = new List<Disk>();
        disk_Prefab = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/UFO"), Vector3.zero, Quaternion.identity);
        disk_Prefab.SetActive(false);
    }

    public GameObject GetDisk(int round)
    {
        GameObject disk;
        //如果有空闲的飞碟，则直接使用，否则生成一个新的
        if (free.Count > 0)
        {
            disk = free[0].gameObject;
            free.Remove(free[0]);
        }
        else
        {
            disk = GameObject.Instantiate<GameObject>(disk_Prefab, Vector3.zero, Quaternion.identity);
            disk.AddComponent<Disk>();
        }
        //按照round来设置飞碟属性
        //飞碟的等级 = 0~2之间的随机数 * 轮次数
        //0~4:  红色飞碟  
        //4~7:  绿色飞碟  
        //7~10: 蓝色飞碟
        float level = UnityEngine.Random.Range(0, 2f) * (round + 1);
        if (level < 4)
        {
            disk.GetComponent<Disk>().points = 1;
            disk.GetComponent<Disk>().speed = 2.0f;
            disk.GetComponent<Disk>().direction = new Vector3(UnityEngine.Random.Range(-1f, 1f) > 0 ? 2 : -2, 1, 0);
            disk.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (level > 7)
        {
            disk.GetComponent<Disk>().points = 3;
            disk.GetComponent<Disk>().speed = 4.0f;
            disk.GetComponent<Disk>().direction = new Vector3(UnityEngine.Random.Range(-1f, 1f) > 0 ? 2 : -2, 1, 0);
            disk.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            disk.GetComponent<Disk>().points = 2;
            disk.GetComponent<Disk>().speed = 3.0f;
            disk.GetComponent<Disk>().direction = new Vector3(UnityEngine.Random.Range(-1f, 1f) > 0 ? 2 : -2, 1, 0);
            disk.GetComponent<Renderer>().material.color = Color.green;
        }
        used.Add(disk.GetComponent<Disk>());
        return disk;
    }

    public void FreeDisk(GameObject disk)
    {
        //找到使用中的飞碟，将其踢出并加入到空闲队列
        foreach (Disk disk1 in used)
        {
            if (disk1.gameObject.GetInstanceID() == disk.GetInstanceID())
            {
                disk.SetActive(false);
                free.Add(disk1);
                used.Remove(disk1);
                break;
            }
        }
    }
}