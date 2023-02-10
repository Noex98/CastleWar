using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { 
        get {
            if(_instance == null) {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    public int activeTurn = 0;
    public int[] heartScore = new int[] {3, 3, 3, 3};
    public int[] teamOneBases = new int[5];
    public int[] teamTwoBases = new int[5];

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private int getCurrentTeam(){
        return activeTurn < 2 ? 1 : 2;
    }

    public void handleBaseHit(int baseId){
        int currentTeam = getCurrentTeam();
        //bool baseAlreadyCaptured = 
        changeTurn();
    }

    public void handleCastleHit(int castleId){
        if(heartScore[castleId] > 0) {
            heartScore[castleId] -= 1;
        }
        EventSystem.FireEvent(EventType.CastleHit);
        changeTurn();
    }

    public void handleMiss(){
        Debug.Log("Miss");
        changeTurn();
    }

    public void endGame(){
        Debug.Log("Game ended");
    }

    private void changeTurn(){
        activeTurn = activeTurn >= 3 ? 0 : activeTurn + 1;
        Debug.Log("Change turn");
    }
}

