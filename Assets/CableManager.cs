
using System;
using UnityEngine;

public class CableManager : MonoBehaviour
{
    private Edit2Controller controller;

    [SerializeField] private AbstractPhysicalLink selectedPhysicalLink;
    [SerializeField] private Cable ghostCable;
    
    [SerializeField] private bool IsClicked;
    [SerializeField] public bool IsDragging = false;

    void Start()
    {
        controller = FindObjectOfType<Edit2Controller>();
    }

    void Update()
    {
        /*if (controller.IsDragging)
        {
            return;
        }*/
        DetectClickInPhysicalLinkOnScreen();
        CheckIsCastingOtherLink();
        ManageGhostCable();
        CheckIsDragging();
    }

    private void CheckIsCastingOtherLink()
    {
        if (Input.GetMouseButtonUp(0))
        {
            IsClicked = false;
            if (selectedPhysicalLink != null)
            {
                AbstractPhysicalLink otherPhysicalLink = FindPhysicalLinkOnScreen();

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
        if (IsDragging)
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
                    Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    pos.z = 0;
                    ghostCable.EndLocation.position = pos;
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
        if (!IsDragging)
        {
            selectedPhysicalLink = null;
        }
        if (Input.GetMouseButtonDown(0))
        {
            /* achou um link na tela */
            AbstractPhysicalLink detectedPhysicalLink = FindPhysicalLinkOnScreen();

            if (detectedPhysicalLink == null)
                return;

            selectedPhysicalLink = detectedPhysicalLink;
            IsClicked = true;
            
            /* remover link */
            if (Input.GetKey(KeyCode.LeftAlt) && selectedPhysicalLink.Other != null)
                ClearLinkConnection(ref detectedPhysicalLink);
        }
    }

    private AbstractPhysicalLink FindPhysicalLinkOnScreen()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray, 10f);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.TryGetComponent<AbstractPhysicalLink>(out var physicalLink))
            {
                return physicalLink;
            }
        }
        return null;
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

    private void CheckIsDragging()
    {
        IsDragging = IsClicked && Input.GetMouseButton(0);
    }
}
