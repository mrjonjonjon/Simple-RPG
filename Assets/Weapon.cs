using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 2
public class Weapon : MonoBehaviour
{
    public float weaponVelocity;
// 3
 public GameObject ammoPrefab;
// 4
 static List<GameObject> ammoPool;
// 5
 public int poolSize;
// 6
 void Awake()
 {// 7
 if (ammoPool == null)
 {
 ammoPool = new List<GameObject>();
 }
// 8
 for (int i = 0; i < poolSize; i++)
 {
 GameObject ammoObject = Instantiate(ammoPrefab);
 ammoObject.SetActive(false);
 ammoPool.Add(ammoObject);
 }
 }

// 1
 void Update()
 {
// 2
 if (Input.GetMouseButtonDown(0))
 {
// 3
 FireAmmo();
 }
 }
// 4
 GameObject SpawnAmmo(Vector3 location)
 {
foreach (GameObject ammo in ammoPool)
 {
// 2
 if (ammo.activeSelf == false)
 {// 3
 ammo.SetActive(true);
// 4
 ammo.transform.position = location;
// 5
 return ammo;
 }
 }
// 6
 return null;
 


 }
// 5
 void FireAmmo()
 {
 
Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
// 2
 GameObject ammo = SpawnAmmo(transform.position);
// 3
 if (ammo != null)
 {
// 4
 Arc arcScript = ammo.GetComponent<Arc>();
// 5
 float travelDuration = 1.0f / weaponVelocity;
 // 6
 StartCoroutine(arcScript.TravelArc(mousePosition,
travelDuration));
 }


 }
// 6
 void OnDestroy()
 {
 ammoPool = null;
 }

 


}