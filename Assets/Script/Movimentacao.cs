using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movimentacao : MonoBehaviour
{

    // variáveis globais

    private Rigidbody2D myRigidbody;

    public TextMeshProUGUI vida;

    public int QntVida;
    public static bool estado;

    [Header("Movimento")]
    public bool olhandoDireita; 
    public static float andar; 

    public Animator animacao;


    [Header("Pulo")]
    private bool podePular = false;

    public  static float forcaPulo = 400f; 

    public Transform posPe; 
    public LayerMask layerChao; 

    void Start()
    {
        animacao = GetComponent<Animator>();
        vida.text = QntVida.ToString();
        forcaPulo = 100;
        myRigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        vida.text = QntVida.ToString();

        if(Colisao.activeMoviment)
        {
            movimentacao();
        }

        
        if (NoChao() && Input.GetButtonDown("Jump"))
        {
            podePular = true;
        }

        direcao();

    }

    private void FixedUpdate()
    {
        if (podePular) Pular();
    }


    public void RecebeDano(int dano)
    {
        QntVida = Mathf.Clamp(QntVida - dano,0,3);
        if (QntVida <= 0)
        {
            GameOver.instance.fimdejogo();
        }
    }

    private void Pular()
    {
        podePular = false;
        myRigidbody.AddForce(Vector2.up * forcaPulo); 

    }
    
    private bool NoChao()
    {
         return Physics2D.OverlapCircle(posPe.position, 0.02f, layerChao); 
    }

    void movimentacao()
    {
        andar = Input.GetAxisRaw("Horizontal");

        myRigidbody.velocity = new Vector2(andar, myRigidbody.velocity.y);



        if (andar < 0)
        {
            olhandoDireita = true;
            animacao.SetBool("andando", true);

        }
        else if (andar > 0)
        {
            olhandoDireita = false;
            animacao.SetBool("andando", true);

        }else 
        {
            animacao.SetBool("andando", false);
        }

    }

    void direcao()
    {

        if (olhandoDireita)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("parede") || collision2D.gameObject.CompareTag("obstaculo") || collision2D.gameObject.CompareTag("passagem"))
        {   
            estado = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("parede") || collision2D.gameObject.CompareTag("obstaculo") || collision2D.gameObject.CompareTag("passagem"))
        {
            estado = true;
        }
    }
}
    

