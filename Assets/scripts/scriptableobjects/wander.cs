using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
//[RequireComponent(typeof(Animator))]

public class wander : MonoBehaviour
{
     
 public float pursuitSpeed;
 public float wanderSpeed;
 float currentSpeed;
  public float directionChangeInterval;
  public bool followPlayer;
// 4
 Coroutine moveCoroutine;
// 5
 Rigidbody2D rb2d;
 Animator animator;
// 6
 Transform targetTransform = null;
// 7
 Vector3 endPosition;
// 8
 float currentAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        
 currentSpeed = wanderSpeed;
// 3
 rb2d = GetComponent<Rigidbody2D>();
// 4
 StartCoroutine(WanderRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 1
public IEnumerator WanderRoutine()
{
// 2
 while (true)
 {
// 3
 ChooseNewEndpoint();
//4
 if (moveCoroutine != null)
 {
// 5
 StopCoroutine(moveCoroutine);
 }
// 6
 moveCoroutine = StartCoroutine(Move(rb2d,
currentSpeed));
// 7
 yield return new WaitForSeconds(directionChangeInterval);
 }
}


void ChooseNewEndpoint()
{
// 2
 currentAngle += Random.Range(0, 360);
// 3
 currentAngle = Mathf.Repeat(currentAngle, 360);
// 4
 endPosition += Vector3FromAngle(currentAngle);
}

Vector3 Vector3FromAngle(float inputAngleDegrees)
{
// 1
 float inputAngleRadians = inputAngleDegrees * Mathf.Deg2Rad;
// 2
 return new Vector3(Mathf.Cos(inputAngleRadians),
Mathf.Sin(inputAngleRadians), 0);
}


public IEnumerator Move(Rigidbody2D rigidBodyToMove, float
speed)
{
// 1
 float remainingDistance = (transform.position -
endPosition).sqrMagnitude;
// 2
 while (remainingDistance > float.Epsilon)
 {// 3
 if (targetTransform != null)
 {
 endPosition = targetTransform.position;
 }
// 4
 if (rigidBodyToMove != null)
 {
// 5
 //animator.SetBool("isWalking", true);
// 6
 Vector3 newPosition = Vector3.MoveTowards(rigidBodyToMove.position, endPosition,speed * Time.deltaTime);
// 7
 rb2d.MovePosition(newPosition);
// 8
 remainingDistance = (transform.position -
endPosition).sqrMagnitude;
 }
// 9
 yield return new WaitForFixedUpdate();
 }
// 10
 //animator.SetBool("isWalking", false);
}

void OnTriggerEnter2D(Collider2D collision)
{
// 1
 if (collision.gameObject.CompareTag("Player") &&
followPlayer)
 {
// 2
 currentSpeed = pursuitSpeed;
// 3
 targetTransform = collision.gameObject.transform;
// 4
 if (moveCoroutine != null)
 {
 StopCoroutine(moveCoroutine);
 }
// 5
 moveCoroutine = StartCoroutine(Move(rb2d,
currentSpeed));
 }
}

void OnTriggerExit2D(Collider2D collision)
{
// 1
 if (collision.gameObject.CompareTag("Player"))
 {
// 2
 //animator.SetBool("isWalking", false);
 // 3
 currentSpeed = wanderSpeed;
// 4
 if (moveCoroutine != null)
 {
 StopCoroutine(moveCoroutine);
 }
// 5
 targetTransform = null;
 }
}





}
