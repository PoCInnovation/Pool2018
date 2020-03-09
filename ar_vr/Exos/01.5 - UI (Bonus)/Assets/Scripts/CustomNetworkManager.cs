using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager {

    [Header("Network UI")]
    public InputField ip;
    public InputField port;
    public Text myPort;

    private void Start()
    {
        SetMyPort(Random.Range(1111, 9999));
        StartHost();
    }

    private void SetMyPort(int port)
    {
        networkPort = port;
        myPort.text = "Your port:" + System.Environment.NewLine + port.ToString();
    }

    public void Connect()
    {
        StopHost();
        StopClient();
        SetMyPort(System.Convert.ToInt32(port.text));
        networkAddress = ip.text;
        StartClient();
    }
}
