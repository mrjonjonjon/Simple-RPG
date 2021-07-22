using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

// 1
public abstract class character : MonoBehaviour {
// 2
 
public virtual IEnumerator FlickerCharacter()
{
// 1
 GetComponent<SpriteRenderer>().color = Color.red;
// 2
 yield return new WaitForSeconds(0.1f);
 // 3
 GetComponent<SpriteRenderer>().color = Color.white;
}

 public float maxHitPoints;
 public float startingHitPoints;


public virtual void KillCharacter()
{
// 2
 Destroy(gameObject);
}

public abstract void ResetCharacter();

public abstract IEnumerator DamageCharacter(int damage, float interval);
}