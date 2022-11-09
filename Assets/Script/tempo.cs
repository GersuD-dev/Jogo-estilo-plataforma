using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class tempo : MonoBehaviour
{

    private string timerFormatted;



    bool isRunning = true;

    private float tempoo;
    void Start()
    {
        tempoo = 90;
    }


    void Update()
    {



        if (isRunning)
        {
            tempoo -= Time.deltaTime;
       
            System.TimeSpan t = System.TimeSpan.FromSeconds(tempoo);
            timerFormatted = string.Format("{0:D1}:{1:D2}", t.Minutes, t.Seconds);


            GetComponent<TextMeshProUGUI>().text = timerFormatted;
        }


        if (tempoo <= 0)
        {
            GameOver.instance.fimdejogo();
        }

    }

}