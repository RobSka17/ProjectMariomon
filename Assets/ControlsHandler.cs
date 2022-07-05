using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlsHandler
{
    private InputActionMap inputActions;

    public InputAction PrimaryButtonAction { get; }
    public InputAction SecondaryButtonAction { get; }

    public InputAction LeftOnceAction { get; }

    private enum ControlPreset
    {
        SwitchPro,
        XboxPlaystation
    }

    public ControlsHandler(InputActionAsset inputConfig)
    {
        ControlPreset controlPreset = ControlPreset.SwitchPro;
        inputActions = inputConfig.FindActionMap(controlPreset.ToString());
        PrimaryButtonAction = inputActions["PrimaryButton"];
        PrimaryButtonAction.Enable();
        SecondaryButtonAction = inputActions["SecondaryButton"];
        SecondaryButtonAction.Enable();
        LeftOnceAction = inputActions["LeftOnce"];
        LeftOnceAction.Enable();
    }
}
