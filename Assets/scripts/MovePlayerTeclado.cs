using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerTeclado : MonoBehaviour
{
    public float velocidade = 5f; // Velocidade de movimento do objeto

    
    void Update()
    {

        float movimentoHorizontal = Input.GetAxis("Horizontal"); 
        Vector3 movimento = new Vector3(movimentoHorizontal, 0f, 0f) * velocidade * Time.deltaTime; 

        transform.Translate(movimento); 
    }

}
