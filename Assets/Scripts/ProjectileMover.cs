using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
    public float speed;
    Rigidbody rg;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        rg.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < -10 || transform.position.z > 20)
        {
            Destroy(this.gameObject);
        }
    }
}
