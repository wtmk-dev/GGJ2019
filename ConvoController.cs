using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConvoController : MonoBehaviour {

    [SerializeField]
    private List<ConversationTrigger> triggers;
    [SerializeField]
    private GameObject goTextBox;
    private TextBox textBox;

    void Awake(){
        foreach( var trigger in triggers ){
            trigger.OnConversationDisplay += DisplayConversation;
            trigger.OnConversationDisplay += HideConversation;
        }

        textBox = goTextBox.GetComponent<TextBox>();
        textBox.SetActive( false );
    }

    private void DisplayConversation( int id ){
        Debug.Log(id);
        switch(id){
            default:
            textBox.SetText( "" );
            break;
        }
    }

    private void HideConversation( int id ){
        textBox.SetText( "" );
    }
}
