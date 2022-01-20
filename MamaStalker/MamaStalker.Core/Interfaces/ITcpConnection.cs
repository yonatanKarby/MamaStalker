namespace MamaStalker.Common.Interfaces
{
    public interface ITcpConnection
    {
        void Write(byte[] buffer);
        byte[] Read();
    }
}