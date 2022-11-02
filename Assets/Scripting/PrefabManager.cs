


using UnityEngine;

public class PrefabManager : MonoBehaviour
{

    public static PrefabManager Instance 
    { 
        get; 
        private set; 
    }

    [SerializeField] private GameObject cablePrefab;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Já existe uma instancia desse object.");
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    public static GameObject GetPrefabOf(PrefabType prefabType)
    {
        switch (prefabType)
        {
            case PrefabType.CABLE: 
                return Instance.cablePrefab;
        }
        return null;
    }

}
