using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBalloon : MonoBehaviour
{
    [SerializeField] GameObject[] balloons;
    [SerializeField] Transform pos;
    [SerializeField] float floatStrength = 3.5f;
    int randomInt;

    void Start() {
        InvokeRepeating("randomBalloons", 0.0f, 2.5f);
    }

    void randomBalloons() {
            randomInt = Random.Range(0, balloons.Length);
            var cube = GameObject.FindGameObjectWithTag("Cube");
            if(cube) {
                var obj = Instantiate(balloons[randomInt], cube.transform.position, pos.rotation);
                obj.GetComponent<Rigidbody>().AddForce(Vector3.up * floatStrength);
           }
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
                GameObject obj = hit.collider.gameObject;
                // if(obj.tag == "Cube") {
                    obj.SetActive(false);
                // }
                // obj.GetComponent<RPS_Interaction>().action.Invoke();
            }
        }    
    }
}
