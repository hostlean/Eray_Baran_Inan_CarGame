using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private GameObject text;

    private void Awake()
    {
        text.SetActive(false);
        gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, .2f);
        Gizmos.DrawSphere(transform.position, 2f);
    }
}
