using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameScreenController : MonoBehaviour {

    public static Action<Screen> OnScreenComplete;
    [SerializeField]
    private GameObject titleScreen, gameScreen, creditsScreen, fadeScreen;
    [SerializeField]
    private TextMeshProUGUI endingText;
    [SerializeField]
    private Sprite endGameSprite;
    private IEnumerator screenFade;
    private string endingString;
    private Image startImg;

    void OnEnable(){
        GameController.OnScreenChange += ScreenChanged;
    }

    void OnDisable(){
        GameController.OnScreenChange -= ScreenChanged;
    }

    void Awake(){
        startImg = fadeScreen.GetComponent<Image>();
    }

    public void StartGame(){
        if( OnScreenComplete != null ){
            OnScreenComplete( Screen.Title );
        }

        titleScreen.SetActive( false );
    }

    public void WakeUp(){
        gameScreen.SetActive( false );

        if( screenFade != null ){
            StopCoroutine( screenFade );
        }
        endingString = "Slept.";
        fadeScreen.SetActive( true ); 
        screenFade = FadeImageRoutine( true );
        StartCoroutine( screenFade );
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
        if( screenFade != null ){
            StopCoroutine( screenFade );
        }

        if( currentScreen == Screen.Title ){
            fadeScreen.SetActive( false );
            titleScreen.SetActive( true );
        }

        if( currentScreen == Screen.Game ){
            gameScreen.SetActive( true );
            fadeScreen.SetActive( true );
            screenFade = FadeImageRoutine( false );
            StartCoroutine( screenFade );
        }

        if( currentScreen == Screen.Credits ){
            fadeScreen.SetActive( true );
            startImg.sprite = endGameSprite;
            screenFade = FadeImageRoutine( true );
            StartCoroutine( screenFade );
            creditsScreen.SetActive( true );
            endingText.text = endingString;
        }

    }

    private IEnumerator FadeImageRoutine(bool isWake ) {
        if( isWake ){
            for ( float i = 1; i >= 0; i -= Time.deltaTime ) {
                // set color with i as alpha
                startImg.color = new Color(1, 1, 1, i);
                yield return new WaitForEndOfFrame();
            }
        } else {
             // loop over 1 second backwards
            for ( float i = 1; i >= 0; i -= Time.deltaTime ) {
                // set color with i as alpha
                startImg.color = new Color(1, 1, 1, i);
                yield return new WaitForEndOfFrame();
            }

            for ( float i = 0; i <= 1; i += Time.deltaTime ) {
                // set color with i as alpha
                startImg.color = new Color(1, 1, 1, i);
                yield return new WaitForEndOfFrame();
            }

            for ( float i = 1; i >= 0; i -= Time.deltaTime ) {
                // set color with i as alpha
                startImg.color = new Color(1, 1, 1, i);
                yield return new WaitForEndOfFrame();
            }

            for ( float i = 0; i <= 1; i += Time.deltaTime ) {
                // set color with i as alpha
                startImg.color = new Color(1, 1, 1, i);
                yield return new WaitForEndOfFrame();
            }

            for ( float i = 1; i >= 0; i -= Time.deltaTime ) {
                // set color with i as alpha
                startImg.color = new Color(1, 1, 1, i);
                yield return new WaitForEndOfFrame();
            }
        }
    
        fadeScreen.SetActive( false );
       
	}
}
