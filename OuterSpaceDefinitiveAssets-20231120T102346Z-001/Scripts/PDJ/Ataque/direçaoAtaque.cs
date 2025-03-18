using UnityEngine;

public class direçaoAtaque : MonoBehaviour {
    bool podeA = true, podeD = false;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.A) && podeA) {
            podeA = false;
            podeD = true;
            transform.Rotate(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.D) && podeD) {
            podeA = true;
            podeD = false;
            transform.Rotate(0, 180, 0);
        }
    }
}
