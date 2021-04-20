using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upperTorsoLerpTo : MonoBehaviour
{
    [SerializeField] float slerpSpeed;
    [SerializeField] Transform lowerTorsoTarget;
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, lowerTorsoTarget.transform.rotation, slerpSpeed * Time.deltaTime);
        transform.position = lowerTorsoTarget.position;
    }
}
