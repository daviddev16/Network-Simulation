using UnityEngine;

/* todo dispositivo no sistema */
public abstract class AbstractHardware : MonoBehaviour
{
    public static readonly long INVALID_ID = -1024;

    private string m_Name;

    public string Name 
    { 
        get => m_Name; 
        set
        {
            if (!m_Name.Equals(value))
            {
                m_Name = value;
                gameObject.name = Name + "  [GameDevice]";
            }
        } 
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
    public abstract void Initialize();
}
