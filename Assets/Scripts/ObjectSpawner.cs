using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private ArPlaceObject placementIndicator;
    private ARPlaneManager planeManager;

    void Start() {
        placementIndicator = FindObjectOfType<ArPlaceObject>();
        planeManager = FindObjectOfType<ARPlaneManager>();
    }

    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Cube").Length == 0) {
            if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
                GameObject ojb = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
                var indicator = GameObject.FindGameObjectWithTag("PlacementIndicator");
                indicator.SetActive(false);
                foreach (var plane in planeManager.trackables) {
                    plane.gameObject.SetActive(false);
                }
            }
        }
    }
}
