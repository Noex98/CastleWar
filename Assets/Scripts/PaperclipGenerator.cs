using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PaperclipGenerator : MonoBehaviour {
    private GameManager gameManager;
    public GameObject paperclip;
    public GameObject[] castles = {};
    public GameObject[] bases = {};

    private void Start() {
        gameManager = GameManager.Instance;
    }
    void createPaperClip(){

        Vector3 position = castles[gameManager.activeTurn].transform.position;

        int currentTeam = gameManager.getCurrentTeam();

        if(currentTeam == 1 && gameManager.baseState.Contains(currentTeam)){
            for(int i = 0; i < gameManager.baseState.Length; i++){
                int reverseI = gameManager.baseState.Length - (i + 1);
                if(gameManager.baseState[reverseI] == currentTeam){
                    position = bases[reverseI].transform.position;
                    break;
                }
            }
        } else if (currentTeam == 2 && gameManager.baseState.Contains(currentTeam)){
            for(int i = 0; i < gameManager.baseState.Length; i++){
                if(gameManager.baseState[i] == currentTeam){
                    position = bases[i].transform.position;
                    break;
                }
            }
        }

        Instantiate(paperclip, position, Quaternion.identity);
    }

    void OnEnable() {
		EventSystem.RegisterForEvent(createPaperClip, EventType.TurnStart);
	}

	void OnDisable() {
		EventSystem.UnRegisterFromEvent(createPaperClip, EventType.TurnStart);
	}
}
