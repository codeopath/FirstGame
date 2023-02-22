using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryLimiter : MonoBehaviour
{
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 warriorPos = transform.position;
        Debug.Log(transform.position);
        Vector3 size = transform.GetComponent<SpriteRenderer>().bounds.size*7;
        warriorPos.x = Mathf.Clamp(warriorPos.x, -1 * (screenBounds.x - size.x), screenBounds.x - size.x * 2.3F);
        transform.position = warriorPos;
        Debug.Log(transform.position);
    }
}
