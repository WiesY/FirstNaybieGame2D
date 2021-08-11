using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class AchievementSceneScript : MonoBehaviour
{
    [SerializeField] private GameObject achievementsList;

    private int index;

    void Start()
    {
        Social.LoadAchievements(achievements => {
            if (achievements.Length > 0)
            {
                int index = 0;
                foreach (IAchievement achievement in achievements)
                {
                    var tmpColor = achievementsList.transform.GetChild(index).GetChild(0).GetComponent<Image>().color;
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
                Debug.Log("No achievements returned");
            }
        });
    }
}
