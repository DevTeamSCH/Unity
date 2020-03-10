using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    public GameObject ImpactEffect;
    public float bulletSpeed = 50f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position+Vector3.up*1.5f - transform.position;
        float distanceThisFrame = bulletSpeed * Time.deltaTime;
        if(dir.magnitude<=distanceThisFrame)
        {
            HitTarget();
        }
        transform.Translate(dir.normalized * distanceThisFrame,Space.World);
    }

    private void HitTarget()
    {
        GameObject effectInstance=Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 1f);
        Destroy(gameObject);

    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
}
