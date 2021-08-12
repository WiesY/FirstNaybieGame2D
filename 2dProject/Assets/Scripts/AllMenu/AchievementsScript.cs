using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class AchievementsScript : MonoBehaviour
{
    private void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) => { });
    }

    public void SetAchievements()
    {
        Social.ShowAchievementsUI();
    }

    public void ExitFromGPS()
    {
        PlayGamesPlatform.Instance.SignOut();
    }
}