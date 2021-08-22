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

    void Awake()
    {
        Social.LoadAchievementDescriptions(achDescr => {
            if(achDescr.Length > 0)
            {
                index = 0;
                foreach (IAchievementDescription ach in achDescr)
                {
                    achievementsList.transform.GetChild(index).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = ach.title;
                    achievementsList.transform.GetChild(index).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = ach.unachievedDescription;
                    index++;
                }
            }
            else
            {
                achievementsList.transform.GetChild(0).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "Achiev not found";
            }
        });

        Social.LoadAchievements(achievements => {            
            if (achievements.Length > 0)
            {
                index = 0;
                foreach (IAchievement achievement in achievements)
                {
                    // achievementsList.transform.GetChild(index).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = achievement.
                    // achievementsList.transform.GetChild(index).GetComponent<Image>().color.sizeDelta = new Vector2((achievementsList.GetComponent<RectTransform>().sizeDelta.x / 100f * (float)achievement.percentCompleted), tmpColor.sizeDelta.y);
                    if (achievement.completed)
                    {
                        achievementsList.transform.GetChild(index).GetComponent<Image>().color = new Color(0.182f, 0.594f, 0.188f);
                    }
                    else
                    {
                        achievementsList.transform.GetChild(index).GetComponent<Image>().color = new Color(0.792f, 0.313f, 0.250f);
                    }
                    index++;
                }
            }
            else
            {
                var asd = achievementsList.transform.GetChild(0).GetComponent<Image>().color;
                asd.a = 0.35f;
                achievementsList.transform.GetChild(0).GetComponent<Image>().color = asd;
            }
        });
    }
}