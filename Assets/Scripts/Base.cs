using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {
    private GameManager gameManager;
    public int id;
    public SpriteRenderer spriteRenderer;
    public Color teamOneColor;
    public Color teamTwoColor;

    private void Start(){
        gameManager = GameManager.Instance;
    }

    private void UpdateColor(){
        if(gameManager.baseState[id] != 0){
            spriteRenderer.color = gameManager.baseState[id] == 1 ? teamOneColor : teamTwoColor;
        }
    }

    void OnEnable() {
		EventSystem.RegisterForEvent(UpdateColor, EventType.BaseHit);
	}

	void OnDisable() {
		EventSystem.UnRegisterFromEvent(UpdateColor, EventType.BaseHit);
	}
}
