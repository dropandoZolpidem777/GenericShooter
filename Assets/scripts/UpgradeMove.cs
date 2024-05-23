using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class UpgradeMove : MonoBehaviour
{
 

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, -0.1f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            Destroy(gameObject);
            
            GameObject.Find("Player").GetComponent<PlayerShoot>().forca = GameObject.Find("Player").GetComponent<PlayerShoot>().forca * 1.2f;
        }

    }


}

