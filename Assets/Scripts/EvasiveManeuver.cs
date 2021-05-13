using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour
{
    float dodge = 5.0f;
    float smoothing = 7.5f;
    float tilt = 10.0f;
    Vector2 startWait = new Vector2(0.5f, 1.0f);
    Vector2 maneuverTime = new Vector2(1.0f, 2.0f);
    Vector2 maneuverWait = new Vector2(1.0f, 2.0f);
    public Boundaries boundary;

    float targetVelocity;
    Rigidbody rg;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        StartCoroutine(Evade());
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while(true)
        {
            targetVelocity = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetVelocity = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    void FixedUpdate()
    {
        float newVelocity = Mathf.MoveTowards(rg.velocity.x, targetVelocity, smoothing * Time.deltaTime);
        rg.velocity = new Vector3(newVelocity, 0.0f, rg.velocity.z);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp(transform.position.x, boundary.zMin, boundary.zMax));
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rg.velocity.x * -tilt);
    }
}
