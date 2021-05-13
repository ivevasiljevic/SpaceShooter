using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundaries
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public Boundaries boundaries;
    public float shotRate;
    public float playerTilt;
    public float playerSpeed;
    public GameObject projectile;

    Rigidbody rg;
    float nextShot;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && (Time.time > nextShot))
        {
            nextShot = Time.time + shotRate;
            Instantiate(projectile, transform.position + new Vector3(0.0f, 0.0f, 1.25f), Quaternion.identity);
            GetComponent<AudioSource>().Play();
        } 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        rg.velocity = new Vector3(x, 0.0f, z) * playerSpeed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, boundaries.xMin, boundaries.xMax), 5f, Mathf.Clamp(transform.position.z, boundaries.zMin, boundaries.zMax));

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rg.velocity.x * (-playerTilt));
    }
}
