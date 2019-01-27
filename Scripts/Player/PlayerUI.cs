using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour {

    [SerializeField]
    private GameObject goInventoryText;
    private TextMeshProUGUI inventoryText;

    void Awake(){
        inventoryText = goInventoryText.GetComponent<TextMeshProUGUI>();
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
