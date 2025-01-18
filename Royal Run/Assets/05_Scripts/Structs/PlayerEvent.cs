using System;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerEvent
{
    public Action<Vector3> OnPlayerMove;
    public Action<Chunk> OnChunkDestroyed;
}
