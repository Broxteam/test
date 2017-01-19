using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControler : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * moveSpeed;
    }

    void Update() {
        if (rb.position.z > 18) {
            Destroy(this.gameObject);
        }
    }

}
