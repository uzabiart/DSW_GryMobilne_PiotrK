using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseLoginEmailPassword : MonoBehaviour
{
    public string email;
    public string password;

    string displayName;
    string emailAddress;

    Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    public static Firebase.Auth.FirebaseUser user;

    public void Register()
    {
        if (FirebaseInit.app == null) return;
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            GameData.UserData.userId = newUser.UserId;
            OnUserUpdated();
        });
    }

    public void Login()
    {
        if (FirebaseInit.app == null) return;
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);

            GameData.UserData.userId = newUser.UserId;
            OnUserUpdated();
        });
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserId);
                displayName = user.DisplayName ?? "";
                emailAddress = user.Email ?? "";

                GameData.UserData.userId = user.UserId;
                OnUserUpdated();
            }
        }
    }


    public void OnUserUpdated()
    {
        OnlineEvents.OnUserLogIn?.Invoke();
    }
}
