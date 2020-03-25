using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{

    //private Vector2 oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //oldPosition = transform.position;
        //Debug.Log(GetComponent<Rigidbody2D>().velocity.magnitude);

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }

}
