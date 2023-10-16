using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleItem : MonoBehaviour
{
    //variables for item collection
    public Transform playerPos;
    private Vector3 centered = new Vector3(0f,1f,0f);

    //variables for rotation
    private static float rotateSpeed = 50f;

    //variables for bouncing
    private Vector3 startPos;
    private Vector3 displacement = new Vector3(0f,0f,0f);
    private float bounceAmount = 0.15f;
    public float timeSlow = 5f;
    public float startTime = 0f;
    
    void Start()
    {
        startPos = transform.position;
    }
    
    void Update()
    {
        transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y+Time.deltaTime*rotateSpeed);

        displacement = new Vector3(0f, bounceAmount*Mathf.Sin(Time.time*timeSlow+startTime), 0f);
        transform.position = startPos + displacement;

        RaycastHit hit;
        if (Physics.Raycast(transform.position+centered, playerPos.position, out hit, 0.7f)) {
            if(hit.collider.GetComponent<PlayerMovement>() != null) {
                Collect();
            }
        }
    }

    public void Collect() {
        Destroy(gameObject);
    }
}
