using FishNet.Connection;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Video;
using FishNet.Object;


public class EnemyController : NetworkBehaviour
{
    bool morto = false;
    int vida = 1;
    

    public float velocidade = 7.5f;
    Rigidbody rb;

   public Transform inimigoPrefab;
    public Transform EnemyPoint;
    public Transform SpawnPrefab;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {

        //if ()
       // {
            
        //}
    }

    
    
    public void receberDano()
    {
        vida--;

        if (vida <= 0)
        {
            Morrer();
            morto = true;
        }
    }

    void Morrer()
    {
        

        if (base.IsOwner)
        {
            enabled = false;
        }

        if (vida <= 0)
        {
            base.Despawn(gameObject);
            //morto = true;
        }
    }
     void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            //collision.gameObject.GetComponent<EnemyController>(). //(collision.gameObject.GetComponent<EnemyController>().Owner);
            receberDano();
            base.Despawn(gameObject);
        }
    }

    /*
    [TargetRpc]
    public void InimigoAnda()
    {
        Debug.Log("O Inimigo Andou");
        Transform instancia = Instantiate(inimigoPrefab, EnemyPoint.position, Quaternion.Euler(SpawnPrefab.transform.forward));
    }
    */
}
