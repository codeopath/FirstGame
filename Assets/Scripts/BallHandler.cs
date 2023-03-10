using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Rigidbody2D pivot;
    [SerializeField] private float reSpawnDelay;


    private Camera mainCamera;
    private bool isDragging;

    private Rigidbody2D currentBallRigidBody;
    private SpringJoint2D currentPivot;
    private Rigidbody2D obstacle;

    // Start is called before the first frame update
    void Start() {
        SpawnNewBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBallRigidBody == null) {
            return;
        }
        if(!Touchscreen.current.primaryTouch.press.isPressed) {
            if(isDragging) {
                LaunchBall();

            }
            isDragging = false;
            return;
        }
        isDragging = true;
        currentBallRigidBody.isKinematic = true;
        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
        currentBallRigidBody.position = worldPosition;
  
    }

    private void SpawnNewBall()
    {
        GameObject ballInstance = Instantiate(ballPrefab, pivot.position, Quaternion.identity);
        currentBallRigidBody = ballInstance.GetComponent<Rigidbody2D>();
        currentBallRigidBody.mass = 2000;
        currentPivot = ballInstance.GetComponent<SpringJoint2D>();
        currentPivot.connectedBody = pivot;
    }

    private void LaunchBall() {
        currentBallRigidBody.isKinematic = false;
        currentBallRigidBody = null; 
        Invoke(nameof(DetachBall), 0.25F);
        
    }

    private void DetachBall() {
        currentPivot.enabled = false;
        currentPivot = null;
        Invoke(nameof(SpawnNewBall), reSpawnDelay);
        //Start();
    }
}
