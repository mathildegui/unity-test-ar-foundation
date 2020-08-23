using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private ArTApToPlaceObject placementIndicator;

    void Start() {
        placementIndicator = FindObjectOfType<ArTApToPlaceObject>();
    }

    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Cube").Length == 0) {
            if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
                GameObject ojb = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
                var indicator = GameObject.FindGameObjectWithTag("PlacementIndicator");
                indicator.SetActive(false);
            }
        }
    }
}
