using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ConnectionButtons : MonoBehaviour
{
    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
    }
    // Start is called before the first frame update
    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
    }
}
