using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Infrastructure.Services;
using Newtonsoft.Json;
using UnityEngine;

namespace CodeBase.Infrastructure.CommandCache.SaveLoad
{
    public class PlayerPrefsCommandSaveLoader<TServices> : ICommandSaveLoader<TServices> where TServices : IServicesHolder
    {
        private readonly string Key = $"{nameof(PlayerPrefsCommandSaveLoader<TServices>)}_save";
        
        private readonly ILogService _logService;
        private readonly List<SaveUnit> _saveUnits;

        private CommandFactory _factory;
        private TServices _services;

        public PlayerPrefsCommandSaveLoader(
            ILogService logService, 
            CommandFactory factory,
            TServices services)
        {
            _services = services;
            _factory = factory;
            _logService = logService;
            
            var save = GetSave();
            _saveUnits = JsonConvert.DeserializeObject<List<SaveUnit>>(save) ?? new();
        }
        
        public ICacheCommand[] LoadAll()
        {
            ICacheCommand[] commands = new ICacheCommand[_saveUnits.Count];
            for (var index = 0; index < _saveUnits.Count; index++)
            {
                var unit = _saveUnits[index];
                var args = JsonConvert.DeserializeObject(unit.Args, unit.ArgsType);
                var command = _factory.Create(unit.CommandType, args, _services);
                commands[index] = command;
            }
            
            _saveUnits.Clear();
            Save(_saveUnits);
            return commands;
        }

        public void Save(ICacheCommand command)
        {
            var unit = ConvertToUnit(command);
            if (unit.ArgsType.IsSerializable == false)
                _logService.LogError($"Args '{unit.ArgsType}' is not serialized!");

            _saveUnits.Add(unit);
            Save(_saveUnits);
        }

        public void Unload(ICacheCommand command)
        {
            var unit = _saveUnits.FirstOrDefault((unit => unit.CacheCommand == command));
            if(unit == default)
            {
                _logService.LogError($"Command not found in save list!");
                return;
            }

            _saveUnits.Remove(unit);
            Save(_saveUnits);
        }

        private void Save(List<SaveUnit> saveUnits)
        {
            PlayerPrefs.SetString(Key, JsonConvert.SerializeObject(saveUnits));
        }

        private SaveUnit ConvertToUnit(ICacheCommand command)
        {
            var type = command.GetType();
            var args = command.JsonArgs();
            return new SaveUnit(type, args, command, command.ArgsType);
        }

        private string GetSave()
        {
            return PlayerPrefs.GetString(Key);
        }
    }
}