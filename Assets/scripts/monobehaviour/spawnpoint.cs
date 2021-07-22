using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnpoint : MonoBehaviour
{



    public GameObject prefabToSpawn;
// 2
 public float repeatInterval;
 public void Start()
 {
// 3
 if (repeatInterval > 0)
 {
// 4
 InvokeRepeating("SpawnObject", 0.0f, repeatInterval);
 }else if(repeatInterval==-1){
SpawnObject();
 }

 }
// 5
 public GameObject SpawnObject()
 {
// 6
 if (prefabToSpawn != null)
 {
// 7
 return Instantiate(prefabToSpawn, transform.
position, Quaternion.identity);
 }
    // 8
 return null;
 }
}