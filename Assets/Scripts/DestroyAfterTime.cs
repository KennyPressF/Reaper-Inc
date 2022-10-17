using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] float timeBeforeDestroy;

    private void Start()
    {
        Destroy(gameObject, timeBeforeDestroy);
    }
}
