using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAction : MonoBehaviour
{
    // Start is called before the first frame update
    private static Dictionary<GameObject, int> objectHits = new Dictionary<GameObject, int>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!objectHits.ContainsKey(collision.gameObject))
        {
            this.gameObject.SetActive(false);
            objectHits.Add(collision.gameObject, 1);
        }
        objectHits[collision.gameObject]++;
        if (objectHits[collision.gameObject] >= 5)
        {
            collision.gameObject.SetActive(false);
        }
    }
}
