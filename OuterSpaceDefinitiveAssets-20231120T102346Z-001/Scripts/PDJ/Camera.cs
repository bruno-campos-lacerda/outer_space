using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera : MonoBehaviour {
    [SerializeField]
    private Transform protagonista;
    [SerializeField]
    private Vida vida;

    [SerializeField]
    private vida LifeInimigos;

    [SerializeField]
    private AudioSource BACOmorte;

    public float x, y;
    public bool podeSeguir;
    public bool BACOmorreu;

    public int limitex, limitey;
    public int iniciox, inicioy;

    public void Start() {
        BACOmorreu = false;
        podeSeguir = true;
    }

    private void Update() {
        if(BACOmorreu == true) {
            BACOmorte.Play();
        }
    }

    void FixedUpdate() {
        x = protagonista.transform.position.x;
        y = protagonista.transform.position.y;
        if (x < 0 || x > limitex || y > limitey) {
            podeSeguir = false;
        } else {
            podeSeguir = true;
        }
        if(y < 0) {
            vida.vida = 0;
        }
        if (podeSeguir) {
            transform.position = Vector2.Lerp(transform.position, protagonista.position, 0.2f);
        }
    }
}
