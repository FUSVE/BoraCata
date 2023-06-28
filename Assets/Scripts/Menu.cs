using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject metal;
    public GameObject plastico;
    public GameObject vidro;
    public GameObject papel;
    public GameObject comum;
    public GameObject bateria;
    public GameObject inicial;

    void Start()
    {
        Inicial();
    }

    public void DesativaTodos()
    {
        metal.SetActive(false);
        plastico.SetActive(false);
        vidro.SetActive(false);
        papel.SetActive(false);
        comum.SetActive(false);
        bateria.SetActive(false);
        inicial.SetActive(false);
    }

    public void Metal()
    {
        DesativaTodos();
        metal.SetActive(true);
    }

    public void Plastico()
    {
        DesativaTodos();
        plastico.SetActive(true);
    }

    public void Vidro()
    {
        DesativaTodos();
        vidro.SetActive(true);
    }

    public void Papel()
    {
        DesativaTodos();
        papel.SetActive(true);
    }

    public void Comum()
    {
        DesativaTodos();
        comum.SetActive(true);
    }

    public void Bateria()
    {
        DesativaTodos();
        bateria.SetActive(true);
    }

    public void Inicial()
    {
        DesativaTodos();
        inicial.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
