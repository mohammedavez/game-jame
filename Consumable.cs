using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public int health =100;
    private int consume;
    public GameObject consumable;
    public int playerPref;
    // Start is called before the first frame update
    void Start()
    {
        playerPref=PlayerPrefs.GetInt("strenght");
        Debug.Log("the player preference is"+playerPref);
    }

    // Update is called once per frame
    void Update()
    {
        playerPref=PlayerPrefs.GetInt("strenght");
         if(Input.GetButton("Fire2")){
           if (consume==1 && health >=0){
                Debug.Log("health of consumable "+health);
                if(playerPref == 10){
                health=health-10;
                }else if(playerPref==20){
                  health=health-20;  
                }
                if(health<=0){
                    Destroy(consumable);
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col){
       
            if(col.gameObject.tag == "player"){
                    consume = 1;
            }
                else {
                    consume = 0;
               }
            }
}
