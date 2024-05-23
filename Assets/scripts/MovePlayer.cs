using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    float velocidade = 5f;
   
 
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.touchCount > 0)
        {
            float pos_X = Input.GetTouch(0).position.x;
           

            horizontal = (Screen.width / 2 < pos_X) ? 1 : -1;
            
            
        }



        Vector3 movimento = new Vector3(horizontal, 0, vertical);
        movimento = movimento * velocidade * Time.deltaTime;

        transform.Translate(movimento);
    }
}
