using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject tiro;
    public float forca = 5;
    void Start()
    {
        StartCoroutine(disparo());
    }




    IEnumerator disparo()
    {
        yield return new WaitForSeconds(0.25f);
        GameObject novoTiro = Instantiate(tiro, transform.position, Quaternion.identity);
        novoTiro.GetComponent<Rigidbody>().AddForce(Vector3.forward * forca );
        StartCoroutine(disparo());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "inimigo")
        {
            Destroy(tiro);
        }
    }

}
