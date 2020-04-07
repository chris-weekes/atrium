using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Services;


namespace lmras
{
    class TrackingHandler : ITrackingHandler
    {

        string strAddress = lmras.Properties.Settings.Default.alias;


        public void DisconnectedObject(object obj)
        {
            //do nothing
        }

        public void MarshaledObject(object obj, ObjRef or)
        {
            if (or.ChannelInfo == null)
                return;

            

            for (int i = or.ChannelInfo.ChannelData.GetLowerBound(0);
                            i <= or.ChannelInfo.ChannelData.GetUpperBound(0); i++)
            {
                // Check for the ChannelDataStore object that we don't want to copy
                if (or.ChannelInfo.ChannelData[i] is ChannelDataStore)
                {
                    // Personally I don't know why ChannelURIs is an array... I am only
                    // familiar with there being one URI in each ChannelDataStore object
                    foreach (string uri in ((ChannelDataStore)or.ChannelInfo.ChannelData[i]).ChannelUris)
                    {
                        // this will get the first part of the uri
//                        int nOffset = uri.IndexOf("//") + 2;

                        Uri uOld = new Uri(uri);

                        string strNewUri = "http://" + strAddress + "/" + uOld.AbsolutePath;
                        //    uri.Substring(0, nOffset);
                        //strNewUri += strAddress;
                        //nOffset = uri.IndexOf(":", nOffset);
                        //strNewUri += uri.Substring(nOffset, uri.Length - nOffset);
                        //strNewUri = strNewUri.Replace(":443", ":80");
                        
                        string[] strarray = new string[1] { strNewUri };

                        ChannelDataStore cds = new ChannelDataStore(strarray);
                        or.ChannelInfo.ChannelData[i] = cds;
                    }
                }
            }
        }

        public void UnmarshaledObject(object obj, ObjRef or)
        {
            //do nothing
        }

    }
}
