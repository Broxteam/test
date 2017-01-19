using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoundaryArea
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerControler : MonoBehaviour {

    public float moveSpeed;
    public float moveTilt;
    public BoundaryArea boundaryArea;

    public GameObject bullet;
    public float fireRate;

    private Rigidbody playerRigidbody;
    private float nextFire;

    // Use this for initialization
    void Start () {
        playerRigidbody = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && Time.time > nextFire) {
            //bullet start pos
            Vector3 bulletStart = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1);
            //next fire
            nextFire = Time.time + fireRate;

            //clone prefab bullet
            Instantiate(bullet, bulletStart, this.transform.rotation);
            
        }
    }

    // call each fixed physics step
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        Vector3 moves = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        playerRigidbody.velocity = moves * moveSpeed;
        
        playerRigidbody.position = new Vector3(
                Mathf.Clamp(playerRigidbody.position.x, boundaryArea.xMin, boundaryArea.xMax),
                0.0f,
                Mathf.Clamp(playerRigidbody.position.z, boundaryArea.zMin, boundaryArea.zMax)
            );

        playerRigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, playerRigidbody.velocity.x * moveTilt);
    }
}
