namespace CodeBase.Modules.CoreModule.Services.Creatures.Components.Base
{
    public interface IDamageable : ICoreComponent
    {
        void Damage(float value);
    }
}