namespace MamaStalker.Common.Interfaces
{
    public interface ITcpConnection
    {
        bool IsRunning();
        void Write(byte[] buffer);
        byte[] Read();
    }
}