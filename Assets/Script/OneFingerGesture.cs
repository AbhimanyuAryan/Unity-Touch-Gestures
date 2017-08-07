using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneFingerGesture : MonoBehaviour {

    GameObject Object_to_move;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.touchCount == 1) {
            if(Input.GetTouch(0).tapCount == 1) {
                Debug.Log("Single Tap with one finger");

                RaycastHit hit;
                Ray ray;

                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                if(Physics.Raycast(ray, out hit)){
                    // Select an object
                    Debug.Log(hit.transform.name);
                    if (Object_to_move != null && hit.transform.name != Object_to_move.transform.name) {
                        Object_to_move.GetComponent<ParticleSystem>().Stop();
                        //stop the particle system
                    }


                    Object_to_move = GameObject.Find(hit.transform.name);
                    Object_to_move.GetComponent<ParticleSystem>().Play();
                }
            } 
            else if(Input.GetTouch(0).tapCount == 2) {
                if(Object_to_move != null) {
                    Vector3 pos;
                    pos.x = Input.GetTouch(0).position.x;
                    pos.y = Input.GetTouch(0).position.y;

                    pos.z = Mathf.Abs(Camera.main.transform.position.z - Object_to_move.transform.position.z);
                    Object_to_move.transform.position = Camera.main.ScreenToWorldPoint(pos);
                }
            }
        }	
	}
}
