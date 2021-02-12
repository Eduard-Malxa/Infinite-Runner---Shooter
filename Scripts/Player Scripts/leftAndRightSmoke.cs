using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftAndRightSmoke : MonoBehaviour
{
    public GameObject smokePosition;
    public GameObject smoke;
    void Start()
    {
        StartCoroutine(activateSmokePos());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.PLATFORM_TAG)
        {
            if (smokePosition.activeInHierarchy)
            {
                Instantiate(smoke, smokePosition.transform.position, Quaternion.identity);
            }
        }
    }


    IEnumerator activateSmokePos()
    {
        yield return new WaitForSeconds(1.5f);
        smokePosition.gameObject.SetActive(true);
    }
}
