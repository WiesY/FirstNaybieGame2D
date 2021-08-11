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
        Social.localUser.Authenticate((bool success) => {

        });
    }

    public void SetAchievements(string idAchiev)
    {
        Social.ReportProgress(idAchiev, 100, (bool success) => { });
    }
}