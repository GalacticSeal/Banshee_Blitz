using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private float mouseSensitivity = 200f;
    private float camRotation = 0f;

	public Transform CamTransform;
	private CharacterController CC;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
        CC = GetComponent<CharacterController>();
	}

	private void Update()
	{
		float mouseInputY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
		camRotation -= mouseInputY;
		camRotation = Mathf.Clamp(camRotation, -80f, 80f);
		CamTransform.localRotation = Quaternion.Euler(camRotation, 0f, 0f);

		float mouseInputX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, mouseInputX));	
	}
}
