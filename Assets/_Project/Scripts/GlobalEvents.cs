using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GlobalEvents
{
    public static Action OnEnable;
}

public class GameplayEvents
{
    public static Action<Vector2> PlayerInput;
    public static Action<ItemData> OnItemPickup;
}

public class UIEvents
{
    public static Action<PopupInfo> OnShowMessage;
    public static Action OpenInventory;
}