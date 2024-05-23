using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGerator : MonoBehaviour
{
    public GameObject inimigo;
    public int forca = 5;

    void Start()
    {
        StartCoroutine(gerar());
    }


    void Update()
    {

    }

    IEnumerator gerar()
    {
        yield return new WaitForSeconds(2f);
        GameObject novoInimigo = Instantiate(inimigo, transform.position, transform.rotation);
        StartCoroutine(gerar());
    }
}
