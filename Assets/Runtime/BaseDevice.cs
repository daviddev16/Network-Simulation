using UnityEngine;

public abstract class BaseDevice : MonoBehaviour, Hardware
{

    public static readonly long INVALID_ID = -100;

    private string m_Name;

    public string Name 
    { 
        get => m_Name; 
        set => m_Name = value; 
    }

    private long id = INVALID_ID;
    
    public long Id 
    { 
        get => id; 
        set 
        {
            if (id != INVALID_ID)
                throw new System.Exception("Id cannot be set twice.");

            id = value;
        }
    }

    public virtual void Start()
    {
        Debug.Log("Loaded:BaseDevice");
    }

    public virtual void Update()
    {
        
    }

}
