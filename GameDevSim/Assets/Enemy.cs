using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    float timer = 0;
    protected Controller controller;
	// Use this for initialization
	protected void Start () {
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            GameObject bulletClone = Instantiate(Resources.Load("BulletEnemy"), transform.position, transform.rotation) as GameObject;
            bulletClone.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);

        }
    }
    
    public virtual void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "PlayerBullet")
        {
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }

}
