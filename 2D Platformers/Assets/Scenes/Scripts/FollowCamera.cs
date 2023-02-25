using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // speed in which the camera moves
    public float FollowSpeed = 2f;
    public Transform target;
  // every update makes sure that the camera follows the position of the player
    void Update()
    {

        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);

        
    }
}
