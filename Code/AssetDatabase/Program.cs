using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemObject obj = new Image("C:\\test.data", 0);
        }

        static void Save(FileSystemObject obj)
        {

        }
    }

    class FileSystemObject
    {
        public string PathInDisk;
        public int ID;
        private bool isReadable;

        public FileSystemObject(string pathInDisk, int iD)
        {
            PathInDisk = pathInDisk;
            ID = iD;
        }
    }

    class Image : FileSystemObject
    {
        public Image(string pathInDisk, int iD) : base(pathInDisk, iD)
        {
        }
    }

    class Video : FileSystemObject
    {
        public Video() : base("test", 0)
        {

        }
    }

    class UserSave : FileSystemObject
    {

    }
}
