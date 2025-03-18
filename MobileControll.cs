using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControll : MonoBehaviour {
    public GameObject left, right, jump;
    private controleMovimento controll;

    public float speed, direction, jumpForce;

    void Start() {
        controll = FindAnyObjectByType<controleMovimento>();
    }

    void Update() {

    }

    public void MoveRight(float move) {
        direction = 1;
        transform.Translate(new Vector2(speed* direction * Time.deltaTime, 0), Space.Self);
    }
}
