using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;
using UnityEngine.XR.ARSubsystems;

public class ArTApToPlaceObject : MonoBehaviour {
    private String TAG = "Unity::ArTApToPlaceObject";
    private GameObject visual;
    private ARRaycastManager manager;
    // Start is called before the first frame update
    void Start() {
        manager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;
        visual.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //shoot a raycast at the center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        manager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if(hits.Count > 0) {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }

        if(!visual.activeInHierarchy) {
            visual.SetActive(true);
        }
    }
}
