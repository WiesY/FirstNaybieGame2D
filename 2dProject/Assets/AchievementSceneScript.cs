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
    [SerializeField] private Text checkErrorsText;

    private int index = 0;

    void Awake()
    {
        Social.LoadAchievementDescriptions(achDescr =>
        {
            if (achDescr.Length > 0)
            {
                index = 0;
                foreach (IAchievementDescription ach in achDescr)
                {
                    Sprite tempSprite = Sprite.Create(ach.image, new Rect(60, 3.3f, 100, 100), new Vector2(0.5f, 0.5f), 2);
                    achievementsList.transform.GetChild(index).GetChild(1).gameObject.GetComponent<Image>().sprite = tempSprite;
                    achievementsList.transform.GetChild(index).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = ach.title;
                    achievementsList.transform.GetChild(index).GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = ach.unachievedDescription;
                    checkErrorsText.text += $"Descr{index}";
                    index++;
                }
            }
            else
            {
                achievementsList.transform.GetChild(0).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "Achiev not found";
            }
        });

        checkErrorsText.text += $"DescrComp";

        Social.LoadAchievements(achievements =>
        {
            if (achievements.Length > 0)
            {
                index = 0;
                foreach (IAchievement achievement in achievements)
                {
                    achievementsList.transform.GetChild(index).GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(achievementsList.GetComponent<RectTransform>().rect.width / 100 * (float)achievement.percentCompleted, achievementsList.transform.GetChild(index).GetChild(0).GetComponent<RectTransform>().rect.height);
                    achievementsList.transform.GetChild(index).GetChild(0).GetComponent<RectTransform>().localPosition = new Vector3(achievementsList.transform.GetChild(index).GetChild(0).GetComponent<RectTransform>().rect.width / 2, 0, 0);
                    //if (achievement.completed)
                    //{
                    //    achievementsList.transform.GetChild(index).GetComponent<Image>().color = new Color(0.182f, 0.594f, 0.188f);
                    //}
                    //else
                    //{
                    //    achievementsList.transform.GetChild(index).GetComponent<Image>().color = new Color(0.792f, 0.313f, 0.250f);
                    //}
                    checkErrorsText.text += $"Ach{index}";
                    index++;
                }
            }
            else
            {
                var asd = achievementsList.transform.GetChild(1).GetComponent<Image>().color;
                asd.a = 0.35f;
                achievementsList.transform.GetChild(1).GetComponent<Image>().color = asd;
            }
        });

        checkErrorsText.text += $"AchComp";

        achievementsList.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(achievementsList.GetComponent<RectTransform>().rect.width / 100 * 50f, achievementsList.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().rect.height);
        achievementsList.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().localPosition = new Vector2(achievementsList.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().rect.width / 2, 0);

        checkErrorsText.text += $"AllComp";
    }
}