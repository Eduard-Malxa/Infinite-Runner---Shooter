﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instatiateSmoke : MonoBehaviour
{
    public float timer = 1.5f;
    void Start()
    {
        StartCoroutine(stopEffect());
    }

    IEnumerator stopEffect()
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }
}
