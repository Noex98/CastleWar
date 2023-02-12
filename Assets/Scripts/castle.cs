using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){
        /*
        if (collision.GameObject.name == "paperclip"){
            Debug.Log("enter");
        }
        */

    }
    private void OnCollisionStay2D(Collision2D collision){
        /*
        if (collision.gameObject.name == "paperclip"){
            Debug.Log("stay");
        }
        */
    }
    private void OnCollisionExit2D(Collision2D collision){
        /*

        if(collision.gameObject.name == "paperclip"){
            Debug.Log("exit");
        }
        */
    }

}
