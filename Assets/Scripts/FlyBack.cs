﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBack : MonoBehaviour {

    // Use this for initialization
//    private Rigidbody rb;
    private Animator animator;
    public GameObject nuke;

    private void Start()
    {
  //      rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other) {
        animator.SetBool("hasWolfEntered", true);
        if (nuke != null)
        {
            nuke.transform.position = transform.position;
            nuke.SetActive(true);
        }
        
    }




}