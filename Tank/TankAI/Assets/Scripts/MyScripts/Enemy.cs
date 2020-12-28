using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Tank
{
    public delegate void RecycleEnemy(GameObject enemy);
    public static event RecycleEnemy recycleEnemy;
    private Vector3 playerLocation;
    private bool gameover;
    // Start is called before the first frame update
    void Start()
    {
        playerLocation = GameDirector.getInstance().currentSceneController.getPlayer().transform.position;
        StartCoroutine(shoot());
    }

    // Update is called once per frame
    void Update()
    {
        playerLocation = GameDirector.getInstance().currentSceneController.getPlayer().transform.position;
        gameover = GameDirector.getInstance().currentSceneController.getGameOver();
        if (!gameover)
       {
           if (getHP() <= 0 && recycleEnemy != null)
           {
               recycleEnemy(this.gameObject);
           }
           else
           {
               UnityEngine.AI.NavMeshAgent agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
               agent.SetDestination(playerLocation);
             
           }
       }
       else
       {
           UnityEngine.AI.NavMeshAgent agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
           agent.velocity = Vector3.zero;
           agent.ResetPath();
       }
   }
   IEnumerator shoot()
   {
       while (!gameover)
       {
           for(float i =1;i> 0; i -= Time.deltaTime)
           {
               yield return 0;
           }
           if(Vector3.Distance(playerLocation,gameObject.transform.position) < 14)
           {
               shoot(TankType.ENEMY);
           }
       }
   }
}
