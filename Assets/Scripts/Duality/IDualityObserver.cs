namespace HeresyRun.Duality
{
    /// <summary>
    /// Interface para subscriptores que reaccionan a cambios en el DualityMeter.
    /// </summary>
    public interface IDualityObserver
    {
        void OnDualityChanged(float value, DualityState state);
    }
}