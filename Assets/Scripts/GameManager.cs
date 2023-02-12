using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;
    public int activeTurn = 0;
    public int[] heartScore = new int[4] {3, 3, 3, 3};
    public int[] baseState = {0, 0, 0};

    public int winner;

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

    public int getCurrentTeam(){
        return activeTurn < 2 ? 1 : 2;
    }

    public void HandleBaseHit(int baseId){
        int currentTeam = getCurrentTeam();
        baseState[baseId] = currentTeam;
        EventSystem.FireEvent(EventType.BaseHit);
        EndTurn();
    }

    public void HandleCastleHit(int castleId){
        if(heartScore[castleId] > 0) {
            heartScore[castleId] -= 1;
        }
        EventSystem.FireEvent(EventType.CastleHit);
        EndTurn();
    }

    public void HandleMiss(){
        EndTurn();
    }

    public void EndGame(int winner){
        this.winner = winner;
        EventSystem.FireEvent(EventType.GameOver);
    }

    private int getNextPlayersTurn(int activeTurn){
        int nextPlayer = activeTurn >= 3 ? 0 : activeTurn + 1;
        return heartScore[nextPlayer] == 0 ? getNextPlayersTurn(nextPlayer) : nextPlayer;
    }

    private void EndTurn(){
        EventSystem.FireEvent(EventType.TurnOver);

        if (heartScore[0] == 0 && heartScore[1] == 0){
            EndGame(2);
        } else if (heartScore[2] == 0 && heartScore[3] == 0){
            EndGame(1);
        } else {
            ChangeTurn();
        }
    }

    private void ChangeTurn(){
        activeTurn = getNextPlayersTurn(activeTurn);
        EventSystem.FireEvent(EventType.TurnStart);
    }
}
