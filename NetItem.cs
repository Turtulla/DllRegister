﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DllRegister
{
    [Serializable]
    public class FileItem
    {
        public FileItem() { Name = string.Empty;FullPath = string.Empty; }        
        [XmlAttribute]
        public string Name { get; set; }                
        [XmlAttribute]
        public string FullPath { get; set; }          
        public override string ToString()
        {
            return FullPath;
        }       
    }




    [Serializable]
    public class NetItem
    {
        public string Name { get;set;}
        private string mFullPath;
        public string FullPath { get { return mFullPath; }
            set {
                mFullPath = value;
                string version = string.Empty;
                string[] sp = value.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                if (sp != null && sp.Length > 0)
                {
                    foreach (var item in sp)
                    {
                        if (item.StartsWith("v") && int.TryParse(item.Substring(1, item.Length - 1).Replace(".", ""), out int n))
                        {
                            version = item.Substring(1, item.Length - 1);
                        }
                    }

                }

                if (mFullPath.ToLower().Contains("framework") && mFullPath.Contains("64"))
                {
                    Name = "64 Bit Net Version: " + version;
                }
                else if (mFullPath.ToLower().Contains("framework"))
                {
                    Name = "32 Bit Net Version: " + version;
                }
                else
                {
                    Name = mFullPath;
                }
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}