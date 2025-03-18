using UnityEngine;
using UnityEngine.SceneManagement;

public class Scener : MonoBehaviour
{
    [SerializeField]
    Vida vida;

    [SerializeField]
    private GameObject protagonista;

    public bool skip;

    private void Update() {
        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.K) && Input.GetKey(KeyCode.P)) {
            skip = true;
        }else if (skip) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.gameObject.layer == 17) {
            if(Input.GetKey(KeyCode.S)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public void Restart() {
        protagonista.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
