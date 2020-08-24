using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBalloon : MonoBehaviour
{
    [SerializeField] GameObject[] balloons;
    [SerializeField] Transform pos;
    [SerializeField] float floatStrength = 3.5f;
    int randomInt;
    private GameObject cube;
    private int count = 0;
    private int countExplode = 0;
    private GameObject countObject;

    void Start() {
        InvokeRepeating("randomBalloons", 0.0f, 2.5f);
    }

    void randomBalloons() {
        randomInt = Random.Range(0, balloons.Length);
        cube = GameObject.FindGameObjectWithTag("Cube");
        if(cube) {
            count++;
            var placedCube = Instantiate(balloons[randomInt], cube.transform.position, pos.rotation);
            
            updateCounter();
        }
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                GameObject obj = hit.collider.gameObject;
                countExplode++;
                updateCounter();
                obj.SetActive(false);
            }
        }
    }

    void FixedUpdate() {
        foreach (var item in FindObjectsOfType<Rigidbody>()) {
            item.AddForce(Vector3.up * floatStrength * Time.deltaTime);
        }
    }

    private void updateCounter() {
        cube.GetComponent<TextMesh>().text = countExplode.ToString() + " / " + count;
    }
}
