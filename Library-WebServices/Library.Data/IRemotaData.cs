namespace Library.Data
{
    public interface IRemotaData
    {
        void DownloadFile(string path);

        void UploadFile(byte[] content, string filename, string target);

        void Initialize();
    }
}
