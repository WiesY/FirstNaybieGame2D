using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadCompleteLevelsScripts : MonoBehaviour
{
    [SerializeField] private int indexIsland;

    private bool[] openLevels; // Массив пройденных уровней(пройден/не пройден - true/false)

    private void Awake()
    {
        openLevels = new bool[8];

        for (int i = indexIsland * 8; i <= indexIsland * 8 + 7; i++)
        {
            openLevels[i] = InfoAboutApplication.OpenLevels[i];
        }

        //if (PlayerPrefs.HasKey(nameIsland))
        //{
        //    isCompleteLevels = PlayerPrefsX.GetBoolArray(nameIsland);
        //}
        //else
        //{
        //    isCompleteLevels[0] = true;
        //    PlayerPrefsX.SetBoolArray(nameIsland, isCompleteLevels);
        //}

        var allLevels = transform.Find("All Levels").gameObject;
        for (int i = 0; i < allLevels.transform.childCount; i++) // Замок на уровни
        {
            if (openLevels[i])
            {
                allLevels.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
                allLevels.transform.GetChild(i).GetComponent<Button>().interactable = true;
            }
            else
            {
                allLevels.transform.GetChild(i).GetChild(1).gameObject.SetActive(true);
                allLevels.transform.GetChild(i).GetComponent<Button>().interactable = false;
            }
        }
    }
}