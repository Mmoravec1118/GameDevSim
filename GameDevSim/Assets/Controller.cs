using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    [SerializeField]
    GameObject DesignEnemy, ProgramEnemy, ArtEnemy;
    float timer = 0;

    public value DesignValue, ProgramValue, ArtValue;

    public float leftConstraint = 0.0f;
    public float rightConstraint = 0.0f;
    public float topConstraint = 0.0f;
    public float bottomConstraint = 0.0f;
    public float distanceZ = 10.0f;
    // Use this for initialization
    void Start () {
        leftConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;

        bottomConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        topConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, distanceZ)).y;

    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;

        if (timer > 3)
        {
            timer = 0f;
            switch (Random.Range(0,3))
            {
                case 0:
                    SpawnEnemy(ArtEnemy);
                    break;
                case 1:
                    SpawnEnemy(DesignEnemy);
                    break;
                case 2:
                    SpawnEnemy(ProgramEnemy);
                    break;

                default:
                    break;
            }
        }
	}
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, new Vector3(Random.Range(leftConstraint, rightConstraint), Random.Range(bottomConstraint, topConstraint)),new Quaternion());
    }
}
