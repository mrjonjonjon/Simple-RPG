using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RPGGamemanager : MonoBehaviour
{
    public spawnpoint playerSpawnPoint;
    // 1
      

 public static RPGGamemanager sharedInstance = null;



 public void SpawnPlayer()
{
// 1
 if (playerSpawnPoint != null)
 {
// 2
 GameObject player = playerSpawnPoint.SpawnObject();
 
 }
}

 void Awake()
 {

 // 2
 if (sharedInstance != null && sharedInstance != this)
 {
// 3
 Destroy(gameObject);
 }
 else
 {
// 4
 sharedInstance = this;
 }
 }
 void Start()
 {
// 5
 SetupScene();
 }
// 6
 public void SetupScene()
 {
 SpawnPlayer();
 }


}



