using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameScreenController : MonoBehaviour {

    public static Action<Screen> OnScreenComplete;
    [SerializeField]
    private GameObject titleScreen, gameScreen, creditsScreen;
    private TextMeshProUGUI endingText;

    void OnEnable(){
        GameController.OnScreenChange += ScreenChanged;
    }

    void OnDisable(){
        GameController.OnScreenChange -= ScreenChanged;
    }

    public void StartGame(){
        if( OnScreenComplete != null ){
            OnScreenComplete( Screen.Title );
        }

        titleScreen.SetActive( false );
    }

    public void WakeUp(){
        gameScreen.SetActive( false );
    }

    private void ScreenChanged( Screen currentScreen ){
        if( currentScreen == Screen.Title ){
            titleScreen.SetActive( true );
        }

        if( currentScreen == Screen.Game ){
            gameScreen.SetActive( true );
        }

        if( currentScreen == Screen.Credits ){
            creditsScreen.SetActive( true );
        }
    }
}
