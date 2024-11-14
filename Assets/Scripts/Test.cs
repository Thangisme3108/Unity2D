using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

   public GameObject effecBullet;
   public Transform target;
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("square"))
      {
         Destroy(this.gameObject, 2f);
         Instantiate(effecBullet, transform.position, Quaternion.identity);
      }
   }
}
