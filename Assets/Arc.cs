using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arc : MonoBehaviour
{
    // 2
 public IEnumerator TravelArc(Vector3 destination, float
duration)
 {
// 3
 var startPosition = transform.position;
// 4
 var percentComplete = 0.0f;
// 5
 while (percentComplete < 1.0f)
 {// 6
 percentComplete += Time.deltaTime / duration;
// 7
 transform.position = Vector3.Lerp(startPosition,
destination, percentComplete);
// 8
 yield return null;
 }
// 9
 gameObject.SetActive(false);
 }
}



