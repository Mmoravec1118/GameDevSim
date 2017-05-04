﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgrammingEnemy : Enemy {

	// Use this for initialization
	
	// Update is called once per frame
	//void Update () {
		
	//}

    public override void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "PlayerBullet")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().ShotsHit++;
            controller.ProgramValue.currValue -= 5;
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }
}
