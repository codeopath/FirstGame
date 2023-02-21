using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorControler : MonoBehaviour
{
    [SerializeField] FixedJoystick fixedJoystick;
    [SerializeField] float moveSpeed;
    [SerializeField] WarriorHandler warriorHandler;

    private void Update()
    {
        Rigidbody2D warriorRigidBody = warriorHandler.WarriorInstance.GetComponent<Rigidbody2D>();
        warriorRigidBody.velocity = new Vector3(fixedJoystick.Horizontal * moveSpeed, 0);
    }
}
