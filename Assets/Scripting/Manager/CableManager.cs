
using UnityEngine;

public class CableManager : MonoBehaviour
{

    public static CableManager Instance { get; private set; }

    [SerializeField] private bool isClicked = false;
    [SerializeField] public bool isDragging = false;

    [SerializeField] private AbstractPhysicalLink selectedPhysicalLink;
    [SerializeField] private Cable ghostCable;

    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        
        Instance = this;
    }

    void Update()
    {
        if (LinkMoveController.Instance.IsDragging)
            return;

        DetectClickInPhysicalLinkOnScreen();
        CheckIsCastingOtherLink();
        ManageGhostCable();
        CheckisDragging();
    }
        
    private void CheckIsCastingOtherLink()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isClicked = false;
            if (selectedPhysicalLink != null)
            {
                AbstractPhysicalLink otherPhysicalLink = Utility.FindPhysicalLinkOnScreen();

                /* verificar se não é o mesmo gameobject ou se o outro link já não está conectado */
                if (otherPhysicalLink == null || 
                    otherPhysicalLink.gameObject == selectedPhysicalLink.gameObject ||
                    otherPhysicalLink.Other != null)
                    return;

                /* build a real cable */
                Cable connectionCable = CreateCable();

                connectionCable.StartLocation = selectedPhysicalLink.transform;
                connectionCable.EndLocation = otherPhysicalLink.transform;

                selectedPhysicalLink.Connect(otherPhysicalLink, connectionCable);
                otherPhysicalLink.Connect(selectedPhysicalLink, connectionCable);

                /* desenhar cabo */
                connectionCable.Show();
            }
        }
    }

    /* gerenciar cabo temporario */
    private void ManageGhostCable()
    {
        if (isDragging)
        {
            if (selectedPhysicalLink != null)
            {
                if (ghostCable == null && selectedPhysicalLink.Other == null)
                {
                    ghostCable = CreateCable();
                    ghostCable.StartLocation = selectedPhysicalLink.transform;
                }
                else if (ghostCable != null)
                {
                    Vector3 worldPosition = Utility.GetMouseWorldPosition();
                    ghostCable.EndLocation.position = worldPosition;
                    ghostCable.Show();
                }
            }
        }
        else
        {
            if (ghostCable != null)
            {
                Destroy(ghostCable.gameObject);
            }
            
        }
    }
    
    /* detectar se o usuário está tentando criar uma conexão em um PhysicalLink */
    private void DetectClickInPhysicalLinkOnScreen()
    {
        if (!isDragging)
        {
            selectedPhysicalLink = null;
        }
        if (Input.GetMouseButtonDown(0))
        {
            /* achou um link na tela */
            AbstractPhysicalLink detectedPhysicalLink = Utility.FindPhysicalLinkOnScreen();

            if (detectedPhysicalLink == null)
                return;

            selectedPhysicalLink = detectedPhysicalLink;
            isClicked = true;
            
            /* remover link */
            if (Input.GetKey(KeyCode.LeftAlt) && selectedPhysicalLink.Other != null)
                ClearLinkConnection(ref detectedPhysicalLink);
        }
    }

    private void ClearLinkConnection(ref AbstractPhysicalLink physicalLink)
    {
        physicalLink.ConnectedCable.Disconnect();
        AbstractPhysicalLink otherPhysicalLink = physicalLink.Other;
        physicalLink.Disconnect();
        otherPhysicalLink.Disconnect();
    }

    private Cable CreateCable()
    {
        GameObject cablePrefab = PrefabManager.GetPrefabOf(PrefabType.CABLE);
        return Instantiate(cablePrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<Cable>();
    }

    private void CheckisDragging()
    {
        isDragging = isClicked && Input.GetMouseButton(0);
    }
}
