using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObserver {

    private IEnumerator UpDateTimeRoutine;
    private Dictionary<int,float> timeMap;
    private Dictionary<int,bool> inventoryMap;
    private Dictionary<int,bool> accomplishmentMap;
    public Dictionary<int,bool> InventoryMap { get{ return inventoryMap; } }
    public Dictionary<int,bool> AccomplishmentMap { get{ return accomplishmentMap; } }


    public float timeRemaning;

    public PlayerObserver(){ 
        timeMap = new Dictionary<int, float>();
        InitAccomplishmentMap();
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

    public void Accomplishment( int id ){
        accomplishmentMap[id] = true;
    }

    private void InitAccomplishmentMap(){
        accomplishmentMap = new Dictionary<int,bool>();
        // 0 gave coffee to op
        accomplishmentMap.Add( 0, false );
        // 1 gave bacon to oa
        accomplishmentMap.Add( 1, false );
        // 2 gave away your money to someone in need
        accomplishmentMap.Add( 2, false );

        // 4 comforted someone
        accomplishmentMap.Add( 4, false );
        // 5 was rewared
        accomplishmentMap.Add( 5, false );

        // 7 saved someone
        accomplishmentMap.Add( 7, false );

        // 8 spent time with someone special
        accomplishmentMap.Add( 8, false );

        // 10 killed somone
        accomplishmentMap.Add( 10, false );
        
    }

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
        inventoryMap.Add( 10, false );
        inventoryMap.Add( 11, false );

        
    }

    public bool CheckInventory( int id ){
        return inventoryMap[id];
    }

    public void UpdateInventory( int id, bool isActive ) {
        inventoryMap[id] = isActive;
    }

    

}
