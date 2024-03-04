using System;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class LogService : ILogService
    {
        public void Log(string text, LogDefinition definition)
        {
            switch (definition)
            {
                case LogDefinition.GameState:
                    Debug.Log($"<color=#52ffee>{definition}</color>: {text}");
                    break;
                case LogDefinition.Infrastructure:
                    Debug.Log($"<color=#f5dd90>{definition}</color>: {text}");
                    break;
                case LogDefinition.Core:
                    Debug.Log($"<color=#db3a34>{definition}</color>: {text}");
                    break;
                case LogDefinition.MainMenu:
                    Debug.Log($"<color=#a4b0f5>{definition}</color>: {text}");
                    break;
                default:
                    Debug.Log($"{text}");
                    break;
            }
            LastLog = text;
        }

        public void LogError(string text)
        {
            Debug.LogError($"{text}");
            LastLog = text;
        }

        public string LastLog { get; private set; }
    }

    public enum LogDefinition
    {
        Default,
        GameState,
        Infrastructure,
        Core,
        MainMenu,
    }

    public interface ILogService
    {
        string LastLog { get; }

        void Log(string text, LogDefinition definition);
        void LogError(string text);
    }
}