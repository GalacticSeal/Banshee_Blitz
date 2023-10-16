using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController CC;

    public float moveSpeed = 12.0f;

    public Vector3 spawnPos;
    public Vector3 startPos; //for retrieving initial starting point coordinates
    private Vector3 moveDirect;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        CC = GetComponent<CharacterController>();
        startPos = transform.position;
        spawnPos = startPos;
    }
    
    void Update() {
        Vector3 move = Vector3.zero;
        moveDirect = new Vector3(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), 0f); //gets inputs as Vector3
        moveDirect = Vector3.Normalize(moveDirect); //normalizes direction so diagonal movement does not cause you to move faster

		move += ((transform.forward * moveDirect.x) + (transform.right * moveDirect.y)) * moveSpeed * Time.deltaTime; //horizontal movement
		CC.Move(move);
    }

    public void Respawn() { //respawns player
        CC.enabled = false;
        transform.position = spawnPos;
        CC.enabled = true;
    }
}
