using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemytype2 : MonoBehaviour
{
    
    public Transform target;
    public float chaseRange;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position,target.position);
        if(distanceToTarget<chaseRange){
            //start chasing the target
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y,targetDir.x)*Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis ( angle,Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,q,180);
            transform.Translate(Vector3.up*Time.deltaTime*speed);
        }
    }
}
