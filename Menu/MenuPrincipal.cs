using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelmenuInicial;
    [SerializeField] private GameObject painelOpçoes;
    public void Jogar() {
        SceneManager.LoadScene("SpaçoSideral");
    }



    public void AbrirMenu() {
        painelmenuInicial.SetActive(false);
        painelOpçoes.SetActive(true);
    }

    public void FecharMenu() {
        painelOpçoes.SetActive(false);
        painelmenuInicial.SetActive(true);
    }

    public void SairJogo() {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}