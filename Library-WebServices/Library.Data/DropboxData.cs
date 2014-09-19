namespace Library.Data
{
    using HigLabo.Net;
    using HigLabo.Net.Dropbox;

    public class DropboxData : IRemotaData
    {
        private const string APP_KEY = "c4oiq2h11r3ogt9";
        private const string APP_SECRET = "wzhi0p1way43gdd";

        private OAuthClient ocl;
        private AuthorizeInfo ai;
        public string RequestToken { get; private set; }
        public string RequestTokenSecret { get; private set; }
        public string redirect_url { get; private set; }



        public string Token { get; private set; }
        public string TokenSecret { get; private set; }


        public DropboxData()
        {
        }

        public void Initialize()
        {
            
        }

        public void DownloadFile(string path)
        {

        }

        public void UploadFile(byte[] content, string filename, string target)
        {
            ocl = DropboxClient.CreateOAuthClient(APP_KEY, APP_SECRET);
            ai = ocl.GetAuthorizeInfo();

            RequestToken = ai.RequestToken;
            RequestTokenSecret = ai.RequestTokenSecret;
            redirect_url = ai.AuthorizeUrl;
            AccessTokenInfo t = ocl.GetAccessToken(RequestToken, RequestTokenSecret);

            Token = t.Token;
            TokenSecret = t.TokenSecret;

            DropboxClient cl = new DropboxClient(APP_KEY, APP_SECRET, Token, TokenSecret);

            HigLabo.Net.Dropbox.UploadFileCommand ul = new HigLabo.Net.Dropbox.UploadFileCommand();
            ul.Root = RootFolder.Sandbox;
            ul.FolderPath = target;
            ul.FileName = filename;
            ul.LoadFileData(content);

            Metadata md = cl.UploadFile(ul);


        }
    }
}
