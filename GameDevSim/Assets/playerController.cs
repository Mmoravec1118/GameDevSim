using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    GameObject dock;

    [SerializeField]
    Material docked, flying;

    Vector2 move;

    public float shotsFired;
    public float ShotsHit;

    public float leftConstraint = 0.0f;
    public float rightConstraint = 0.0f;
    public float topConstraint = 0.0f;
    public float bottomConstraint = 0.0f;
    public float buffer = 1.0f; // set this so the spaceship disappears offscreen before re-appearing on other side
    public float distanceZ = 10.0f;

    // Use this for initialization
    void Start()
    {

        shotsFired = 1;
        ShotsHit = 1;

        move = new Vector2();
        leftConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;

        bottomConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        topConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, distanceZ)).y;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            move.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move.y = -1;
        }
        else
        {
            move.y = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move.x = 1;
        }
        else
        {
            move.x = 0;
        }
        move.Normalize();
        move *= speed;
        transform.position += new Vector3(move.x, move.y);

        if (Vector3.Distance(dock.transform.position, transform.position) > 1.5)
        {
            GetComponent<Renderer>().material = flying;
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

            if (Input.GetMouseButtonDown(0))
            {
                shotsFired++;
                Vector3 myPos = transform.position;
                float x = Input.mousePosition.x;
                float y = Input.mousePosition.y;
                Vector3 direction = Camera.main.ScreenToWorldPoint
                                (new Vector3(x, y, 0));
                GameObject bulletClone = Instantiate(Resources.Load("Bullet"), myPos, transform.rotation) as GameObject;
                bulletClone.transform.LookAt(new Vector3(direction.x, direction.y, 0));
            }
        }

        else
        {
            GetComponent<Renderer>().material = docked;
            GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>().Sanity.currValue += Time.deltaTime * 2;
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
            GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>().Sanity.currValue -= 5;
        }
    }
}
