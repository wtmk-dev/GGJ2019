﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public PlayerObserver observer;
    private int currentId;
    private bool isInteracting;
    [SerializeField]
    private GameObject goPlayerUI, goGameScreenController;
    private PlayerUI playerUI;
    private float timeWith;
    private List<ConversationTrigger> conversationTriggers;

    private GameScreenController gsController;

    void OnTriggerEnter2D(Collider2D other){
        ConversationTrigger co = other.GetComponent<ConversationTrigger>();

        if( co != null ){
            timeWith = 0f;
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        ConversationTrigger co = other.GetComponent<ConversationTrigger>();

        if( co != null ){
            timeWith += Time.deltaTime;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        ConversationTrigger co = other.GetComponent<ConversationTrigger>();

        if( co != null ){
            observer.UpdateTimeMap( co.id, timeWith );
            timeWith = 0f;
        }
    }

    void OnDisable(){
        foreach( var ct in conversationTriggers ){
            ct.OnConversationDisplay -= OnEventEntered;
            ct.OnConversationHide -= OnEventLeft;
        }
    }

    void Awake() {
        Init();
    }

    void Update() {
        if( isInteracting && Input.GetKey( KeyCode.Y ) ){
            switch(currentId){
                case 0:
                observer.UpdateInventory( currentId, false );
                observer.Accomplishment( currentId );
                break;
                case 1:
                observer.UpdateInventory( currentId, false );
                observer.Accomplishment( currentId );
                break;
                case 2:
                observer.UpdateInventory( currentId, false );
                observer.UpdateInventory( currentId + 1, false );
                observer.UpdateInventory( 7, true );
                observer.Accomplishment( currentId );
                break;
                case 3:
                observer.UpdateInventory( currentId, false );
                observer.UpdateInventory( currentId - 1, false );
                observer.UpdateInventory( 0, true );
                break;
                case 4:
                observer.UpdateInventory( currentId, false);
                observer.Accomplishment( currentId );
                break;
                case 5:
                observer.UpdateInventory( 4, true );
                observer.Accomplishment( currentId );
                break;
                case 7:
                if( observer.InventoryMap[currentId] ){
                    observer.Accomplishment( 10 );
                }
                observer.Accomplishment( currentId );
                observer.UpdateInventory( currentId, false );
                observer.UpdateInventory( 9, true );
                break;
                case 8:
                observer.Accomplishment( currentId );
                break;
                case 9:
                observer.UpdateInventory( currentId, false );
                observer.UpdateInventory( 1, true );
                break;
                case 10:
                observer.UpdateInventory( 7, false );
                observer.Accomplishment( 10 );
                break;
            }

            foreach (var item in conversationTriggers ) {
                item.Activate( currentId );
            }
            
            playerUI.UpdateInventory( observer.InventoryMap );
            gsController.UpdateAccomplishments( observer.AccomplishmentMap );
        }
    }

    public void Init(){
        observer = new PlayerObserver();
        playerUI =  goPlayerUI.GetComponent<PlayerUI>();
        playerUI.UpdateInventory( observer.InventoryMap );

        conversationTriggers = new List<ConversationTrigger>();
        gsController = goGameScreenController.GetComponent<GameScreenController>();
    }

    public void SetConversationTriggers( List<ConversationTrigger> conversationTriggers ) {
        this.conversationTriggers = conversationTriggers;

        foreach( var ct in conversationTriggers ){
            ct.OnConversationDisplay += OnEventEntered;
            ct.OnConversationHide += OnEventLeft;
        }
    }

    private void OnEventEntered( int id ){
        Debug.Log( "playerController " + id );

        if ( observer.CheckInventory(id) ){
             currentId = id;
             isInteracting = true;
        }

        if( id == 5 || id == 8 || id == 7 || id == 10 ){
            currentId = id;
            isInteracting = true;
        }
    }

    private void OnEventLeft( int id ){
        currentId = -1;
        isInteracting = false;
    }



}
