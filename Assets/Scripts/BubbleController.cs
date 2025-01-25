using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    [Header("Scale Limits")]
    public Vector3 minScale;
    public Vector3 maxScale;
    
    [Header("Speed Limits")]
    public float minSpeed = 0f;
    public float maxSpeed = 10f;
    
    public float rotationSpeed = 100f;
    public GameObject deathMenu;

    private NumberFromAudioClip _numberFromAudio;
    private Rigidbody2D _rigidbody2D;

    public Camera _mainCamera;
    
    private void Start()
    {
        _numberFromAudio = GetComponent<NumberFromAudioClip>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        horizontalInput *= -1;
        transform.Rotate(Vector3.forward * horizontalInput * rotationSpeed * Time.deltaTime);

        transform.localScale = Vector3.Lerp(minScale, maxScale, _numberFromAudio.loudness);
        
        _mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        _mainCamera.transform.Rotate(Vector3.forward * horizontalInput * rotationSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        float speed = Mathf.Lerp(minSpeed, maxSpeed, _numberFromAudio.loudness);
        _rigidbody2D.velocity = transform.right.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        deathMenu.SetActive(true);
    }
}
