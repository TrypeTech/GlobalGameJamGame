using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10;
    public Transform movingPlatform;
    public Transform startPos;
    public Transform endPos;
    public Vector3 newPosition;
    public string currentState;
    public float smooth;
    public float resetTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // This Function detects if the player caliding with it and returns true or false
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = transform;
        }
    }
    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = null;
        }
    }

    void movePlatform()
    {
        movingPlatform.position = Vector3.Lerp(movingPlatform.position, newPosition, smooth * Time.deltaTime);
    }
    void ChangeTarget()
    {
        if(currentState == "Moving To Position 1"){
            currentState = "Moving To Position 2";
            newPosition = endPos.position;
        }
        else if(currentState == "Moving To Position 2"){
            currentState = "Moving To Position 1";
            newPosition = startPos.position;

        }
        else if(currentState == ""){
            currentState = "Moving To Position 2";
            newPosition = endPos.position;
        }
        Invoke("ChangeTarget", resetTime);
    }

}
