using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    public float moveSpeed;
    private Vector3 moveDirection;
    public float turnSpeed;

    void Start()
    {
        moveDirection = Vector3.right; 

    }

    // Update is called once per frame
    void Update()
    
    {
        Event e = Event.current;
// 1
Vector3 currentPosition = transform.position;
// 2
if(Input.GetButton("Fire1")) {
  // 3
  Vector3 moveToward = Camera.main.ScreenToWorldPoint( Input.mousePosition );
  // 4
  moveSpeed=5;
  moveDirection = moveToward - currentPosition;
  moveDirection.z = 0; 
  moveDirection.Normalize();
}
if(!Input.GetButton("Fire1")){
    moveSpeed=0;
}
Vector3 target = moveDirection * moveSpeed + currentPosition;
transform.position = Vector3.Lerp( currentPosition, target, Time.deltaTime );

  float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
transform.rotation = 
  Quaternion.Slerp( transform.rotation, 
                    Quaternion.Euler( 0, 0, targetAngle ), 
                    turnSpeed * Time.deltaTime );

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed,0,0);
        }else if(Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(speed,0,0);
        }
        else if(Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(0,-speed,0);
        }
        else if(Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(0,speed,0);
        }

    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "enemy"){
            Destroy(col.gameObject);
        }
    }
}
