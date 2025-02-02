using System.Collections;
using System.Collections.Generic;
using Farou.Utility;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Pool;

public class GameObjectPool : Singleton<GameObjectPool>
{
    [System.Serializable]
    public class PickUpReference
    {
        [Searchable] public PickUpType Type;
        public GameObject GameObject;
        [HideInInspector] public Transform ParentTransform;
        [HideInInspector] public ObjectPool<GameObject> ObjectPool;
    }

    [System.Serializable]
    public class ChunkReference
    {
        [Searchable] public ChunkType Type;
        public GameObject GameObject;
        [HideInInspector] public Transform ParentTransform;
        [HideInInspector] public ObjectPool<GameObject> ObjectPool;
    }

    [System.Serializable]
    public class ObstacleReference
    {
        [Searchable] public ObstacleType Type;
        public GameObject GameObject;
        [HideInInspector] public Transform ParentTransform;
        [HideInInspector] public ObjectPool<GameObject> ObjectPool;
    }

    [TableList(ShowIndexLabels = true)] public List<PickUpReference> PickUpReferences = new List<PickUpReference>();
    [TableList(ShowIndexLabels = true)] public List<ChunkReference> ChunkReferences = new List<ChunkReference>();
    [TableList(ShowIndexLabels = true)] public List<ObstacleReference> ObstacleReferences = new List<ObstacleReference>();

    private void Start()
    {
        foreach (var item in PickUpReferences)
        {
            item.ObjectPool = new ObjectPool<GameObject>(() =>
            {
                if (item.ParentTransform == null)
                {
                    item.ParentTransform = Instantiate(new GameObject(), transform).transform;
                    item.ParentTransform.name = item.Type.ToString();
                }
                return Instantiate(item.GameObject, item.ParentTransform);
            }, obj =>
            {
                obj.gameObject.SetActive(true);
                // obj.ResetState();
            }, obj =>
            {
                obj.gameObject.SetActive(false);
            }, obj =>
            {
                Destroy(obj.gameObject);
            }, false, 10, 20);
        }

        foreach (var item in ChunkReferences)
        {
            item.ObjectPool = new ObjectPool<GameObject>(() =>
            {
                if (item.ParentTransform == null)
                {
                    item.ParentTransform = Instantiate(new GameObject(), transform).transform;
                    item.ParentTransform.name = item.Type.ToString();
                }
                return Instantiate(item.GameObject, item.ParentTransform);
            }, obj =>
            {
                obj.gameObject.SetActive(true);
                // obj.ResetState();
            }, obj =>
            {
                obj.gameObject.SetActive(false);
            }, obj =>
            {
                Destroy(obj.gameObject);
            }, false, 10, 20);
        }

        foreach (var item in ObstacleReferences)
        {
            item.ObjectPool = new ObjectPool<GameObject>(() =>
            {
                if (item.ParentTransform == null)
                {
                    item.ParentTransform = Instantiate(new GameObject(), transform).transform;
                    item.ParentTransform.name = item.Type.ToString();
                }
                return Instantiate(item.GameObject, item.ParentTransform);
            }, obj =>
            {
                obj.gameObject.SetActive(true);
                // obj.ResetState();
            }, obj =>
            {
                obj.gameObject.SetActive(false);
            }, obj =>
            {
                Destroy(obj.gameObject);
            }, false, 10, 20);
        }
    }

    public GameObject GetPooledObject(PickUpType type)
    {
        return PickUpReferences.Find(i => i.Type == type).ObjectPool.Get();
    }

    public void ReturnToPool(PickUpType type, GameObject gameObject)
    {
        PickUpReferences.Find(i => i.Type == type).ObjectPool.Release(gameObject);
    }

    public GameObject GetPooledObject(ChunkType type)
    {
        return ChunkReferences.Find(i => i.Type == type).ObjectPool.Get();
    }

    public void ReturnToPool(ChunkType type, GameObject gameObject)
    {
        ChunkReferences.Find(i => i.Type == type).ObjectPool.Release(gameObject);
    }

    public GameObject GetPooledObject(ObstacleType type)
    {
        return ObstacleReferences.Find(i => i.Type == type).ObjectPool.Get();
    }

    public void ReturnToPool(ObstacleType type, GameObject gameObject)
    {
        ObstacleReferences.Find(i => i.Type == type).ObjectPool.Release(gameObject);
    }
}

[System.Serializable]
public enum PickUpType
{
    HealthKit,
    Money
}

[System.Serializable]
public enum ChunkType
{
    Chunk_1,
    Chunk_2,
    Chunk_3,
    Chunk_4,
    Chunk_5,
    Chunk_6,
    Chunk_7
}

[System.Serializable]
public enum ObstacleType
{
    Barrel,
    Bench,
    Cannon,
    BrokenCar,
    Cart,
    Crate,
    Piano,
}


