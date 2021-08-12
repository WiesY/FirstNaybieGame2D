using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using TMPro;

public class AchievementSceneScript : MonoBehaviour
{
    [SerializeField] private GameObject achievementsList;

    private int index = 0;

    void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) => { });

        Social.LoadAchievements(achievements => {
            achievementsList.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = achievements.Length.ToString();
            if (achievements.Length > 0)
            {
                foreach (IAchievement achievement in achievements)
                {
                    var tmpColor = achievementsList.transform.GetChild(index).GetComponent<Image>().color;
                    //tmpColor.sizeDelta = new Vector2((achievementsList.GetComponent<RectTransform>().sizeDelta.x / 100f * (float)achievement.percentCompleted), tmpColor.sizeDelta.y);
                    if (achievement.completed)
                    {
                        tmpColor = new Color(46, 152, 48);
                    }
                    else
                    {
                        tmpColor = new Color(202, 80, 64);
                    }
                    index++;
                }
            }
            else
            {
                var asd = achievementsList.transform.GetChild(0).GetComponent<Image>().color;
                asd.a = 0.35f;
                achievementsList.transform.GetChild(0).GetComponent<Image>().color = asd;
                Debug.Log("No achievements returned");
            }
        });        
    }
}