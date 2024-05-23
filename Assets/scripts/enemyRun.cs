using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, -0.1f) ;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
