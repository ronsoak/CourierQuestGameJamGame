using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour
{
    // Variables
    private Rigidbody2D rCloud;

    // Start is called before the first frame update
    void Start()
    {
        rCloud = GetComponent<Rigidbody2D>();
        rCloud.velocity = new Vector3(-10, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        rCloud.constraints = RigidbodyConstraints2D.FreezeRotation;
        rCloud.constraints = RigidbodyConstraints2D.FreezePositionY;
    }
}
