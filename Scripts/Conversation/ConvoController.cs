using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConvoController : MonoBehaviour {

    [SerializeField]
    private List<GameObject> triggers;
    [SerializeField]
    private GameObject goTextBox, goQestionBox, goPlayerController;
    private ITextBox textBox, questionBox;
    private PlayerController playerController;
    private List<ConversationTrigger> conversationTriggers;
    private bool hasTriggerd = false;

    void OnDisable(){
        if( conversationTriggers.Count > 0 ){
            foreach( var ct in conversationTriggers ){
                ct.OnConversationDisplay -= DisplayConversation;
                ct.OnConversationHide -= HideConversation;
            }
        }
    }

    void Awake(){
        textBox = goTextBox.GetComponent<TextBox>();
        questionBox = goQestionBox.GetComponent<TextBox>();
        playerController = goPlayerController.GetComponent<PlayerController>();
    }

    void Start(){
        conversationTriggers = new List<ConversationTrigger>();

        foreach( var trigger in triggers ){
            ConversationTrigger ct = trigger.GetComponent<ConversationTrigger>();
            Debug.Log( ct );
            ct.OnConversationDisplay += DisplayConversation;
            ct.OnConversationHide += HideConversation;
            conversationTriggers.Add( ct );
        }

        playerController.SetConversationTriggers( conversationTriggers );
        textBox.SetText( "" );
        questionBox.SetText( "" );
    }

    private void DisplayConversation( int id ){
        Debug.Log(id);
        switch(id){
            case 0:
            textBox.SetText( "Important person: Hello! I could Really use some coffee!" );
            if( playerController.observer.CheckInventory(id) ){
                questionBox.SetText( "Give coffee? Press Y for yes." );
            }
            break;
            case 1:
            textBox.SetText( "Important animals: BORK! BORK! (we like bacon...)" );
            if( playerController.observer.CheckInventory(id) ){
                questionBox.SetText( "Give bacon? Press Y for yes." );
            }
            break;
            case 2:
            textBox.SetText( "Someone: Hey im hungry got any moeny i can eat?" );
            if( playerController.observer.CheckInventory(id) ){
                questionBox.SetText( "Give money? Press Y for yes." );
            }
            break;
            case 3:
            textBox.SetText( "Coffee Shop: Would you like to buy some coffee?" );
            if( playerController.observer.CheckInventory(id) ){
                questionBox.SetText( "Give money? Press Y for yes." );
            }
            break;
            case 4:
            textBox.SetText( "Sad person: They just left... you know?" );
            if( playerController.observer.CheckInventory(id) ){
                questionBox.SetText( "Whipe tiers? Press Y for yes." );
            }
            break;
            case 5:
            textBox.SetText( "Almost hurt person: Thanks! Yo da best!" );
            questionBox.SetText( "Would you like a reward? Press Y for yes." );
            break;
            case 6:
            if( !hasTriggerd ){
                textBox.SetText( "Someone in danger: HELP! PLEASE HELP!" );
                hasTriggerd = true;
            }
            break;
            case 7:
            textBox.SetText( "Mean person: Nothing to see here move along" );
            if( playerController.observer.CheckInventory(id) ){
                questionBox.SetText( "Would you like to stab? Press Y for yes." );
            }else{
                questionBox.SetText( "Stand your ground? Press Y for yes." );
            }
            break;
            case 8:
            textBox.SetText( "Adorable person: *.* ohhh!!! Hi boo :* come hang out withs me!? " );
            questionBox.SetText( "Press Y for yes." );
            break;
            case 9:
            textBox.SetText( "Oniking animals: WHERES THE BEEF?" );
            if( playerController.observer.CheckInventory(id) ){
                questionBox.SetText( "Show them where it is? Press Y for yes." );
            }
            break;
            case 10:
            if( playerController.observer.timeRemaning > 0 ){
                textBox.SetText( "You position is no longer needed" );
            }else{
                 textBox.SetText( "You are FIRED!" );
            }
            break;
            case 11:
            textBox.SetText( "Extra adorable person: Don't worry so much we will alwasy have eachother.\n<3 u 5 ever..." );
            break;
            case 12:
            textBox.SetText( "Saved person: That could have been the end for me." );
            break;
        }   
    }

    private void HideConversation( int id ){
        textBox.SetText( "" );
        questionBox.SetText( "" );
    }

}
