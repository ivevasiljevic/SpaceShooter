using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void LateUpdate()
    {
        if(!ps.IsAlive())
        {
            Destroy(this.gameObject);
        }
    }
}
