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

    void OnEnable() {
		EventSystem.RegisterForEvent(UpdateHeartDisplay, EventType.CastleHit);
	}

	void OnDisable() {
		EventSystem.UnRegisterFromEvent(UpdateHeartDisplay, EventType.CastleHit);
	}

    private void UpdateHeartDisplay() {
        for (int i = 0; i < heartDisplays.Length; i++){
            heartDisplays[i].text = gameManager.heartScore[i].ToString();
        }
    }
}