using System;

#pragma warning disable CS0660
#pragma warning disable CS0661

namespace CodeBase.Infrastructure.CommandCache.SaveLoad
{
    [Serializable]
    public struct SaveUnit
    {
        public Type CommandType;
        public Type ArgsType;
        public string Args;
        public readonly ICacheCommand CacheCommand;

        public SaveUnit(Type commandType, string args, ICacheCommand cacheCommand, Type argsType)
        {
            ArgsType = argsType;
            Args = args;
            CacheCommand = cacheCommand;
            CommandType = commandType;
        }

        public static bool operator ==(SaveUnit first, SaveUnit second) => first.CacheCommand == second.CacheCommand;

        public static bool operator !=(SaveUnit first, SaveUnit second) => !(first == second);
    }
}