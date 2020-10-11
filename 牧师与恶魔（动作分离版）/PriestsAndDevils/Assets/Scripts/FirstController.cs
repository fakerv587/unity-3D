using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, SceneController{

    private Role[] Priests;            
    private Role[] Devils;              
    private GameObject GroundFrom;     
    private GameObject GroundTo;      
    private GameObject Water;     
    private Boat boat;         
    private int fromDevilNum;
    private int fromPriestNum;
    private int toDevilNum;
    private int toPriestNum;
    private int state;    

    private UserGUI mygui;
    
    public Action actionManager;
    FirstController()
    {
        Priests = new Role[3];
        Devils = new Role[3];
    }

    // Use this for initialization
    void Start() {
        Director director = Director.GetInstance();      
        director.scene = this;
        actionManager = new Action();                          
        this.LoadResources();
    }

    public void LoadResources()
    {
        Debug.Log("load resource");

        state = -1;

        mygui = new UserGUI();

        fromDevilNum = fromPriestNum = 3;
        toDevilNum = toPriestNum = 0;

        GroundFrom = Object.Instantiate(Resources.Load("ground3", typeof(GameObject)), new Vector3(0, -5, 15), Quaternion.identity, null) as GameObject;
        GroundFrom.transform.localScale = new Vector3(20, 9, 15);
        GroundFrom.name = "groundfrom";
        GroundTo = Object.Instantiate(Resources.Load("ground3", typeof(GameObject)), new Vector3(0, -5, -15), Quaternion.identity, null) as GameObject;
        GroundTo.transform.localScale = new Vector3(20, 9, 15);
        GroundTo.name = "groundto";

        Water = Object.Instantiate(Resources.Load("Water", typeof(GameObject)), new Vector3(0, -6, 0), Quaternion.identity, null) as GameObject;
        Water.name = "water";

        boat = new Boat();

        for (int i = 0;i < 3;i ++)
        {
            Role temp = new Role("Sphere");
            temp.setName("Priest"+ i);
            Priests[i] = temp;
            float p_z = (float)(8 + i * 1.5);
            Priests[i].setOriginalPos(new Vector3(0, 1, p_z));
            Priests[i].setDestPos(new Vector3(0, 1, -p_z));
            Priests[i].character.transform.localScale = new Vector3(1.6f, 2f, 1.6f);
            Priests[i].character.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        for (int i = 0; i < 3; i++)
        {
            Role temp = new Role("Cube");
            temp.setName("Devil" + i);
            Devils[i] = temp;
            float p_z = (float)(13 + i * 1.5);
            Devils[i].setOriginalPos(new Vector3(0, 1, p_z));
            Devils[i].setDestPos(new Vector3(0, 1, -p_z));
            Devils[i].character.transform.localScale = new Vector3(1.6f, 2, 1.6f);
            Devils[i].character.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }

    public void print()
    {
        Debug.Log("hello world");
    }

    public Role findRoleByName(string name)
    {
        Role obj = null;
        for (int i = 0; i < 3; i++)
        {
            if (name == ("Priest" + i))
            {
                obj = Priests[i];
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (name == ("Devil" + i))
            {
                obj = Devils[i];
            }
        }
        return obj;
    }

    public int MapName(string name)
    {
        int obj = 0;
        for (int i = 0; i < 3; i++)
        {
            if (name == ("Priest" + i))
            {
                obj = i+1;
                return obj;
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (name == ("Devil" + i))
            {
                obj = i+4;
                return obj;
            }
        }
        return obj;
    }

    public int getPosition(string name)
    {
        if(name == "boat")
        {
            return boat.position;
        }
        else
        {
            return findRoleByName(name).position;
        }
    }

    public void moveto(string name)
    {
        if(boat.movestate != 0)
        {
            return;
        }
        if(name == "boat")
        {
            if(boat.position == 0 && boat.num > 0)
            {
                boat.position = 1;
                boat.movestate = 1;
                foreach(int num in boat.BoatState)
                {
                    if(num > 0 && num < 4)
                    {
                        fromPriestNum--;
                        toPriestNum++;
                    }
                    else if(num > 3)
                    {
                        fromDevilNum--;
                        toDevilNum++;
                    }
                }
                
            }
            else if(boat.num > 0)
            {
                boat.position = 0;
                boat.movestate = 2;
                foreach (int num in boat.BoatState)
                {
                    if (num > 0 && num < 4)
                    {
                        toPriestNum--;
                        fromPriestNum++;
                    }
                    else if (num > 3)
                    {
                        toDevilNum--;
                        fromDevilNum++;
                    }
                }
            }
        }
        else
        {
            Role obj = findRoleByName(name);
            if(obj.position == 0 && obj.position == boat.position && boat.num < 2)
            {
                boat.num++;
                if(boat.BoatState[0] == 0)
                {
                    obj.getBoat(1);
                    actionManager.GetBoat(obj, 1);
                    boat.BoatState[0] = MapName(name);
                }
                else
                {
                    obj.getBoat(2);
                    actionManager.GetBoat(obj, 2);
                    boat.BoatState[1] = MapName(name);
                }
            }
            else if(obj.position == 1 && obj.position == boat.position && boat.num < 2)
            {
                boat.num++;
                if (boat.BoatState[0] == 0)
                {
                    obj.getBoat(4);
                    actionManager.GetBoat(obj, 4);
                    boat.BoatState[0] = MapName(name);
                }
                else
                {
                    obj.getBoat(3);
                    actionManager.GetBoat(obj, 3);
                    boat.BoatState[1] = MapName(name);
                }
            }
            else if(obj.position == 2)
            {
                if(boat.position == 0)
                {
                    boat.num--;
                    boat.BoatState[obj.boatPos] = 0;
                    obj.MoveToOrigin();
                    actionManager.MoveToOrigin(obj);
                }
                else
                {
                    boat.num--;
                    boat.BoatState[obj.boatPos] = 0;
                    obj.MoveToDest();
                    actionManager.MoveToDest(obj);
                }
            }
        }
    }

    Role MapNumToRole(int num)
    {
        Role tmp = null;
        if(num<4 && num > 0)
        {
            tmp = Priests[num - 1];
        }
        else if(num >= 4 && num <= 6)
        {
            tmp = Devils[num - 4];
        }
        return tmp;
    }

    // Update is called once per frame
    void Update () {
        if(boat.movestate > 0)
        {
            actionManager.MoveBoat(boat, Priests, Devils);
        }


        if ((fromPriestNum != 0 && fromDevilNum > fromPriestNum) || (toPriestNum != 0 && toDevilNum > toPriestNum))
        {
            state = 0;
            mygui.setLose();
        }

        if (toDevilNum+toPriestNum == 6 && boat.num == 0)
        {
            state = 1;
            mygui.setWin();
        }
	}

    public void Reset()
    {
        for(int i = 0;i < 3;i ++)
        {
            Destroy(Priests[i].character);
            Destroy(Devils[i].character);
            Destroy(boat.thisboat);
            Destroy(GroundFrom);
            Destroy(GroundTo);
            Destroy(Water);
        }
        LoadResources();
    }


    void OnGUI()
    {
        mygui.display();
    }


}
