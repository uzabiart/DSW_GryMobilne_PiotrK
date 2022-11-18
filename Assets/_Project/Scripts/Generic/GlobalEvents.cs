using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GlobalEvents
{
    public static Action OnSpacebarHit;
    public static Action OnEnable;

    public static Action OnGameplayStateChange;
}

public class GameplayEvents
{
    public static Action<Vector2> PlayerInput;
    public static Action<ItemData> OnItemPickup;

    public static Action OnSaveGame;
    public static Action OnLoadGame;
}

public class UIEvents
{
    public static Action<PopupInfo> OnShowMessage;
    public static Action OpenInventory;

    public static Action OnUIRefresh;
    public static Action OnDebugButtonClick;
}

public class OnlineEvents
{
    public static Action OnServerInit;
    public static Action OnUserLogIn;
}