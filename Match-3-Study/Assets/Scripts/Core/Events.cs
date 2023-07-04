using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Events
{
    public static class CoreEvents
    {
        public static Action OnGameStarted;
        public static Action OnGameEnded;
    }

    public static class GameEvents
    {
        public static Action OnMatchFound;
        public static Action OnPlayerInput;
    }
}
