using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

public class ArPlaceObject : MonoBehaviour
{
    // Start is called before the first frame updateprivate GameObject visual;
    private ARRaycastManager manager;
    // Start is called before the first frame update
    void Start() {
        manager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update() {
        //shoot a raycast at the center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        manager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if(hits.Count > 0) {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }
}
