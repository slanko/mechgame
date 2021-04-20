using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    public float LThrottle, RThrottle, torsoTwistY, torsoTwistX;
    public bool Brakes = false;
    [SerializeField] float leftThrottle, rightThrottle, leftClampMax, rightClampMax, leftClampMin, rightClampMin, throttleSensitivity, turnSpeedModifier, moveSpeedModifier, brakeSensitivity;
    [SerializeField] Slider leftSlider, rightSlider;
    [SerializeField] Transform torsoRotatorY, torsoRotatorX;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //THROTTLES

        if (LThrottle != 0) leftThrottle += LThrottle * Time.deltaTime * throttleSensitivity;

        if (RThrottle != 0) rightThrottle += RThrottle * Time.deltaTime * throttleSensitivity;

        leftThrottle = Mathf.Clamp(leftThrottle, leftClampMin, leftClampMax);

        rightThrottle = Mathf.Clamp(rightThrottle, rightClampMin, rightClampMax);

        leftSlider.value = leftThrottle;
        rightSlider.value = rightThrottle;

        Vector3 forwardVector = new Vector3(transform.forward.x, transform.forward.y, transform.forward.z) * (leftThrottle + rightThrottle) * Time.deltaTime * moveSpeedModifier;
        rb.AddForce(forwardVector, ForceMode.VelocityChange);
    }

    void Update()
    {
        transform.Rotate(0, (leftThrottle - rightThrottle) * Time.deltaTime * turnSpeedModifier , 0);
        if (Brakes)
        {
            leftThrottle = Mathf.Lerp(leftThrottle, 0, Time.deltaTime * brakeSensitivity);
            rightThrottle = Mathf.Lerp(rightThrottle, 0, Time.deltaTime * brakeSensitivity);
        }

        torsoRotatorY.Rotate(0, torsoTwistY, 0);
        torsoRotatorX.Rotate(-torsoTwistX, 0, 0);
    }
}
