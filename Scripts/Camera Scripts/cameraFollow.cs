using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    private Transform playerTransform;
    public float offsetX = 9f;
    public float offsetY = 4f;
    public float offsetZ = -11f;
    public float lerpTime = 0.05f;


    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
    }
    void FixedUpdate()
    {
        if (playerTransform)
        {
            Vector3 cameraMove = new Vector3(playerTransform.position.x + offsetX, offsetY, playerTransform.position.z + offsetZ);
            transform.position = Vector3.Lerp(transform.position, cameraMove, lerpTime);
        }
    }
}
