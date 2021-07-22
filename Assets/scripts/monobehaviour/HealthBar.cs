using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
// 2
 public HitPoints hitPoints;
// 3
 [HideInInspector]
 public player character;
// 4
 public Image meterImage;
 // 5
 public Text hpText;
// 6
 float maxHitPoints;
 void Start()
 {
// 7
 maxHitPoints = character.maxHitPoints;
 }
 void Update()
 {
// 8
 if (character != null)
 {
// 9
 meterImage.fillAmount = hitPoints.value /
  maxHitPoints;
// 10
 hpText.text = "HP:" + (meterImage.fillAmount * 100);
 }
 }
}