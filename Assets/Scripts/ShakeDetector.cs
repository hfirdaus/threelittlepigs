using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ShakeDetector : MonoBehaviour
{

    public float ShakeDetectionThreshold;
    public float MinShakeInterval;

    private float sqrShakeDetectionThreshold;
    private float timeSinceLastShake;
    private Animator animator;
    MicrophoneInput micIn;

    //   private PhysicsController physicsController;

    public void Start()
    {
        sqrShakeDetectionThreshold = Mathf.Pow(ShakeDetectionThreshold, 2);
        animator = GetComponent<Animator>();
        //        physicsController = GetComponent<PhysicsController>();
        Input.gyro.enabled = true;
        micIn = FindObjectOfType<AudioSource>().GetComponent<MicrophoneInput>();
    }

    public void FixedUpdate()
    {
        if (animator.GetBool("hasWolfBlown") == true)
        {
            animator.SetBool("hasWolfBlown", false);
        }

        if (micIn.loudness > micIn.threshold)
        {
            animator.SetBool("hasWolfBlown", true);
        }
        
        if (Input.acceleration.sqrMagnitude >= sqrShakeDetectionThreshold
                  && Time.unscaledTime >= timeSinceLastShake + MinShakeInterval)
        {
            animator.SetBool("hasWolfShaken", true);
            timeSinceLastShake = Time.unscaledTime;
        }
        
    }
}
