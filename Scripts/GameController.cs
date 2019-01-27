using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static Action<Screen> OnScreenChange; 
    public Screen gameScreen;

    void OnEnable(){
        GameScreenController.OnScreenComplete += ScreenComplete;
    }

    void OnDisable(){
        GameScreenController.OnScreenComplete -= ScreenComplete;
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

    private void ScreenComplete( Screen completedScreen ){
         if( completedScreen == Screen.Title ){
            gameScreen = Screen.Game;
        }

        if( completedScreen == Screen.Game ){
            gameScreen = Screen.Credits;
        }

        if( completedScreen == Screen.Credits ){
            gameScreen = Screen.Game;
        }

        ChangeScreen( gameScreen );
    }

    public static void EndGame() {
        if( OnScreenChange != null ){
            OnScreenChange( Screen.Credits );
        } 
    }

}

public enum Screen { Title, Game, Credits };
