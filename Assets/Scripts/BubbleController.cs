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

    private Camera _mainCamera;
    
    private void Start()
    {
        _numberFromAudio = GetComponent<NumberFromAudioClip>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        horizontalInput *= -1;
        transform.Rotate(Vector3.forward * horizontalInput * rotationSpeed * Time.deltaTime);
        //lerp value from min scale to max scale
        transform.localScale = Vector3.Lerp(minScale, maxScale, _numberFromAudio.scaleLoudness);
        
        _mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        _mainCamera.transform.Rotate(Vector3.forward * horizontalInput * rotationSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        float speed = Mathf.Clamp(_numberFromAudio.speedLoudness, minSpeed, maxSpeed);
        Debug.Log("Speed " + speed);
        _rigidbody2D.velocity = Vector2.right.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        deathMenu.SetActive(true);
    }
}