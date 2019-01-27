using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour {

    private Rigidbody2D rb2d;
    private float vertical;
    private float horizontal;
    private float speed = 2;

    void Awake(){
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate() {
        if( rb2d != null ){
            Move();
        }
    }
    
    private void Move(){
        horizontal = Input.GetAxis( "Horizontal" );
        vertical = Input.GetAxis( "Vertical" );
        Vector3 dir = new Vector3( horizontal, vertical, 0f );
        rb2d.velocity = dir;
    }

    

}
