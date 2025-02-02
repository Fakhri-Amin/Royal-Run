using System;
using System.Collections.Generic;
using Farou.Utility;
using UnityEngine;

public class GameDataManager : PersistentSingleton<GameDataManager>
{
    private GameData gameData;

    public new void Awake()
    {
        base.Awake();

        gameData = Data.Get<GameData>();
    }

    public void Save()
    {
        Data.Save();
    }

    public void ClearAllData()
    {
        PlayerPrefs.DeleteAll();
        Save();
    }
}
