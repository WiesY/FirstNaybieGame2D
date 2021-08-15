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

            OpenSavedGame(false, "Money");

            //GoogleServices.OpenSavedGame(false, "Money");
            //GoogleServices.OpenSavedGame(false, "SkinsInfo");
            //GoogleServices.OpenSavedGame(false, "OpenIslands");
            //GoogleServices.OpenSavedGame(false, "OpenLevels");
        });
    }

    public static void OpenSavedGame(bool saving, string nameFileToOpen) // Сохранение / Загрузка данных ||| true - сохранение, false - загрузка
    {
        isSaving = saving;
        text.text = "Открытие файла...";
        OpenSavedGame("TestSaveAndLoadApp");
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

                text.text = "Попытка сохранить";

                InfoAboutApplication infoAboutApplication = new InfoAboutApplication();
                infoAboutApplication.money = 5;
                string data = JsonUtility.ToJson(infoAboutApplication);

                byte[] saveData = Encoding.UTF8.GetBytes(data);

                SaveGame(game, saveData);
            }
            else if(!isSaving)
            {
                text.text = "Попытка загрузить";
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
                InfoAboutApplication ifa = InfoAboutApplication.CreateFromJSON(dataGoogle); // JsonUtility.FromJson<InfoAboutApplication>(dataGoogle);

                text.text = "Успешно загрузил: " + "Монеты ifa.money: " + ifa.money + " Монеты класса: " + InfoAboutApplication.Money;

                InfoAboutApplication.Money = ifa.money;

                text.text += "Успешно загрузил: " + "Монеты ifa.money: " + ifa.money + " Монеты класса: " + InfoAboutApplication.Money;
            }
            else
            {
                text.text = "Данных нет, не удалось считать";
            }
        }
        else
        {
            text.text = "Ошибка при считавании данных";
        }
    }
}