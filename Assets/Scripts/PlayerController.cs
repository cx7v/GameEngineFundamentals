using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 300.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + (transform.forward * 0.1f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + (transform.forward * -0.1f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + (transform.right * 0.1f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + (transform.right * -0.1f);
        }

        if (Input.GetKeyDown("space"))
        {
            // turn on the cursor
            GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, jumpForce, 0.0f));
        }
    }
}
