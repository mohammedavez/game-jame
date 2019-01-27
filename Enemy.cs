using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Enemy : MonoBehaviour
{
    public int health =100;
    public Transform target;
    public float chaseRange;
    public float speed;
    private int consume;
    private int escape;
    public int timeLeft = 100;
    public Player player;
    private int playerConsume;
    // Start is called before the first frame update
    void Start()
    {
     player = GameObject.Find("survivor-idle_knife_0").GetComponent<Player>();
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "player"){
            playerConsume=1;
            Debug.Log("Player consume enabled");
        }
    }
    void OnTriggerEnter2D(Collider2D col){
       // Debug.Log("holamallu");
            if(col.gameObject.tag == "player"){

                    // playerConsume=1;
                    // Debug.Log("Player consume enabled");
                    consume = 1;
            }
                
                else {
                    playerConsume=0;
                    Debug.Log("nahi marta");
                    consume = 0;
                    //Destroy(col.gameObject);
               }
            }
        

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire2")){
           if (consume==1 && health >=0){
                 Debug.Log("holamalluanderagaya");
                //if(Input.GetKeyDown(KeyCode.G)){
                    Debug.Log("mar gaya maderchod");
                Debug.Log(health);
                health=health-10;

                  }
        }
        // if (playerConsume==1 && player.health >=0)
        //     {
                
        //         //if(Input.GetKeyDown(KeyCode.G)){
        //         Debug.Log("player health");
        //         Debug.Log(player.health);
        //         player.health=player.health-10;

                  
        //      }
        float distanceToTarget = Vector3.Distance(transform.position,target.position);
        if(distanceToTarget<chaseRange){
            escape = 0;
            StartCoroutine("LoseTime");
            Debug.Log("Time Left = " + timeLeft);
            if (timeLeft <= 0)
                {
                    
                    StopCoroutine("LoseTime");
                    Debug.Log("Game Over");
                    Destroy(player);
                }
            //start chasing the target
            Debug.Log("Alert");
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y,targetDir.x)*Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis ( angle,Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,q,180);
            transform.Translate(Vector3.up*Time.deltaTime*speed);
        }else{
            escape = 1;
            timeLeft = 10;
        }
        if(health<=0){
        Debug.Log("ab koun hain maderchod, maaakii!");
        Destroy(gameObject);
        }
    }
    // void OnCollisionEnter2D(Collision2D col){
        
    //     if(col.gameObject.tag == "player"){
            
    //         takeDamage(5);
    //         if(health<=0){
    //         Destroy(gameObject);
    //         }
    //     }
    // }
    void takeDamage(int amount){
        health = health-amount;
    }
     IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("this is "+timeLeft);
            timeLeft--;
        }
    }
}
