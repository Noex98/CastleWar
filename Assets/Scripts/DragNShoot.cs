using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour {
    public float power = 10f;
    public Rigidbody2D rb;
    public Vector2 minPower;
    public Vector2 maxPower;

    TrajectoryLine tl;

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;
    bool hasBeenShot = false;

    private void Start(){
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
            Debug.Log(force);
            rb.AddForce(force * power, ForceMode2D.Impulse);
            tl.EndLine();
            hasBeenShot = true;
        }
    }

    private void HandleStop(){
        Destroy(gameObject, 0);
    }

    private void Update(){
        if (!hasBeenShot){
            HandleMouseInput();
        } else {
            bool hasStoppedMoving = rb.velocity.magnitude == 0;
            if (hasStoppedMoving){
                HandleStop();
            }
        }
    }

    private void OnCollisionEnter(Collision collision){
        Debug.Log("collision");
    }
}
