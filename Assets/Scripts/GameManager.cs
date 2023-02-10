using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int activeTurn = 0;
    public int[] heartScore = new int[] {3, 3, 3, 3};
    public int[] teamOneBases = new int[5];
    public int[] teamTwoBases = new int[5];

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this); 
        } else {
            Instance = this; 
        }
    }

    private int getCurrentTeam(){
        return activeTurn < 2 ? 1 : 2;
    }

    void handleBaseHit(int baseId){
        int currentTeam = getCurrentTeam();
        
        changeTurn();
    }

    void handleCastleHit(int CastleId){
        Debug.Log("Castle hit");
        changeTurn();
    }

    void handleMiss(){
        Debug.Log("Miss");
        changeTurn();
    }

    void endGame(){
        Debug.Log("Game ended");
    }

    private void changeTurn(){
        activeTurn = activeTurn >= 3 ? 0 : activeTurn + 1;
        Debug.Log("Change turn");
    }
}
