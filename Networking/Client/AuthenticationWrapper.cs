using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public static class AuthenticationWrapper
{
   public static AuthState AuthState {get; private set;} = AuthState.NotAuthenticated;
   public static async  Task<AuthState> DoAuth(int maxRetries = 5)
   {
        if(AuthState == AuthState.Authenticated)
        {
            return AuthState;
        }
        
        await SignInAnonymouslyAsync(maxRetries);

        return AuthState;

   }
  private static async Task SignInAnonymouslyAsync(int maxRetries)
  {
    AuthState = AuthState.Authenticating;
        int tries = 0;
        while(AuthState == AuthState.Authenticating && tries < maxRetries )
        {
            try 
            {
                 await AuthenticationService.Instance.SignInAnonymouslyAsync();
            if(AuthenticationService.Instance.IsSignedIn && AuthenticationService.Instance.IsAuthorized)
            {
                AuthState = AuthState.Authenticated;
                break;
            }


            }
            catch(AuthenticationException ex)
            {
                    Debug.LogError(ex);
                    AuthState = AuthState.Error;
            }
            catch(RequestFailedException exeption)
            {
                Debug.LogError(exeption);
                AuthState = AuthState.Error;
            }
           
            tries++;
            await Task.Delay(1000);

            
        }

}
}

public enum AuthState
{
    NotAuthenticated,
    Authenticating,
    Authenticated,
    Error,
    TimeOut

}
