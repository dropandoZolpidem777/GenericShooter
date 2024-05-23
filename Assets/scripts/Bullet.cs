using System.Collections.Generic;

using System.Collections;

using FishNet.Object;

using UnityEngine;

public class Bullet : NetworkBehaviour

{

    public float velocidade = 5f;

    public float tempoVida = 2f;

    public Vector3 direcao;

    public override void OnStartServer()

    {

        base.OnStartServer();

        Invoke("DestruirBala", tempoVida);

        GetComponent<Rigidbody>().velocity = velocidade * direcao;

    }

    [ServerRpc]

    private void DestruirBala()

    {

        base.Despawn(gameObject);

    }

    private void OnTriggerEnter(Collider collision)

    {

    /*    if (collision.CompareTag("inimigo"))

        {

            collision.GetComponent<PlayerController>().receberDano(collision.GetComponent<PlayerController>().Owner);

        }*/

        DestruirBala();

    }

}