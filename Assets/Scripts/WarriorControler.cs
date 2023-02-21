using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorControler : MonoBehaviour
{
    [SerializeField] FixedJoystick fixedJoystick;
    [SerializeField] float moveSpeed;
    [SerializeField] WarriorHandler warriorHandler;

    private Vector2 screenBounds;
    // Start is called before the first frame update

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, Camera.main.transform.position.z));
    }
    private void Update()
    {
        Debug.Log(fixedJoystick.Horizontal);
        Debug.Log(fixedJoystick.Vertical);
        Debug.Log(moveSpeed);
        Rigidbody2D warriorRigidBody = warriorHandler.WarriorInstance.GetComponent<Rigidbody2D>();
        Vector2 warriorPos = warriorRigidBody.position;
        Vector3 transPos = transform.position;
        warriorRigidBody.velocity = new Vector3(fixedJoystick.Horizontal * moveSpeed, 0);
        warriorPos.x = Mathf.Clamp(warriorPos.x, -screenBounds.x, screenBounds.x);
        warriorPos.y = Mathf.Clamp(warriorPos.y, -screenBounds.y, screenBounds.y);
    }
}
