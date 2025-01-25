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
    public GameObject winMenu;
    public TMPro.TMP_Text scoreDisplay;
    public Timer timer;
    public SpriteRenderer sprite;
    public Sprite stillSprite;
    public Sprite moveSprite;

    // New variables for bubbly effects
    [Header("Bubbly Effect Settings")]
    public float localRotationSpeed = 2f; // Speed of local rotation oscillation
    public float scaleFrequency = 2f;    // Frequency of compression/decompression
    public float scaleAmplitude = 0.1f;  // Amplitude of the scaling effect

    private float localRotationAngle = 0f;
    private Vector3 baseScale;
    private float enlapsedCoyoteTime = 0f;
    private bool coyoting = false;
    public float coyoteBuffer = 1f;

    private void Start()
    {
        _numberFromAudio = GetComponent<NumberFromAudioClip>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        baseScale = transform.localScale; // Save the original scale
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        horizontalInput *= -1;
        transform.Rotate(Vector3.forward * horizontalInput * rotationSpeed * Time.deltaTime);

        // Scale the GameObject based on loudness
        transform.localScale = Vector3.Lerp(minScale, maxScale, _numberFromAudio.loudness);

        // Make the camera follow the GameObject
        _mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        _mainCamera.transform.Rotate(Vector3.forward * horizontalInput * rotationSpeed * Time.deltaTime);

        // Bubbly Effects
        ApplyBubblyEffects();

        if (coyoting)
        {
            enlapsedCoyoteTime += Time.deltaTime;
            if (enlapsedCoyoteTime > coyoteBuffer)
            {
                deathMenu.SetActive(true);  
                if (timer != null)
                {
                    timer.Stop();
                }
            }
        }
    }

    private void ApplyBubblyEffects()
    {
        // Local rotation oscillation
        localRotationAngle += localRotationSpeed * Time.deltaTime;
        float rotationOffset = Mathf.Sin(localRotationAngle) * 5f; // Adjust 5f to control max rotation angle
        sprite.transform.localRotation = Quaternion.Euler(0, 0, rotationOffset);

        // Compression and decompression
        float scaleOffset = Mathf.Sin(Time.time / scaleFrequency) * scaleAmplitude; // Slow down compression/decompression
        Vector3 newScale = baseScale + new Vector3(scaleOffset, scaleOffset, 0); // Both X and Y axes scale the same
        sprite.transform.localScale = newScale;
    }

    private void FixedUpdate()
    {
        float speed = Mathf.Lerp(minSpeed, maxSpeed, _numberFromAudio.loudness);
        _rigidbody2D.velocity = transform.right.normalized * speed;

        if (speed > 0.1)
        {
            sprite.sprite = moveSprite;
        }
        else
        {
            sprite.sprite = stillSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Win"))
        {
            //deathMenu.SetActive(true);
            //timer.Stop();
            enlapsedCoyoteTime = 0f;
            coyoting = true;
        }
        else
        {
            winMenu.SetActive(true);
            scoreDisplay.text = timer.score;
            timer.Stop();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        enlapsedCoyoteTime = 0f;
        coyoting = false;
    }
}
