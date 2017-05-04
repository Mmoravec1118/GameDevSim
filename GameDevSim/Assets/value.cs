using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class value : MonoBehaviour {
    public float currValue;
    enum EnemyType { Design, Programming, Art, Sanity}
    [SerializeField]
    EnemyType enemyType;
    public 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        switch (enemyType)
        {
            case EnemyType.Design:
                foreach (GameObject item in GameObject.FindGameObjectsWithTag("Design"))
                {
                    currValue += Time.deltaTime;
                }
                break;
            case EnemyType.Programming:
                foreach (GameObject item in GameObject.FindGameObjectsWithTag("Programming"))
                {
                    currValue += Time.deltaTime;
                }
                break;
            case EnemyType.Art:
                foreach (GameObject item in GameObject.FindGameObjectsWithTag("Art"))
                {
                    currValue += Time.deltaTime;
                }
                break;
            case EnemyType.Sanity:
                break;
            default:
                break;
        }

        currValue = Mathf.Clamp(currValue, 0, 100);
    }
}
