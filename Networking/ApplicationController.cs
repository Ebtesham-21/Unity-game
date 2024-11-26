using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ApplicationController : MonoBehaviour
{
    [SerializeField] private ClientSingleton clientPrefab;
    private async void Start()
    {
        DontDestroyOnLoad(gameObject);
      await LaunchInMode (SystemInfo.graphicsDeviceType == UnityEngine.Rendering.GraphicsDeviceType.Null)
    }

    private async Task LaunchInMode(bool isDedicatedServer)
    {
        if(isDedicatedServer)
        {

        }
        else 
        {
          ClientSingleton clientSingleton =   Instantiate(clientPrefab);

          await clientSingleton.CreateClient();

          //Go to main menu
        }
    }
   
}