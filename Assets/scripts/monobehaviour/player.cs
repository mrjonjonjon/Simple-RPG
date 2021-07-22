using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : character
{
    // Start is called before the first frame update
    //1
public HitPoints hitPoints;
public HealthBar healthBarPrefab;
public CircleCollider2D Collider2;
// 2
HealthBar healthBar;
void Start(){
   // healthBar = Instantiate(healthBarPrefab);
   // healthBar.character = this;
   // hitPoints.value = startingHitPoints;
// 2

}
public override void ResetCharacter()
{
// 1
 //inventory = Instantiate(inventoryPrefab);
 healthBar = Instantiate(healthBarPrefab);
 healthBar.character = this;
// 2
 hitPoints.value = startingHitPoints;
}



void OnTriggerEnter2D(Collider2D collision)
 {
 if (collision.gameObject.CompareTag("pickup"))
 {
 item hitObject = collision.gameObject.
GetComponent<consumable>().item;
 if (hitObject != null)
 {
 print("Hit: " + hitObject.objectName);
// 1
bool shouldDisappear = false;
 switch (hitObject.itemType)
 {
// 2
 case item.ItemType.COIN:
 shouldDisappear = true;
 break;
// 3
 case item.ItemType.HEALTH:
 shouldDisappear=AdjustHitPoints(hitObject.quantity);
 break;
 default:
 break;
 }
 if (shouldDisappear)
 {
 collision.gameObject.SetActive(false);
 }
 
 }
 }
 }
// 4
 public bool AdjustHitPoints(int amount)
 {


if (hitPoints.value < maxHitPoints)
 {
// 7
 hitPoints.value = hitPoints.value + amount;
// 8
 print("Adjusted HP by: " + amount + ". New value: " +
hitPoints.value);
// 9
 return true;
 }
// 10
 return false;

 }


// 1
public override IEnumerator DamageCharacter(int damage, float interval)
{
  
 while (true)
 {  
     StartCoroutine(FlickerCharacter());
 hitPoints.value = hitPoints.value - damage;
 if (hitPoints.value <= float.Epsilon)
 {
 KillCharacter();
 break;
 }
 if (interval > float.Epsilon)
 {
 yield return new WaitForSeconds(interval);
 }
 else
 {
 break;
 }
 }
}

public override void KillCharacter()
{
// 1
 base.KillCharacter();
// 2
 Destroy(healthBar.gameObject);
 //Destroy(inventory.gameObject);
}


private void OnEnable()
{
// 1
 ResetCharacter();
}
}


