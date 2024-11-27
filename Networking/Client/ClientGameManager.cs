using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using System.Threading.Tasks;
using Unity.Netcode;
using Unity.Services.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClientGameManager 
{
    private const string MenuSceneName = "Menu";
    // Start is called before the first frame update
   public async Task<bool> InitAsync()
   {
    await UnityServices.InitializeAsync();
    AuthState authState = await AuthenticationWrapper.DoAuth();

    if(authState == AuthState.Authenticated)
    {
        return true;
    } 

    return false;
    
   }

   public void GoToMenu()
   {
   SceneManager.LoadScene(MenuSceneName); 
   }
}
