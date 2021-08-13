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
    public Text text;

    private bool isSaving;

    private string testString = "Hi!";
    private int testInt = 15;
    private bool testBool = true;

    private DateTime startTime;

    private void Awake()
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
                startTime = DateTime.Now;
                OpenSavedGame(false);
            }
            else
            {

            }
        });
    }

    public void OpenSavedGame(bool saving)
    {
        isSaving = saving;
        OpenSavedGame("InfoAboutApp");
    }

    private void OpenSavedGame(string filename)
    {
        ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
        savedGameClient.OpenWithAutomaticConflictResolution(filename, DataSource.ReadCacheOrNetwork,
            ConflictResolutionStrategy.UseLongestPlaytime, OnSavedGameOpened);
    }

    private void OnSavedGameOpened(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            if (isSaving)
            {
                string data = testString + ";" + testInt + ";" + testBool;

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
            // handle error
        }
    }

    private void SaveGame(ISavedGameMetadata game, byte[] savedData)
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

    private void OnSavedGameWritten(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            text.text = "Успешно сохранил";
            Debug.Log("Успешно сохранил!");
        }
        else
        {
            text.text = "Неудачное сохранение";

            // handle error
        }
    }

    private void LoadGameData(ISavedGameMetadata game)
    {
        ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
        savedGameClient.ReadBinaryData(game, OnSavedGameDataRead);
    }

    private void OnSavedGameDataRead(SavedGameRequestStatus status, byte[] data)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            if (data.Length > 0)
            {
                string dataGoogle = Encoding.ASCII.GetString(data);

                string[] s = dataGoogle.Split(';');

                text.text = s[0] + " " + s[1] + " " + s[2];

                Debug.Log("Успешно загрузил");
            }
            else
            {
                text.text = "Данных нет, не удалось считать";

                Debug.Log("Нет данных");
            }
        }
        else
        {
            // handle error
        }
    }
}