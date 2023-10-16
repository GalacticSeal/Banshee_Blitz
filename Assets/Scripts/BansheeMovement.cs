using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BansheeMovement : MonoBehaviour
{
    public GameObject player;
    private PlayerMovement playerMove;

    public Transform bansheeCenter;
    public Vector3 spawnPos;

    private float slowDown = 0.35f; //how much the banshee is slowed down moving through walls
    private float speedMod = 0.8f; //normal slowdown on banshee outside of walls
    private bool isActive = false;

    void Start()
    {
        spawnPos = transform.position;
        playerMove = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        transform.LookAt(player.transform, transform.up); //looks towards player
        transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);//readjusts rotation so the banshee is upright at all times

        if(!isActive) {
            isActive = player.transform.position != playerMove.spawnPos; //activates banshee when the player first moves after spawning or respawning
        } else {
            RaycastHit hit;
            if (Physics.Raycast(bansheeCenter.transform.position, bansheeCenter.transform.forward, out hit, 0.7f)) { //detects for player in front
                if((hit.collider.GetComponent<PlayerMovement>()) != null) {
                    playerMove.Respawn();
                    Respawn();
                } else {
                    transform.position += transform.forward*playerMove.moveSpeed*Time.deltaTime*slowDown;
                }
                Debug.DrawLine(bansheeCenter.transform.position, bansheeCenter.transform.position+bansheeCenter.transform.forward*0.7f, Color.green);
            } else {
                transform.position += transform.forward*playerMove.moveSpeed*Time.deltaTime*speedMod;
                Debug.DrawLine(bansheeCenter.transform.position, bansheeCenter.transform.position+bansheeCenter.transform.forward*0.7f, Color.red);
            }
        }
    }

    public void Respawn() { //respawns Banshee
        transform.position = spawnPos;
        isActive = false;
    }
}