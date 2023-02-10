using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
<<<<<<< HEAD
    private static GameManager _instance;
    public static GameManager Instance { 
        get {
            if(_instance == null) {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return _instance;
        }
    }
=======
    public static GameManager Instance { get; private set; }
>>>>>>> c3ec6877400c1a453b28f52bb8943dc90f78ad55

    public int activeTurn = 0;
    public int[] heartScore = new int[] {3, 3, 3, 3};
    public int[] teamOneBases = new int[5];
    public int[] teamTwoBases = new int[5];

    private void Awake() {
<<<<<<< HEAD
        DontDestroyOnLoad(gameObject);
=======
        if (Instance != null && Instance != this) {
            Destroy(this); 
        } else {
            Instance = this; 
        }
>>>>>>> c3ec6877400c1a453b28f52bb8943dc90f78ad55
    }

    private int getCurrentTeam(){
        return activeTurn < 2 ? 1 : 2;
    }

<<<<<<< HEAD
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
=======
    void handleBaseHit(int baseId){
        int currentTeam = getCurrentTeam();
        
        changeTurn();
    }

    void handleCastleHit(int CastleId){
        Debug.Log("Castle hit");
        changeTurn();
    }

    void handleMiss(){
>>>>>>> c3ec6877400c1a453b28f52bb8943dc90f78ad55
        Debug.Log("Miss");
        changeTurn();
    }

<<<<<<< HEAD
    public void endGame(){
=======
    void endGame(){
>>>>>>> c3ec6877400c1a453b28f52bb8943dc90f78ad55
        Debug.Log("Game ended");
    }

    private void changeTurn(){
        activeTurn = activeTurn >= 3 ? 0 : activeTurn + 1;
        Debug.Log("Change turn");
    }
}
<<<<<<< HEAD

=======
>>>>>>> c3ec6877400c1a453b28f52bb8943dc90f78ad55
