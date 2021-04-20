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
    float leftBrakeLerpAmount, rightBrakeLerpAmount;

    private void FixedUpdate()
    {
        //THROTTLES

        if (LThrottle != 0) leftThrottle += LThrottle * Time.deltaTime * throttleSensitivity;

        if (RThrottle != 0) rightThrottle += RThrottle * Time.deltaTime * throttleSensitivity;

        leftThrottle = Mathf.Clamp(leftThrottle, leftClampMin, leftClampMax);

        rightThrottle = Mathf.Clamp(rightThrottle, rightClampMin, rightClampMax);

        leftSlider.value = leftThrottle;
        rightSlider.value = rightThrottle;
    }

    void Update()
    {
        transform.Rotate(0, (leftThrottle - rightThrottle) * Time.deltaTime * turnSpeedModifier , 0);
        transform.Translate(0, 0, (leftThrottle + rightThrottle) * Time.deltaTime * moveSpeedModifier);

        if (Brakes)
        {
            leftThrottle = Mathf.Lerp(leftThrottle, 0, Time.deltaTime * brakeSensitivity);
            rightThrottle = Mathf.Lerp(rightThrottle, 0, Time.deltaTime * brakeSensitivity);
        }

        torsoRotatorY.Rotate(0, torsoTwistY, 0);
        torsoRotatorX.Rotate(-torsoTwistX, 0, 0);
    }
}
