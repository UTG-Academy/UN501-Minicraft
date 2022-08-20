using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    public GameObject grassIndicator;
    public GameObject waterIndicator;

    public GameObject grassBlock;
    public GameObject waterBlock;

    public GameObject holdingBlock;

    public GameObject world;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            BreakBlock();
        }
        if (Input.GetMouseButtonDown(1)) {
            PlaceBlock();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            holdingBlock = grassBlock;
            grassIndicator.SetActive(true);
            waterIndicator.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            holdingBlock = waterBlock;
            grassIndicator.SetActive(false);
            waterIndicator.SetActive(true);
        }
    }

    void BreakBlock() {
        Ray ray = new Ray();
        ray.origin = Camera.main.transform.position;
        ray.direction = Camera.main.transform.forward;
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 3f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.gameObject.tag != "Unbreakable") {
                Destroy(hit.transform.gameObject);
            }
        }
    }

    void PlaceBlock() {
        Ray ray = new Ray();
        ray.origin = Camera.main.transform.position;
        ray.direction = Camera.main.transform.forward;
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 3f);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            GameObject block = Instantiate(holdingBlock);
            block.transform.position = hit.transform.position + hit.normal;
            block.transform.parent = world.transform;
        }
    }
}
