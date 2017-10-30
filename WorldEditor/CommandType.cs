using System;
using System.Collections.Generic;
using System.Text;

namespace WorldEditor
{
    public enum CommandType
    {
        ShowMessage,
        PauseGameLogic,
        ResumeGameLogic,
        PlayMidi,
        StopMidi,
        PlayWav,
        LoadLevel,
        CreateGameUnit,
        RemoveGameUnit,
        KillGameUnit,
        SetPlayerInputOn,
        SetPlayerInputOff,
        SetVariable,
        VariableSelfPlus,
        VariableSelfSubtract,
        ShowVisualLayer,
        HideVisualLayer,
        PlayRoleAnimation,
        Wait,
        FixCamera,
        MoveCameraPosition,
        SetCameraPosition,
        EnableBackgroundColor,
        DisableBackgroundColor,
        SetBackgroundColor,
        SetGameUnitLayerNumber,
        SetPlayerPosition,
        SavePlayerStatus,
        RecoverPlayerStatus,
        CurtainRise,
        CurtainDrop,
        SetTriggerSwitch,
        LoadResource,
        CalculateScore,
        ShowCredit,
        Shake,
        Charge
    }
}
