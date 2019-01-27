using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionBox : MonoBehaviour,ITextBox {
    private TextMeshProUGUI textBoxText;

    void Awake(){
        textBoxText = GetComponent<TextMeshProUGUI>();
    }

    public void SetActive( bool isActive ){
        gameObject.SetActive( isActive );
    }

    public void SetText( string text ){
        Debug.Log(text);
        textBoxText.text = text;
    }
}
