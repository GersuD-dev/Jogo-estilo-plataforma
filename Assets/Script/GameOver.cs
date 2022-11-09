using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public static GameOver instance;

    public void Start()
    {
        instance = this;
    }   
    public void fimdejogo()
    {
        SceneManager.LoadScene("gameover");
    }

    public void iniciojogo()
    {
        SceneManager.LoadScene("tutorial");
    }
}
