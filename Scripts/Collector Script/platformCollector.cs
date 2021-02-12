using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformCollector : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.HEALTH_TAG || other.gameObject.tag == Tags.PLATFORM_TAG || other.gameObject.tag == Tags.MONSTER_TAG)
        {
            other.gameObject.SetActive(false);
        }
    }
}
