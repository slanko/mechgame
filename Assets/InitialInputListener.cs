using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class InitialInputListener : MonoBehaviour
{
    bool primed = true;
    int inputDevicesBound = 0;
    Mouse alphaInput;
    Mouse betaInput;

    public playerScript _playerScript;

    [SerializeField] float LeftThrottle, RightThrottle;

    [SerializeField] Vector2 camInputs;


    private void Update()
    {
        for(int i = 0; i < gameObject.GetComponent<PlayerInput>().devices.Count; i++)
        {
            print(gameObject.GetComponent<PlayerInput>().devices[i]);
        }
    }


    public void RThrottle(CallbackContext context)
    {
        _playerScript.RThrottle = context.ReadValue<Vector2>().y;
        RightThrottle = context.ReadValue<Vector2>().y;
    }
    public void LThrottle(CallbackContext context)
    {
        _playerScript.LThrottle = context.ReadValue<Vector2>().y;
        LeftThrottle = context.ReadValue<Vector2>().y;
    }
    
    public void Brakes(CallbackContext context)
    {
        if (context.started && primed)
        {
            primed = false;
            _playerScript.Brakes = true;
        }
        if (context.canceled)
        {
            primed = true;
            _playerScript.Brakes = false;
        }
    }

    public void CamControl(CallbackContext context)
    {
        var inputs = context.ReadValue<Vector2>();
        if (inputs.x < 0)
        {
            inputs.x = -1;
        }
        else if (inputs.x > 0)
        {
            inputs.x = 1;
        }
        if (inputs.y < 0)
        {
            inputs.y = -1;
        }
        else if (inputs.y > 0)
        {
            inputs.y = 1;
        }


        camInputs = inputs;
    }
}
