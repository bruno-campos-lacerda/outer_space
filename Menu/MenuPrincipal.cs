using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelmenuInicial;
    [SerializeField] private GameObject painelOp�oes;
    public void Jogar() {
        SceneManager.LoadScene("Spa�oSideral");
    }



    public void AbrirMenu() {
        painelmenuInicial.SetActive(false);
        painelOp�oes.SetActive(true);
    }

    public void FecharMenu() {
        painelOp�oes.SetActive(false);
        painelmenuInicial.SetActive(true);
    }

    public void SairJogo() {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}