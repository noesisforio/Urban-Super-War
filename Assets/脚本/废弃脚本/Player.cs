using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController2D cc;

    float move;
    bool jump;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        cc=GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        move *=speed;
        jump = Input.GetButton("Jump");
    }
    private void FixedUpdate()
    {
        cc.Move(move, jump);
    }
}
