using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObserver {

    private IEnumerator UpDateTimeRoutine;
    private Dictionary<int,float> timeMap;
    private Dictionary<int,bool> inventoryMap;
    public Dictionary<int,bool> InventoryMap { get{ return inventoryMap; } }

    public float timeRemaning;

    public PlayerObserver(){ 
        timeMap = new Dictionary<int, float>();
        InitInventoryMap();
    }

    public void UpdateTimeMap( int id, float time ){
        try{
            float t = timeMap[id];
            t += time;
            timeMap[id] = t;
            Debug.Log( timeMap[id] );
        }catch{
            timeMap.Add( id, time );
            Debug.Log( " catch " + timeMap[id] );
        }
    }

    //private void Acomplishments

    private void InitInventoryMap(){
        inventoryMap = new Dictionary<int,bool>();
        // 0 coffee
        inventoryMap.Add( 0, false );
        // 1 bacon
        inventoryMap.Add( 1, false );
        // 2 money
        inventoryMap.Add( 2, true );
        // 3 money
        inventoryMap.Add( 3, true );
        // 4 sented scarf
        inventoryMap.Add( 4, false );
        inventoryMap.Add( 5, false );
        inventoryMap.Add( 6, false );
        // 7 knife
        inventoryMap.Add( 7, false );
        inventoryMap.Add( 8, false );
        // 9 beef
        inventoryMap.Add( 9, false );
        
    }

    public bool CheckInventory( int id ){
        return inventoryMap[id];
    }

    public void UpdateInventory( int id, bool isActive ) {
        inventoryMap[id] = isActive;
    }

    

}
