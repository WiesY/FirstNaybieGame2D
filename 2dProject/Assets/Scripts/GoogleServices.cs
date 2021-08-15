using System;
using System.Collections;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using UnityEngine.SocialPlatforms;
using System.Text;
using UnityEngine.UI;

public class GoogleServices : MonoBehaviour
{
    public static Text text;

    private static DateTime startTime;

    public static bool isSaving; // Сохранить или записать файл
    public static bool tryToAuthenticate = false;

    public static string testString = "Hi!";    // Test field
    private static int testInt = 15;            // Test field
    private static bool testBool = true;        // Test field

    private static string[] arrOfStrings;       // Test field
    private static bool[] arrOfBools;           // Test field

    public static int money = 0;

    public static void AuthenticateAtStartApp()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        .EnableSavedGames()
        .Build();

        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) => {
            if (result == SignInStatus.Success)
            {
                text.text = "Удачная аутентификация";
                startTime = DateTime.Now;
            }
            else
            {

            }
        });
    }

    public static void OpenSavedGame(bool saving, string nameFileToOpen) // Сохранение / Загрузка данных ||| true - сохранение, false - загрузка
    {
        isSaving = saving;
        text.text = "Открытие файла...";
        OpenSavedGame(nameFileToOpen);
    }

    private static void OpenSavedGame(string filename)
    {
        ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
        savedGameClient.OpenWithAutomaticConflictResolution(filename, DataSource.ReadCacheOrNetwork,
            ConflictResolutionStrategy.UseLongestPlaytime, OnSavedGameOpened);
    }

    private static void OnSavedGameOpened(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            if (isSaving)
            {

                //if (game.Filename == "MoneyAndSelectedSkin")
                //{
                //    data = InfoAboutApplication.money + ";" + InfoAboutApplication.selectedSkin;
                //}
                //else if (game.Filename == "PurchasedSkins")
                //{
                //    data = InfoAboutApplication.purchasedSkins;
                //}
                //else if (game.Filename == "OpenIslands")
                //{

                //}
                //else if (game.Filename == "OpenLevels")
                //{

                //}
                // string data = testString + ";" + testInt + ";" + testBool;

                InfoAboutApplication infoAboutApplication = new InfoAboutApplication();
                string data = JsonUtility.ToJson(infoAboutApplication);

                byte[] saveData = Encoding.UTF8.GetBytes(data);
                SaveGame(game, saveData);
            }
            else if(!isSaving)
            {
                LoadGameData(game);
            }
        }
        else
        {
            text.text = "Файл не открылся";
        }
    }

    private static void SaveGame(ISavedGameMetadata game, byte[] savedData)
    {
        TimeSpan currentSpan = DateTime.Now - startTime;
        TimeSpan totalPlaytime = game.TotalTimePlayed + currentSpan;

        ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;

        SavedGameMetadataUpdate.Builder builder = new SavedGameMetadataUpdate.Builder();
        builder = builder
            .WithUpdatedPlayedTime(totalPlaytime)
            .WithUpdatedDescription("Saved game at " + DateTime.Now);
        SavedGameMetadataUpdate updatedMetadata = builder.Build();
        savedGameClient.CommitUpdate(game, updatedMetadata, savedData, OnSavedGameWritten);
    }

    private static void OnSavedGameWritten(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            text.text = "Успешно сохранил";
            Debug.Log("Успешно сохранил!");
        }
        else
        {
            text.text = "Неудачное сохранение";
        }
    }

    private static void LoadGameData(ISavedGameMetadata game)
    {
        ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
        savedGameClient.ReadBinaryData(game, OnSavedGameDataRead);
    }

    private static void OnSavedGameDataRead(SavedGameRequestStatus status, byte[] data)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            if (data.Length > 0)
            {
                string dataGoogle = Encoding.ASCII.GetString(data);
                InfoAboutApplication dataJson = JsonUtility.FromJson<InfoAboutApplication>(dataGoogle);

                Debug.Log(dataJson);

                // string[] s = dataGoogle.Split(';');

                // text.text = s[0] + " " + s[1] + " " + s[2];

                Debug.Log("Успешно загрузил: " + dataJson);
            }
            else
            {
                text.text = "Данных нет, не удалось считать";

                Debug.Log("Нет данных");
            }
        }
        else
        {
            text.text = "Ошибка при считавании данных";
        }
    }
}