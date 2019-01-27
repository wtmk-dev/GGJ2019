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
    [SerializeField]
    private TextMeshProUGUI endingText;

    private string endingString;

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

    public void UpdateAccomplishments( Dictionary<int,bool> accompMap ){
        endingString = "";

        if( accompMap[0] ){
            endingString += "\nGot coffee for an important person.";
        }

        if( accompMap[1] ){
            endingString += "\nGave treats to imporant animals.";
        }

        if( accompMap[2] ){
            endingString += "\nGave away your money to someone in need.";
        }

        if( accompMap[4] ){
            endingString += "\nConforted someone.";
        }

        if( accompMap[7] ){
            endingString += "\nSaved someone.";
        }

        if( accompMap[5] ){
            endingString += "\nClaimed a reward.";
        }

        if( accompMap[8] ){
            endingString += "\nSpent time with someone special.";
        }

        if( accompMap[10] ){
            endingString += "\nDid murder.";
        }

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
            endingText.text = endingString;
        }
    }
}
