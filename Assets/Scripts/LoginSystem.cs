using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class LoginSystem : MonoBehaviour
{
    public 
    async void Start()
    {
        await InitializeAuth();
    }
    async Task InitializeAuth()
    {
        try
        {
            await UnityServices.InitializeAsync();
            Debug.Log("Unity Services Initialized");

            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                Debug.Log("Signed in as: " + AuthenticationService.Instance.PlayerId);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Authentication failed: " + e.Message);
        }
    }
    async Task SignUpWithEmail(string email, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(email, password);
            Debug.Log("User Registered: " + AuthenticationService.Instance.PlayerId);
        }
        catch (AuthenticationException e)
        {
            Debug.LogError("Sign-up Failed: " + e.Message);
        }
    }

    async Task SignInWithEmail(string email, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(email, password);
            Debug.Log("User Logged in: " + AuthenticationService.Instance.PlayerId);
        }
        catch (AuthenticationException e)
        {
            Debug.LogError("Login Failed: " + e.Message);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
