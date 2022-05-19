using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Zikkurat
{
    [Serializable]
     public struct SteeringBehaviourData
    {

    }

    [Flags]
    public enum IgnoreAxisType : byte
    {
        None = 0,
        X =1,
        Y=2,
        Z=4
    }

    public enum AIStateType : byte
    {
        None=0,
        Wait=1,Move_Seek=230,
        Move_Flee=231,
        Move_Arrival=232,
        Move_Wander=233,
        Move_Pursuing=234,
        Move_Evading = 235,
    }
}