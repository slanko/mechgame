using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class InitialInputListener : MonoBehaviour
{
    bool primed = true;
    int inputDevicesBound = 0;

    public playerScript _playerScript;

    [SerializeField] float LeftThrottle, RightThrottle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    //This is what the input system gets (is plugged manually into a component on player)
    //context is the state of the button|| .started = float != 0 || .cancelled = float < currentFloatValue
    void OnMousePress(CallbackContext context)
    {
        //primed required to stop multiple inputs firing
        if (context.started && primed)
        {
            primed = false;

            switch (inputDevicesBound)
            {
                case 0:
                    //Bind my first mouse

                    break;
                case 1:
                    //Bind my second mouse
                    break;
            }
        }
        if (context.canceled)
        {
            primed = true;
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
}
