using System.Text;
using System;
using UnityEngine;

public static class Utility
{

    //  public static readonly char[] HEX = { '0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F' };

    public static AbstractPhysicalLink FindPhysicalLinkOnScreen()
    {
        return (AbstractPhysicalLink) FindTypeOnScreen(typeof(AbstractPhysicalLink));
    }

    public static AbstractNetworkDevice FindNetworkDeviceOnScreen()
    {
        return (AbstractNetworkDevice)FindTypeOnScreen(typeof(AbstractNetworkDevice));
    }

    public static object FindTypeOnScreen(Type type)
    {
        Ray ray = GetMouseRay();
        RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray, 10f);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.TryGetComponent(type, out var component))
            {
                return component;
            }
        }
        return null;
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 worldPosition = CameraController.Camera.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0f; /* previne problemas com distancias */
        return worldPosition;
    }

    public static float Clamp(float value, float min, float max)
    {
        if (value > max)
        {
            return max;
        }
        else if (value < min)
        {
            return min;
        }

        return value;
    }

    public static Ray GetMouseRay()
    {
        return CameraController.Camera.ScreenPointToRay(Input.mousePosition);
    }

}
