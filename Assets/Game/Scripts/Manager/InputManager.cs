using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private void Update()
    {
        int verticalId = -1;
        if (Input.GetKeyDown(KeyCode.Alpha1)) verticalId = 1;
        if (Input.GetKeyDown(KeyCode.Alpha2)) verticalId = 2;
        if (Input.GetKeyDown(KeyCode.Alpha3)) verticalId = 3;
        if (Input.GetKeyDown(KeyCode.Alpha4)) verticalId = 4;
        if (Input.GetKeyDown(KeyCode.Alpha5)) verticalId = 5;
        if(verticalId != -1) ObserverManager.Notify(EventId.PlayerSheepPosition,(int)(verticalId - 1));
    }
}
