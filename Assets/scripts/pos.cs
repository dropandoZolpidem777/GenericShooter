using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pos : MonoBehaviour
{
    List<float> posicao = new List<float>();
    public float po1 = 1;
    public float po2 = 2;
    public float po3 = 3;
    public float po4 = 0;
    public float po5 = -1;
    public float po6 = -2;
    public float po7 = -3;
    

    public float rand;

    public bool trocar;

    public GameObject inimigo;
    // Start is called before the first frame update
    void Start()
    {
        posicao.Add((int)po1);
        posicao.Add((int)po2);
        posicao.Add((int)po3);
        posicao.Add((int)po4);
        posicao.Add((int)po5);
        posicao.Add((int)po6);
        posicao.Add((int)po7);
        
        StartCoroutine(Teste());
    }

    // Update is called once per frame
    void Update()
    {


    }
    IEnumerator Teste()
    {

        if (trocar)
        {
            transform.position = new Vector3(posicao[(Random.Range(1, 7))], transform.position.y, transform.position.z);
            trocar = false;
        }
        if (trocar == false)
        {
            yield return new WaitForSeconds(3);
            Instantiate(inimigo, transform.position, transform.rotation);
            trocar = true;
        }
        yield return new WaitForSeconds(3);
        StartCoroutine(Teste());

    }
}
