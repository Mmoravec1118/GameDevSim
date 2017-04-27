using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    public float leftConstraint = 0.0f;
    public float rightConstraint = 0.0f;
    public float topConstraint = 0.0f;
    public float bottomConstraint = 0.0f;
    public float distanceZ = 10.0f;
    // Use this for initialization
    
    void Start()
    {
        leftConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;

        bottomConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        topConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, distanceZ)).y;

    }

    // Update is called once per frame
    void Update() {
        transform.position += transform.forward * speed;

        if (transform.position.x < leftConstraint || transform.position.x > rightConstraint || transform.position.y < bottomConstraint || transform.position.y > topConstraint)
        {
            Destroy(gameObject);
        }
    }
}
