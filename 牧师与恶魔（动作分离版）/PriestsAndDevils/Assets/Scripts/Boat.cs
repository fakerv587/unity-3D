using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat{
    public int[] BoatState; 
    public int num;         
    public int position;        
    public GameObject thisboat;
    public Move moveto;
    public int movestate;   
    public Boat()
    {
        movestate = 0;
        num = 0;
        position = 0;
        BoatState = new int[2];
        BoatState[0] = BoatState[1] = 0;
        thisboat = Object.Instantiate(Resources.Load("Boat4", typeof(GameObject)), new Vector3(0, -3, 4), Quaternion.identity, null) as GameObject;
        thisboat.name = "boat";
        var unused = thisboat.AddComponent(typeof(Move)) as Move;
        thisboat.AddComponent<BoxCollider>();

    }


}
