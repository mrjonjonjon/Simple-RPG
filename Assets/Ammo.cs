﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
// 1
 public int damageInflicted;
// 2
 void OnTriggerEnter2D(Collider2D collision)
 {
// 3
if (collision is BoxCollider2D)
 {
// 4
 enemy enemy = collision.gameObject.GetComponent<enemy>();
// 5
 StartCoroutine(enemy.DamageCharacter(damageInflicted, 0.0f));
// 6
 gameObject.SetActive(false);
 }
 }
}