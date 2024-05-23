using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Connection;

public class EnemySpawn : NetworkBehaviour
{
    public float Andar = -0.10f; 

   

    public GameObject prefabInimigo;

    Vector3 PontoSpawn;


    public override void OnStartServer()
    {
           

        base.OnStartServer();

        InvokeRepeating("Server_SpawnarInimigo", 3, 2);

    }


    [Server]
    void Server_SpawnarInimigo(NetworkConnection conn)
    {
        GameObject inimigo = Instantiate(prefabInimigo, transform.position, transform.rotation);
        base.Spawn(inimigo);
        //GameObject.Find("inimigo(Clone)").GetComponent<EnemyController>().InimigoAnda();
        InimigoAnda(conn);


    }




     [TargetRpc]
      void InimigoAnda(NetworkConnection conn)
     {

             Debug.Log("O Inimigo Andou");
             Vector3 frente = transform.TransformDirection(Vector3.forward);
             prefabInimigo.transform.position = frente;
             // Transform instancia = Instantiate(inimigoPrefab, EnemyPoint.position, Quaternion.Euler(SpawnPrefab.transform.forward));


     }


}

