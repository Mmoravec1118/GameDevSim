using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float timer = 0;
    protected Controller controller;

    public float leftConstraint = 0.0f;
    public float rightConstraint = 0.0f;
    public float topConstraint = 0.0f;
    public float bottomConstraint = 0.0f;
    public float buffer = 1.0f; // set this so the spaceship disappears offscreen before re-appearing on other side
    public float distanceZ = 10.0f;

    // Use this for initialization
    protected void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>();

        leftConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;

        bottomConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        topConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, distanceZ)).y;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            GameObject bulletClone = Instantiate(Resources.Load("BulletEnemy"), transform.position, transform.rotation) as GameObject;
            bulletClone.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        }

        if (transform.position.x < leftConstraint - buffer)
        { // ship is past world-space view / off screen
            transform.position = new Vector3(rightConstraint + buffer, transform.position.y);  // move ship to opposite side
        }

        if (transform.position.x > rightConstraint + buffer)
        {
            transform.position = new Vector3(leftConstraint - buffer, transform.position.y);
        }

        if (transform.position.y < bottomConstraint - buffer)
        { // ship is past world-space view / off screen
            transform.position = new Vector3(transform.position.x, topConstraint + buffer);  // move ship to opposite side
        }

        if (transform.position.y > topConstraint + buffer)
        {
            transform.position = new Vector3(transform.position.x, bottomConstraint - buffer);
        }
    }

    public virtual void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "PlayerBullet")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().ShotsHit++;
            Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().ShotsHit);
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }

}
