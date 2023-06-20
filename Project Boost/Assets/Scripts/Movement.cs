using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody rb;
    private AudioSource audioSource;
    [SerializeField] private float thrustPower;
    [SerializeField] private float rotationPower;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        
    }

    private void ProcessThrust() {

    Vector3 force = Vector3.up * thrustPower;

        if (Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(force);
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        } else {
            audioSource.Stop();
        }
    }

    private void ProcessRotation() {
        if (Input.GetKey(KeyCode.D)) {
            ApplyRotation(-rotationPower);
        } else if (Input.GetKey(KeyCode.Q)) {
            ApplyRotation(rotationPower);
        }
    }

    private void ApplyRotation(float rotationThisFrame) {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
