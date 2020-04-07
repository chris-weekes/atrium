using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace atriumBE
{
    class ProxyConfig
    {
       public atriumBE.Servers.ServerRow serverR; 
        public string user; 
        public string password;
     //   public NetworkCredential ADNC;
    }
    class Proxy
    {
        bool stop = false;
        System.Net.HttpListener lmListener;
        CookieContainer jar;
        System.Net.CredentialCache cc;

        ProxyConfig pxc;

        public Proxy(ProxyConfig _pxc)
        {
            pxc = _pxc;

            System.Diagnostics.Trace.WriteLine("Starting Lawmate gateway...");

                       ServicePointManager.ServerCertificateValidationCallback = delegate { return true; }; 

            System.Uri u = new Uri(pxc.serverR.remoteUrl);// + "/");

            cc = new System.Net.CredentialCache();
            if (pxc.user.Contains( "\\"))
                cc.Add(u, "Negotiate", CredentialCache.DefaultNetworkCredentials);
            else
            {
                System.Net.NetworkCredential nc = new System.Net.NetworkCredential(pxc.user, pxc.password);
                cc.Add(u, "Digest", nc);
                cc.Add(u, "Basic", nc);
            }

            System.Net.HttpWebRequest wcinit = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(u);
            jar = new CookieContainer();

            wcinit.CookieContainer = jar;
            wcinit.Credentials = cc;
            wcinit.PreAuthenticate = true;
            wcinit.UnsafeAuthenticatedConnectionSharing = true; //for kerberos
            try
            {
                System.Net.HttpWebResponse hwinit = (System.Net.HttpWebResponse)wcinit.GetResponse();

                hwinit.Close();
                System.Diagnostics.Trace.WriteLine("Ready to start Lawmate...");
            }
            catch (Exception x)
            {
                System.Diagnostics.Trace.WriteLine(x.Message);

                return;
            }
        }
        public void Stop()
        {
            lmListener.Stop();
            lmListener.Close();
            stop = true;
        }

        public void  Start()
        {
          

            int iCount = 0;
           

            lmListener = new HttpListener();

            string pxUrl = pxc.serverR.proxyUrl;
            if(!pxUrl.EndsWith(@"/"))
                pxUrl+=@"/";

            lmListener.Prefixes.Add(pxUrl);

            //netsh http add urlacl url=http://lawmate.secure:8008/lmrasT user=HQ\cweekes --listen=true
            lmListener.Start();

            while (!stop)
            {
                HttpListenerContext context = lmListener.GetContext();
                try
                {
                    iCount++;
                    HttpListenerRequest request = context.Request;

                    Uri url = request.Url;
                    System.Diagnostics.Trace.WriteLine(String.Format("{2}, {0}, {1}", DateTime.Now, url.ToString(), iCount.ToString()));

                    Uri server = new Uri(url.AbsoluteUri.Replace(pxc.serverR.proxyUrl, pxc.serverR.remoteUrl));

                  //  System.Diagnostics.Trace.WriteLine(server.AbsoluteUri);

                    HttpWebRequest wc = (HttpWebRequest)WebRequest.Create(server);
                    wc.Credentials = cc;
                    wc.PreAuthenticate = true;
                    wc.UnsafeAuthenticatedConnectionSharing = true;
                    wc.Timeout = 0;

                    wc.ContentLength = request.ContentLength64;
                    wc.CookieContainer = jar;
                    wc.Method = request.HttpMethod;
                    wc.AllowWriteStreamBuffering = false;//for large files

                    wc.ContentType = "application/octet-stream";

                    if (wc.Method == "POST")
                    {
                        Stream toServer = wc.GetRequestStream();

                        Stream fromClient = request.InputStream;

                        RelayStream(fromClient, toServer);
                    }

                    HttpWebResponse hw = (HttpWebResponse)wc.GetResponse();

                    HttpListenerResponse response = context.Response;

                    Stream fromServer = hw.GetResponseStream();
                    Stream output = response.OutputStream;

                    RelayStream(fromServer, output);
                    hw.Close();
                    output.Close();
                }
                catch (WebException x)
                {
                    HttpListenerResponse response = context.Response;
                    HttpWebResponse err = (HttpWebResponse)x.Response;
                    response.StatusCode = (int)err.StatusCode;
                    response.StatusDescription = err.StatusDescription;

                    Stream fromServer = err.GetResponseStream();
                    Stream output = response.OutputStream;

                    RelayStream(fromServer, output);
                    err.Close();
                    output.Close();



                }
                catch (Exception xx)
                {
                    System.Diagnostics.Trace.WriteLine(xx.Message);
                }
            }
        }
        //static System.Runtime.Remoting.Messaging.Header[] myHeaders;
        //public static object Help(System.Runtime.Remoting.Messaging.Header[] headers)
        //{
        //    myHeaders = headers;
        //    return headers;
        //}


        private static void RelayStream(Stream fromStream, Stream toStream)
        {
            byte[] message;
            int bytesRead;
            int bufferSize=8192;

            message = new byte[bufferSize];



            while (true)
            {
                bytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = fromStream.Read(message, 0, bufferSize);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }

                //message has successfully been received
                toStream.Write(message, 0, bytesRead);

                //UTF8Encoding encoder = new UTF8Encoding();
                //ASCIIEncoding encoder = new ASCIIEncoding();
                //string msg = encoder.GetString(message, 0, bytesRead);

                ////System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));

                //msg=msg.Replace(@"https://www.asptek.ca:443", @"http://lawmate.secure");
                //byte[] b = encoder.GetBytes(msg);
                //toStream.Write(b, 0,b.Length);
            }
        }

    }
}
