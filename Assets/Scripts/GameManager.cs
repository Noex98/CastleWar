using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;
    public static GameManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null) {
                    GameObject go = new GameObject();
                    go.name = "GameManager";
                    _instance = go.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }
    
    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        }
    }

    private void Start(){
        EventSystem.FireEvent(EventType.TurnStart);
    }

    public int activeTurn = 0;
    public int[] heartScore = new int[4] {3, 3, 3, 3};
    public int[] teamOneBases = new int[5];
    public int[] teamTwoBases = new int[5];

    

    private int getCurrentTeam(){
        return activeTurn < 2 ? 1 : 2;
    }

    public void HandleBaseHit(int baseId){
        int currentTeam = getCurrentTeam();
        //bool baseAlreadyCaptured = 
        ChangeTurn();
    }

    public void HandleCastleHit(int castleId){
        if(heartScore[castleId] > 0) {
            heartScore[castleId] -= 1;
        }
        EventSystem.FireEvent(EventType.CastleHit);
        ChangeTurn();
    }

    public void HandleMiss(){
        Debug.Log("Miss");
        ChangeTurn();
    }

    public void EndGame(){
        Debug.Log("Game ended");
    }

    private int getNextPlayersTurn(int activeTurn){
        int nextPlayer = activeTurn >= 3 ? 0 : activeTurn + 1;
        return heartScore[nextPlayer] == 0 ? getNextPlayersTurn(nextPlayer) : nextPlayer;
    }

    private void ChangeTurn(){
        EventSystem.FireEvent(EventType.TurnOver);
        activeTurn = getNextPlayersTurn(activeTurn);
        EventSystem.FireEvent(EventType.TurnStart);
    }
}
