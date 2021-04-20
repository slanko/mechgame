using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollowScript : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    [SerializeField] float lerpSpeed, rotateLerpSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, followTarget.position, lerpSpeed * Time.deltaTime);
        //get quaternion Y and put it in a vector 3 so i can plug it back in as a euler angle taking only the Y
        Vector3 rotationYOnlyAsVector3ForEulerAngles = new Vector3(0, followTarget.rotation.eulerAngles.y, 0);
        //chuck those messed with euler angles back into a quaternion
        Quaternion rotationYOnlyAsQuaternion = new Quaternion();
        rotationYOnlyAsQuaternion.eulerAngles = rotationYOnlyAsVector3ForEulerAngles;
        //SLERP IT
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationYOnlyAsQuaternion, rotateLerpSpeed * Time.deltaTime);
    }
}
