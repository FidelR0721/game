using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball_01 : MonoBehaviour
{
   GameObject target;
   public float speed;
   Rigidbody2D bulletRB;

   void  Start()
   {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector4 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector4(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
   }
}
