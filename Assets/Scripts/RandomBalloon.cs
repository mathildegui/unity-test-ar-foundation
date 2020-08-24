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
            var b = Instantiate(balloons[randomInt], cube.transform.position, pos.rotation);
            applyForce(b);
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
            // var vect = new Vector3(0, 1, Random.Range(0, 100));
            // Debug.Log(vect.ToString());
            // item.AddForce(vect * floatStrength * Time.deltaTime);
        }
    }

    private void applyForce (GameObject balloon) {
        var vect = new Vector3(Random.Range(-5, 5), 1, Random.Range(-5, 5));
        var strengh = Random.Range(2, 5);
        balloon.GetComponent<Rigidbody>().AddForce(vect * strengh);
    }

    private void updateCounter() {
        cube.GetComponent<TextMesh>().text = countExplode.ToString() + " / " + count;
    }
}
