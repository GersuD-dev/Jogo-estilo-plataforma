using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Colisao : MonoBehaviour
{
    private int num;
    public Text TextColeta;

    public Image alma;
    public string item;

    public static bool pequeno;

    Transform rt;

    public int contador;

    public GameObject canva;
    public GameObject fim;

    public static bool activeMoviment;
    private float posicaoX;
    private float posicaoY;

    public float tempoAtivacao;

    void Start()
    {
        alma.fillAmount = 0.02f;
        activeMoviment = true;
        num = 0;
        pequeno = false;
        posicaoX = -2.617f;
        posicaoY = -7.350f;
        contador = 1;
        rt = GetComponent<Transform> ();
    }

    void Update()
    {
        tempoAtivacao += Time.deltaTime;

        TextColeta.text = num.ToString() + "/2";
        
        if (num >= 2)
        {
            canva.SetActive(false);
            fim.SetActive(true);
            activeMoviment = false;
            transform.Translate(0, 0, 0);
        }
    }

      private void OnCollisionEnter2D(Collision2D collision2D)
    {

        if (collision2D.gameObject.CompareTag(item))
        {
            num = num + 1;
            alma.fillAmount += 0.4f;
            Destroy(collision2D.gameObject);
        }

        if (collision2D.gameObject.CompareTag("passagem"))
        {
            if(pequeno)
            {
            Destroy(collision2D.gameObject);
            }
        }

        if (collision2D.gameObject.CompareTag("pequeno"))
        {
            Destroy(collision2D.gameObject);
            pequeno = !pequeno;

            if (pequeno)
             {
                transform.localPosition = new Vector3(-4.525f,-7.467f,0.114f);
                contador = contador + 1;
                rt.localScale = new Vector3 (0.4f,0.4f,0.4f);
             }else
             {
                 if(contador %2 == 0)
                 {
                    transform.localPosition = new Vector3(posicaoX, posicaoY, 0);
                    contador ++;
                 }
                rt.localScale = new Vector3 (1f,1f,1f);
             }
        }

        if (collision2D.gameObject.CompareTag("blockover"))
        {
            GetComponent<Movimentacao>().RecebeDano(3);
        }
    }
}
