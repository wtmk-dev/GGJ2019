using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBox : MonoBehaviour {
    private TextMeshProUGUI textBoxText;

    void Awake(){
        textBoxText = GetComponent<TextMeshProUGUI>();
    }

    public void SetActive( bool isActive ){
        gameObject.SetActive( isActive );
    }

    public void SetText( string text ){
        textBoxText.text = text;
    }
}
