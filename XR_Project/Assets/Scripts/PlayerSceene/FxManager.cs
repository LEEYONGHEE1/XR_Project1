using System.Collections;
using System.Collections.Generic;
using System.Linq;      //Linq ¼³Á¤
using UnityEngine;

public enum FxType
{ 
    hit,
    Explosion
}

[System.Serializable]
public class FxBunbdle
{
    [SerializeField] private FxType fxType;
    [SerializeField] private GameObject fxPrefab;
    public FxType FxType => fxType;
    public GameObject FxPrefab => fxPrefab;
}

public class FxManager : MonoBehaviour
{
    public FxManager() { }
    public static FxManager Instance { get; private set; }

    [SerializeField] private List<FxBunbdle> fxList;

    public Dictionary<FxType, GameObject> FXDict { get; private set; } = new Dictionary<FxType, GameObject>();
    public List<FxBunbdle> FxList => fxList;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            transform.parent = null;
            Instance = this;
            DontDestroyOnLoad(gameObject);
            for(int i=0; i < FxType.GetValues(typeof(FxType)).Length; i++ )
            {
                FXDict.Add((FxType)i, FxList.FirstOrDefault(x => x.FxType == (FxType)i)?.FxPrefab);
            }
        }
    }

    public void PlayFx(Transform targetTransform, FxType targetFx, Vector3 Offset) 
    {
        Instantiate(FXDict[targetFx], targetTransform.position + Offset, new Quaternion(0.0f, 0.0f, 0.0f, 1.0f));
    }
}
