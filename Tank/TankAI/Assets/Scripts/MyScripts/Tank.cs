using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    private float hp = 100.0f;
    public Tank(){
        hp = 100.0f;
    }
    public float getHP(){
        return hp;
    }
    public void setHP(float hp){
        this.hp = hp;
    }
    public void shoot(TankType type){
        GameObject bullet = Singleton<Factory>.Instance.getBullets(type);
        bullet.transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z) + transform.forward * 1.5f;
        bullet.transform.forward = transform.forward; 
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 20, ForceMode.Impulse);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
