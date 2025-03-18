using System.Collections;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class créditos : MonoBehaviour {
    private bool podeReplay;

    private void Awake() {
        print("espere 3 segundos");
    }

    private void Start() {
        podeReplay = false;
    }

    void Update() {
        StartCoroutine(Replay());
        if (Input.anyKey && podeReplay) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
        }
    }
    IEnumerator Replay() {
        yield return new WaitForSeconds(3);
        podeReplay = true;
        print("pode retomar o jogo ");
        print("Prescione qualquer tecla");
    }
}
