using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public GameObject Bonus;
    public int forca = 5;
    void Start()
    {
        StartCoroutine(disparo());
    }




    IEnumerator disparo()
    {
        yield return new WaitForSeconds(4f);
        GameObject novobonus = Instantiate(Bonus, transform.position, Quaternion.identity);
        novobonus.GetComponent<Rigidbody>().AddForce(Vector3.forward * forca);
        StartCoroutine(disparo());
    }
}
