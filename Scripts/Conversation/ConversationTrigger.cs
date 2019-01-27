using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ConversationTrigger : MonoBehaviour {

    public Action<int> OnConversationDisplay;
    public Action<int> OnConversationHide;
    public int id;

    void Awake(){
        DOTween.Init();
    }

    void OnTriggerEnter2D( Collider2D other ) {
        Debug.Log( other );
        if( other.gameObject.tag == "Player" ){
            Debug.Log( id + " will fire" );
            if( OnConversationDisplay != null ){
                OnConversationDisplay( id );
            }
        }
    }

    void OnTriggerExit2D( Collider2D other ) {
        Debug.Log( other );
        if( other.gameObject.tag == "Player" ){
            if( OnConversationHide != null ){
                OnConversationHide( id );
            }
        }
    }

    public void Activate( int id ){
        if( this.id == 7 && id == 7 || this.id == 10 && id == 10 ){
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
            gameObject.GetComponentInChildren<BoxCollider2D>().enabled = false;
            transform.DOLocalMove( new Vector3( -4f, 20f, 0f ), 1.5f );
        }

        if( this.id == 8 && id == 8 ){
            //transform.position = new Vector2( 0, 35f );
            transform.DOLocalMove( new Vector3( -1.8f, 31.2f, 0f ), 1.5f );
            this.id = 11;
        }

        if( this.id == 5 && id == 5 ){
            this.id = 12;
        }
    }
}
