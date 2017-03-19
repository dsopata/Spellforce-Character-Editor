using System;
using System.Net;
using System.Xml;


namespace SCE_Updater
{
    internal class UpdateXML
    {
        private Version version;
        private Uri uri;
        private string filename;
        private string md5;
        private string description;
        private string launchArgs;

        internal Version Version
        {
            get
            { return this.version}
        }
        internal Uri Uri
        {
            get
            { return this.uri; }
        }
        internal string Filename
        {
            get
            { return this.Filename; }
        }
        internal String MD5
        {
            get
            { return this.md5; }
        }
        internal String Description
        {
            get
            { return this.description; }
        }
        internal string LaunchArgs
        {
            get
            { return this.launchArgs; }
        }


        internal UpdateXML(Version version, Uri uri, string filename, string md5, string description, string launchArgs)
        {
            this.version = version;
            this.uri = uri;
            this.filename = filename;
            this.md5 = md5;
            this.description = description;
            this.launchArgs = launchArgs;
        }

        internal bool IsNewerThan(Version version)
        {
            return this.version > version;
        }

        internal static bool ExistsOnServer(Uri location)
        {
            try {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(location.AbsoluteUri);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                resp.Close();

                return resp.StatusCode == HttpStatusCode.OK;
            }
            catch { return false; }
        }
    }
}
