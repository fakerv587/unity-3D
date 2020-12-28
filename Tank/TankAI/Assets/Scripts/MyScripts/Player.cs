using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Tank
{
    public delegate void DestroyPlayer();
    public static event DestroyPlayer destroyEvent;
    // Start is called before the first frame update
    void Start()
    {
        setHP(200);
    }

    // Update is called once per frame
    void Update()
    {
        if(getHP() <= 0){
            this.gameObject.SetActive(false);
            destroyEvent();
        }
    }
    public void moveForward(){
        gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * 30;
    }
    public void moveBackward(){
        gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * -30;
    }
    public void turnAround(float offsetX){
        float x = gameObject.transform.localEulerAngles.x;
        float y = gameObject.transform.localEulerAngles.y + offsetX * 2;
        gameObject.transform.localEulerAngles = new Vector3(x, y, 0);
    }
}
