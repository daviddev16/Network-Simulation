

public class DatagramPacket
{
    private string data;

    public string Data
    { 
        get => data;
        set => data = value;
    }

    public DatagramPacket(string data)
    {
        Data = data;
    }
}
