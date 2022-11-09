using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moviFundo : MonoBehaviour
{

public float velocidade = 0.0009f;

    public void Update() 
    {
    
        if(Movimentacao.estado)
        {
            if (Movimentacao.andar < 0)
            {
                transform.Translate(-velocidade,0,0);

            }else if(Movimentacao.andar  > 0)
            {
                transform.Translate (velocidade, 0,0);
            
            }else
            {

                transform.Translate(0, 0, 0);
            
            }   
        }

    }
}

