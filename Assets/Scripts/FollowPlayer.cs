using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 offset = new Vector3(0.0f, 0.0f, -10);
    public Transform playerChar;
    public float smoothSpeed = 0.5f;
    private Vector3 velo = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = playerChar.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, playerPos, ref velo, smoothSpeed);
    }
}
