using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputController_Singleton", menuName = "Singletons/New InputController", order = 150)]
public class InputController : SingletonSettings<InputController>
{
    [Header("input movement key")]
    public KeyCode key_up = KeyCode.Z;
    public KeyCode key_down = KeyCode.S;
    public KeyCode key_left = KeyCode.Q;
    public KeyCode key_right = KeyCode.D;

    public int GetAxisHorizontal()
    {
        if(Input.GetKey(key_right) && !Input.GetKey(key_left))
        {
            return 1;
        }
        else if (!Input.GetKey(key_right) && Input.GetKey(key_left))
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    public int GetAxisVertical()
    {
        if (Input.GetKey(key_up) && !Input.GetKey(key_down))
        {
            return 1;
        }
        else if (!Input.GetKey(key_up) && Input.GetKey(key_down))
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}