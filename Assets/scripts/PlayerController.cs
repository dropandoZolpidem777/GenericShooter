using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Connection;
using TMPro;
using FishNet.Managing;



public class PlayerController : NetworkBehaviour
{

    private NetworkManager networkManager;
    public Transform bulletPrefab;
    public Transform bulletPoint;

    public int vida = 3;
    bool morto = false;

    public float velocidademovimento = 5f;
    public float velocidaderotacao = 5f;
    public float forcaPulo = 5f;
    public float tempopulo = 1.5f;


    public float rotacaoX = 0;
    public float limitevisaoY = 45f;
    public float gravidade = 9.8f;

    public float frequenciaTiro = 0.5f;

    Vector3 direcaomovimento = Vector3.zero;
    bool podeAtirar = true;

    CharacterController cc;



    /* private void Start()
     {

         cc = GetComponent<CharacterController>();

         // Cursor.LockState = CursorLockMode.Locked;
         // Cursor.visible =false;


     }
    */

    public override void OnStartClient()
    {
        base.OnStartClient();

        if (base.IsOwner == false)
        {
            return;
        }

        cc = GetComponent<CharacterController>();
        transform.Find("Main Camera").gameObject.SetActive(true);

    }

    private void Update()
    {

        if (base.IsOwner == false)
        {
            return;
        }


        float direcaoX = Input.GetAxis("Horizontal");
        float direcaoZ = Input.GetAxis("Vertical");
        float direcaoY = direcaomovimento.y;


        if (Input.GetKey(KeyCode.Mouse0) && podeAtirar == true) // Botao esquerdo do mouse
        {
            podeAtirar = false;
            Server_Atirar(base.Owner, transform.Find("Main Camera").transform.forward);

        }


        // Orientação do jogador em Primeira pessoa
        Vector3 frente = transform.TransformDirection(Vector3.forward);
        Vector3 direita = transform.TransformDirection(Vector3.right);


        // Movimentação do jogador em primeira pessoa
        direcaomovimento = (frente * direcaoZ) + (direita * direcaoX);
        direcaomovimento *= velocidademovimento;
        // Pular

        if (Input.GetKeyDown(KeyCode.Space))
        {
            direcaomovimento.y = forcaPulo;
        }
        else
        {
            direcaomovimento.y = direcaoY;

        }

        // Aplica a gravidade
        direcaomovimento.y -= gravidade * Time.deltaTime;
        // Move o Jogador
        cc.Move(direcaomovimento * Time.deltaTime);


        // Rotacao Jogador
        rotacaoX -= Input.GetAxis("Mouse Y") * velocidademovimento;
        rotacaoX -= Math.Clamp(rotacaoX, -limitevisaoY, limitevisaoY);

        // Rotaciona a camaera para o ponto do mouse

        //Camera.main.transform.localRotation = Quaternion.Euler(rotacaoX, 0, 0);
        //transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * velocidaderotacao, 0);


        // chamada no update ao clicar com botao esquerdo
        [ServerRpc]
        void Server_Atirar(NetworkConnection conn, Vector3 direcao)
        {
            podeAtirar = false;
            Transform instancia = Instantiate(bulletPrefab, bulletPoint.position, Quaternion.Euler(Camera.main.transform.forward));
            instancia.GetComponent<Bullet>().direcao = direcao;

            base.Spawn(instancia.gameObject);

            StartCoroutine(resetarTiro());
            IEnumerator resetarTiro()
            {
                yield return new WaitForSeconds(frequenciaTiro);
                TargetResetarTiro(conn);
            }


        }
    }

    [TargetRpc]
    void TargetResetarTiro(NetworkConnection conn)
    {
        podeAtirar = true;
    }


    [TargetRpc]
    public void receberDano(NetworkConnection conn)
    {
        vida--;
        GameObject.Find("Canvas").transform.Find("Vida").GetComponent<TextMeshProUGUI>().text = "Vida:" + vida.ToString();
        if (vida <= 0)
        {
            Morrer();
            morto = true;
        }
    }

    /*  void VerificarMorte()
      {
          if(vida <= 0)
          {
              networkManager.ClientManager.StopConnection(); 
              Destroy(gameObject);
          }
      }*/

    void Morrer()
    {
        Debug.Log("O Jogador Morreu");

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


    //
    [ServerRpc]
    void Respawn()
    {

        if (morto == true)
        {
            if (base.IsOwner)
            {
                enabled = true;
            }
            if (vida <= 0)
            {
                base.Spawn(gameObject);
            }
        }
    }

}


