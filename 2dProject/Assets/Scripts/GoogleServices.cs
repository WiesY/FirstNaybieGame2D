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
                try
                {
                    text.text = "Удачная аутентификация";
                }
                catch (Exception)
                {

                }                
                startTime = DateTime.Now;
            }
            else
            {

            }

            OpenSavedGame(false);
        });
    }

    public static void OpenSavedGame(bool saving) // Сохранение / Загрузка данных ||| true - сохранение, false - загрузка
    {
        isSaving = saving;
        try
        {
            text.text = "Открытие файла...";
        }
        catch (Exception)
        {
            
        }
        OpenSavedGame("TestSaveAndLoadAppssssssssssssssssssddd");
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
                try
                {
                    text.text = "Попытка сохранить";
                }
                catch (Exception)
                {

                }

                InfoAboutApplication infoAboutApplication = new InfoAboutApplication();

                infoAboutApplication.money = InfoAboutApplication.Money;
                infoAboutApplication.selectedSkin = InfoAboutApplication.SelectedSkin;
                infoAboutApplication.purchasedSkins = InfoAboutApplication.PurchasedSkins;
                infoAboutApplication.openIslands = InfoAboutApplication.OpenIslands;
                infoAboutApplication.openLevels = InfoAboutApplication.OpenLevels;
                infoAboutApplication.countTakenFruits = InfoAboutApplication.CountTakenFruits;
                infoAboutApplication.countAttempsOnLevels = InfoAboutApplication.CountAttempsOnLevels;

                string data = JsonUtility.ToJson(infoAboutApplication);

                byte[] saveData = Encoding.UTF8.GetBytes(data);

                SaveGame(game, saveData);
            }
            else if(!isSaving)
            {
                try
                {
                    text.text = "Попытка загрузить";
                }
                catch (Exception)
                {

                }
                LoadGameData(game);
            }
        }
        else
        {
            try
            {
                text.text = "Файл не открылся";
            }
            catch (Exception)
            {

            }
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
            try
            {
                text.text = "Успешно сохранил";
            }
            catch (Exception)
            {

            }
        }
        else
        {
            try
            {
                text.text = "Неудачное сохранение";
            }
            catch (Exception)
            {

            }
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
                InfoAboutApplication ifa = InfoAboutApplication.CreateFromJSON(dataGoogle);

                InfoAboutApplication.Money = ifa.money;
                InfoAboutApplication.SelectedSkin = ifa.selectedSkin;
                InfoAboutApplication.PurchasedSkins = ifa.purchasedSkins;
                InfoAboutApplication.OpenIslands = ifa.openIslands;
                InfoAboutApplication.OpenLevels = ifa.openLevels;
                InfoAboutApplication.CountTakenFruits = ifa.countTakenFruits;
                InfoAboutApplication.CountAttempsOnLevels = ifa.countAttempsOnLevels;

                try
                {
                    text.text = "Money - " + InfoAboutApplication.Money;
                    text.text += " SelectedIndex - " + InfoAboutApplication.SelectedSkin;
                    text.text += " PurchasedSkins - " + InfoAboutApplication.PurchasedSkins.Length;
                    text.text += " OpenIslands - " + InfoAboutApplication.OpenIslands[0];
                    text.text += " OpenLevels - " + InfoAboutApplication.OpenLevels[1];
                    text.text += " Fruits0 - " + InfoAboutApplication.CountTakenFruits[0];
                    text.text += " Fruits1 - " + InfoAboutApplication.CountTakenFruits[1];
                    text.text += " Fruits2 - " + InfoAboutApplication.CountTakenFruits[2];
                    text.text += " Att0 - " + InfoAboutApplication.CountAttempsOnLevels[0];
                    text.text += " Att1 - " + InfoAboutApplication.CountAttempsOnLevels[1];
                    text.text += " Att3 - " + InfoAboutApplication.CountAttempsOnLevels[2];

                    text.text += "Успешно загрузил:" + " Пройденные острова: " + InfoAboutApplication.OpenIslands[0] + InfoAboutApplication.OpenIslands[1] + InfoAboutApplication.OpenIslands[2];
                }
                catch (Exception)
                {

                }
            }
            else
            {
                InfoAboutApplication.Money = 0;
                InfoAboutApplication.SelectedSkin = 0;
                InfoAboutApplication.PurchasedSkins[0] = true;
                InfoAboutApplication.OpenIslands[0] = true;
                InfoAboutApplication.OpenLevels[0] = true;

                OpenSavedGame(true);

                try
                {
                    text.text = "Неудалось считать данные:" +
                                " Монеты: " + InfoAboutApplication.Money +
                                " Выбранный скин: " + InfoAboutApplication.SelectedSkin +
                                " Купленные скины: " + InfoAboutApplication.PurchasedSkins.Length +
                                " Пройденные острова: " + InfoAboutApplication.OpenIslands[0] +
                                                          InfoAboutApplication.OpenIslands[1] +
                                                          InfoAboutApplication.OpenIslands[2] +
                                " Фрукты: " + InfoAboutApplication.CountTakenFruits[0] +
                                          InfoAboutApplication.CountTakenFruits[1] +
                                          InfoAboutApplication.CountTakenFruits[2];
                }
                catch (Exception)
                {

                }
            }
        }
        else
        {
            try
            {
                text.text = "Ошибка при считывании данных";
            }
            catch (Exception)
            {

            }
        }
    }
}