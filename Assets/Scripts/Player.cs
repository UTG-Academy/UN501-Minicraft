using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 6f;
    float lookSpeed = 3f;

    float lookHorizontal = 0f;
    float lookVertical = 0f;

    // Start is called before the first frame update
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.position -= transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space)) {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift)) {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }


        lookHorizontal += Input.GetAxis("Mouse X") * lookSpeed;
        lookVertical += Input.GetAxis("Mouse Y") * lookSpeed;
        transform.eulerAngles = new Vector3(-lookVertical, lookHorizontal, 0f);
    }
}
