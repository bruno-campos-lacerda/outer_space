using UnityEngine;

public class gravidadeControle : MonoBehaviour {
    public Transform planeta;

    Rigidbody2D rig;

    public float forçaGravidade;

    public float distanciaGravidade;

    float angulo;

    public bool podeGravitar;

    void Start() {
        rig = GetComponent<Rigidbody2D>();
        podeGravitar = false;
    }

    void Update() {
        float distancia = Vector3.Distance(gameObject.transform.position, planeta.transform.position);
        Vector3 velocidade = planeta.transform.position - transform.position;
        angulo = 90 + Mathf.Atan2(velocidade.y, velocidade.x) * Mathf.Rad2Deg;

        if (podeGravitar) {
            rig.gravityScale = 0f;
            rig.velocity = velocidade.normalized * (1.0f - distancia / distanciaGravidade) * forçaGravidade;
            transform.rotation = Quaternion.Euler(0f, 0f, angulo);
        } else {
            rig.gravityScale = 4.9f;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
