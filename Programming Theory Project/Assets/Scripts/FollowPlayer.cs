using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3 (0,1.01f,-.75f);

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
