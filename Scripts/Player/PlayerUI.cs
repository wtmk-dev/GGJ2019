using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour {

    [SerializeField]
    private GameObject goInventoryText, goClockText;
    private TextMeshProUGUI inventoryText, clockText;
    private bool timerStarted;
    private float timeLeft = 1.5f;
    private int hour = 7;
    private int min = 0;

    void OnEnable(){
        GameController.OnScreenChange += ScreenChange;
    }

    void OnDisable(){
        GameController.OnScreenChange -= ScreenChange;
    }

    void Awake(){
        inventoryText = goInventoryText.GetComponent<TextMeshProUGUI>();
        clockText = goClockText.GetComponent<TextMeshProUGUI>();
    }

    void Update(){
        if( timerStarted ){
            timeLeft -= Time.deltaTime;
            if ( timeLeft < 0 ) {
                min++;
                if( min < 10 ){
                    clockText.text = hour + ":" + "0" + min + " AM";
                }else if( min < 60 ){
                    clockText.text = hour + ":" + min + " AM";
                }else if( min >= 60 ){
                    hour++;
                    min = 0;
                    clockText.text = hour + ":00 AM";
                }
                timeLeft = 1.5f;
            }
        }
    }

    private void ScreenChange( Screen screen ){
        if( screen == Screen.Game ){
            timerStarted = true;
        }
    }

    public void UpdateInventory( Dictionary<int,bool> inventory ){
        inventoryText.text = "";

        if( inventory[0] ){
            inventoryText.text = "Coffee";
        }

        if( inventory[1] ){
            inventoryText.text += "\nBACON!";
        }

        if( inventory[2] && inventory[3] ){
            inventoryText.text += "\n$$$";
        }

        if( inventory[4] ){
            inventoryText.text += "\nSented scarf";
        }

        if( inventory[7] ){
            inventoryText.text += "\nKnife";
        }

        if( inventory[9] ){
            inventoryText.text += "\nThe Beef";
        }

        

    }

}
