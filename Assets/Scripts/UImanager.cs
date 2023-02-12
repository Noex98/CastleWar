using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UImanager : MonoBehaviour{
    private GameManager gameManager;
    public TMPro.TextMeshProUGUI[] heartDisplays = {};

    private void Awake() {
        gameManager = GameManager.Instance;
    }

    private void Start(){
        UpdateHeartDisplay();
    }

    public void RemoveHeart(int playerId){
        UpdateHeartDisplay();
    }

    public void AnnounceWin(){
        if(gameManager.winner == 1){
            heartDisplays[0].text = "Winner";
            heartDisplays[1].text = "Winner";
        } else if (gameManager.winner == 2){
            heartDisplays[2].text = "Winner";
            heartDisplays[3].text = "Winner";
        }
    }

    void OnEnable() {
		EventSystem.RegisterForEvent(UpdateHeartDisplay, EventType.CastleHit);
        EventSystem.RegisterForEvent(AnnounceWin, EventType.GameOver);
	}

	void OnDisable() {
		EventSystem.UnRegisterFromEvent(UpdateHeartDisplay, EventType.CastleHit);
        EventSystem.RegisterForEvent(AnnounceWin, EventType.GameOver);
	}

    private void UpdateHeartDisplay() {
        for (int i = 0; i < heartDisplays.Length; i++){
            heartDisplays[i].text = gameManager.heartScore[i].ToString();
        }
    }
}