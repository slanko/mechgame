using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    [SerializeField] float leftThrottle, rightThrottle, leftClampMax, rightClampMax, leftClampMin, rightClampMin, throttleSensitivity, turnSpeedModifier, moveSpeedModifier;
    [SerializeField] Slider leftSlider, rightSlider;
    [SerializeField] Transform upperTorso;

    // Update is called once per frame
    void Update()
    {
        var RThrottle = Input.GetAxis("Right Throttle");
        var LThrottle = Input.GetAxis("Left Throttle");

        if (LThrottle != 0) leftThrottle += LThrottle * Time.deltaTime * throttleSensitivity;

        if (RThrottle != 0) rightThrottle += RThrottle * Time.deltaTime * throttleSensitivity;

        leftThrottle = Mathf.Clamp(leftThrottle, leftClampMin, leftClampMax);

        rightThrottle = Mathf.Clamp(rightThrottle, rightClampMin, rightClampMax);

        leftSlider.value = leftThrottle;
        rightSlider.value = rightThrottle;

        transform.Rotate(0, (leftThrottle - rightThrottle) * Time.deltaTime * turnSpeedModifier , 0);
        transform.Translate(0, 0, (leftThrottle + rightThrottle) * Time.deltaTime * moveSpeedModifier);

    }
}
