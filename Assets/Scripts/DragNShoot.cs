using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour {
    private GameManager gameManager;
    public float power = 10f;
    public Rigidbody2D rb;
    public Vector2 minPower;
    public Vector2 maxPower;
    TrajectoryLine tl;
    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;
    private bool hasBeenShot = false;

    private void Start(){
        gameManager = GameManager.Instance;
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();
    }

    private void HandleMouseInput(){
        if(Input.GetMouseButtonDown(0)){
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 0;
        }

        if (Input.GetMouseButton(0)){
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 0;
            tl.RenderLine(startPoint, currentPoint);
        }

        if (Input.GetMouseButtonUp(0)){
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 0;

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
            tl.EndLine();
            hasBeenShot = true;
        }
    }

    private IEnumerator DeclareMiss() {
        if(gameObject){
            yield return new WaitForSeconds(0.5f);
            gameManager.HandleMiss();
            Destroy(gameObject,0);
        }
    }

    private void HandleStop(){
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        collider.enabled = true;
        StartCoroutine(DeclareMiss());
    }

    private void Update(){
        if (!hasBeenShot){
            HandleMouseInput();
            return;
        }

        bool hasStoppedMoving = rb.velocity.magnitude == 0;
        if (hasStoppedMoving){
            HandleStop();
        }
    }

    private void OnTriggerEnter2D(Collider2D targetHit){
        if(targetHit.tag.Contains("Castle")){
            gameManager.HandleCastleHit(targetHit.GetComponent<castle>().id);
        } else if(targetHit.tag.Contains("Base")){
            Debug.Log("Drag and shoot");
            gameManager.HandleBaseHit(targetHit.GetComponent<Base>().id);
        }
        Destroy(gameObject, 0);
    }
}
