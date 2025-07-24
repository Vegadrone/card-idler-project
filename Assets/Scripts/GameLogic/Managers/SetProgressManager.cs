using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class SetProgressManager
{
    private HashSet<string> unlockedSets = new HashSet<string>();
    private HashSet<string> uncoveredSets = new HashSet<string>();

    private string saveFilePath;

    private static SetProgressManager _instance;

    public static SetProgressManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SetProgressManager();
                _instance.SetProgressManagerInit();
            }
            return _instance;
        }
    }

    private void SetProgressManagerInit()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "setProgression.json");
        Load();
    }

    private void Load()
    {
        if (!File.Exists(saveFilePath))
        {
            Debug.LogWarning($"[SetProgressManager - Load] - {saveFilePath} not found!");
            return;
        }

        string json = File.ReadAllText(saveFilePath);
        var data = JsonConvert.DeserializeObject<ProgressData>(json);
        unlockedSets = new HashSet<string>(data.UnlockedSets ?? new List<string>());
        uncoveredSets = new HashSet<string>(data.UncoveredSets ?? new List<string>());
        Debug.LogWarning($"[SetProgressManager - Save] - successfully load!");
        
    }

    private void Save()
    {
        var data = new ProgressData
        {
            UnlockedSets = unlockedSets.ToList(),
            UncoveredSets = uncoveredSets.ToList()
        };
        var json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(saveFilePath, json);
        Debug.LogWarning($"[SetProgressManager - Save] - successfully saved!");
    }

    public void MarkUncovered(string setId)
    {
        if (uncoveredSets.Add(setId)) Save();
    }

    public void UnlockSet(string setId)
    {
        if (unlockedSets.Add(setId)) Save();
    }

    public bool IsUncovered(string setId) => uncoveredSets.Contains(setId);
    public bool IsUnlocked(string setId) => unlockedSets.Contains(setId);

    class ProgressData
    {
        public List<string> UnlockedSets { get; set; }
        public List<string> UncoveredSets { get; set; }
    }
}
