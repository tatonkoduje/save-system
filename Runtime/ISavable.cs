namespace com.maapiid.savesystem
{
    public interface ISavable
    {
        object CaptureState();
        void RestoreState(object state);
    }
}