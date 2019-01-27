using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static Action<Screen> OnScreenChange; 
    public Screen gameScreen;

    void OnEnable(){
        
    }

    void OnDisable(){

    }

    void Start(){
        ChangeScreen( Screen.Title );
    }

    private void ChangeScreen( Screen gameScreen ){
        this.gameScreen = gameScreen;
        if( OnScreenChange != null ){
            OnScreenChange( this.gameScreen );
        }
    }
    
}

public enum Screen { Title, Game, Credits };
