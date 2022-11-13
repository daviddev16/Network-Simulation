using System.Text;
using System;
using UnityEngine;

public static class Utility
{

    //  public static readonly char[] HEX = { '0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F' };

    /* for inet4address */
    public static string GetNetworkID(string inetAddress, string subnetMask)
    {

        if (!ValidInet4Address(inetAddress) || !ValidInet4Address(subnetMask))
            return null;

        byte[] inetAddressOctets = ToOctets(inetAddress);
        byte[] subnetMaskOctets = ToOctets(subnetMask);
        byte[] networkIdOctets = new byte[inetAddressOctets.Length];

        for (int i = 0; i < networkIdOctets.Length; i++)
        {
            networkIdOctets[i] = (byte)(inetAddressOctets[i] & subnetMaskOctets[i]);
        }
        return ToInet4Address(networkIdOctets);
    }

    public static bool ValidInet4Address(string inetAddress)
    {
        return !string.IsNullOrEmpty(inetAddress) && ToOctets(inetAddress) != null;
    }

    public static string ToInet4Address(byte[] octets)
    {

        if(octets.Length != 4)
            return null;

        StringBuilder builder = new StringBuilder();
        foreach (byte octet in octets)
        {
            builder.Append(".").Append(octet.ToString());
        }

        return builder.ToString().Substring(1);
    }

    public static byte[] ToOctets(string inetAddress)
    {
        string[] octets = inetAddress.Trim().Split(".");

        if (octets.Length != 4)
            return null;

        byte[] octetValues = new byte[octets.Length];

        for (int i = 0; i < octetValues.Length; i++)
        {
            if (!byte.TryParse(octets[i], out byte value))
            {
                return null;
            }
            octetValues[i] = value;
        }

        return octetValues;
    }


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
