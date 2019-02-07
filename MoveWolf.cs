using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWolf : MonoBehaviour {

    GameObject wolf;
    Rigidbody wolfRB;
    GameObject strawHouse;
    GameObject woodHouse;
    GameObject brickHouse;

    bool justStarted = true;
    bool atStrawHouse = false;
    bool atWoodHouse = false;
    bool atBrickHouse = false;

    // Update is called once per frame
    void Update()
    {
        // if just started and see straw house >>> move wolf to straw house from any location
        if (justStarted && strawHouse.activeInHierarchy)
        {
            // move wolf to straw house
            wolf.SetActive(true);
            wolf.transform.LookAt(strawHouse.transform.position + wolfRB.velocity);
            wolfRB.MovePosition(strawHouse.transform.position);
            justStarted = false;
            atStrawHouse = true;
        }
        // if wolf at straw house and see wood house >> move wolf to wood house from straw house
        if (!justStarted && strawHouse.activeInHierarchy && woodHouse.activeInHierarchy && atStrawHouse)
        {
            // move wolf to wood house
            wolf.transform.LookAt(woodHouse.transform.position + wolfRB.velocity);
            wolfRB.MovePosition(woodHouse.transform.position);
            atStrawHouse = false;
            atWoodHouse = true;
        }
        // if wolf at wood house and see brick house >> move wolf to brick house from straw house
        if (!justStarted && woodHouse.activeInHierarchy && brickHouse.activeInHierarchy && atWoodHouse)
        {
            // move wolf to brick house
            wolf.transform.LookAt(brickHouse.transform.position + wolfRB.velocity);
            wolfRB.MovePosition(brickHouse.transform.position);
            atWoodHouse = false;
            atBrickHouse = true;
        }
    }



    // Use this for initialization
    void Start () {
        foreach (Transform child in transform)
        {
            if (child.tag == "Straw")
                strawHouse = child.gameObject;
            if (child.tag == "Wood")
                woodHouse = child.gameObject;
            if (child.tag == "Brick")
                brickHouse = child.gameObject;
            if (child.tag == "Wolf")
            {
                wolf = child.gameObject;
                wolfRB = child.gameObject.GetComponent<Rigidbody>();
            }
        }
        wolf.SetActive(false);
    }
	
}
