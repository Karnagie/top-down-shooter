using System;

namespace CodeBase.Modules.WindowsModule
{
    public interface IPanel : IDisposable
    {
        void Initialize();
        
        void Show();
    }
}