using System;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerEvent
{
    public Action<Chunk> OnChunkDestroyed;
}
