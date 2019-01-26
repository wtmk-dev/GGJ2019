using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour {

    public Action<int> OnConversationDisplay;
    public Action<int> OnConversationHide;
    [SerializeField]
    private int ID;

    void OnTriggerEnter2D( Collider2D other ) {
        Debug.Log( other );
        if( other.gameObject.tag == "Player" ){
            if( OnConversationDisplay != null ){
                OnConversationDisplay( ID );
            }
        }
    }

    void OnTriggerExit2D( Collider2D other ) {
        Debug.Log( other );
        if( other.gameObject.tag == "Player" ){
            if( OnConversationHide != null ){
                OnConversationHide( ID );
            }
        }
    }
}
