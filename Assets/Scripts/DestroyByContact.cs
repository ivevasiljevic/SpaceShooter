using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;

    GameObject gm;

    private void Start()
    {
        gm = GameObject.FindWithTag("GameController");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            return;
        }
        if(other.gameObject.tag == "Player")
        {
            Instantiate(playerExplosion, other.gameObject.transform.position, Quaternion.identity);
            gm.GetComponent<GameManager>().GameOver();
        }
        gm.GetComponent<GameManager>().ChangeScore(scoreValue);
        if(explosion != null)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
