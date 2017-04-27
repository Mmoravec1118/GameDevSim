﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignEnemy : Enemy {

	// Use this for initialization
	
	// Update is called once per frame
	//void Update () {
		
	//}

    public override void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "PlayerBullet")
        {
            controller.DesignValue.currValue += 5;
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }
}