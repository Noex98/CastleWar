using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperclipGenerator : MonoBehaviour {
    private GameManager gameManager;
    public GameObject paperclip;
    public GameObject[] castles = {};

    private void Start() {
        gameManager = GameManager.Instance;
    }
    void createPaperClip(){
        Vector3 position = castles[gameManager.activeTurn].transform.position;
        Instantiate(paperclip, position, Quaternion.identity);
    }

    void OnEnable() {
		EventSystem.RegisterForEvent(createPaperClip, EventType.TurnStart);
	}

	void OnDisable() {
		EventSystem.UnRegisterFromEvent(createPaperClip, EventType.TurnStart);
	}
}
