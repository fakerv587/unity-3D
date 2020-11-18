using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCollide : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        SSDirector director;
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            director = SSDirector.getInstance();
            int i = director.currentScenceController.GetCollector();
            i = i + 1;
            director.currentScenceController.setCollect(i);
        }
    }
}
