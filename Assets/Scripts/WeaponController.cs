using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject shot;
    float fireRate = 1.5f;
    float startWait = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", startWait, fireRate);
    }

    void Fire()
    {
        Instantiate(shot, transform.position + new Vector3(0.0f, 0.0f, -0.5f), Quaternion.identity);
        GetComponent<AudioSource>().Play();
    }
}
