using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController CC;

    static private float moveSpeed = 15.0f;

    public Vector3 spawnPos;
    public Vector3 startPos; //for retrieving initial starting point coordinates

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        CC = GetComponent<CharacterController>();
        startPos = transform.position;
        spawnPos = startPos;
    }
    
    void Update() {
        Vector3 move = Vector3.zero;

        float forwardMove = Input.GetAxis("Vertical");
		float sideMove = Input.GetAxis("Horizontal");

		move += ((transform.forward * forwardMove) + (transform.right * sideMove)) * moveSpeed * Time.deltaTime; //horizontal movement
		CC.Move(move);
    }

    void Respawn() { //respawns player
        CC.enabled = false;
        transform.position = spawnPos;
        CC.enabled = true;
    }
}
