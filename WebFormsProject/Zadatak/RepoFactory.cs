using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zadatak
{
    // statičke klase se ne mogu nasljeđivat i one same ne mogu nasljeđivati
    public static class RepoFactory // statička klasa se ne može instancirat
    {
        private static DataRepo dataRepo = new DataRepo(); // jedna instanca i nikad više instanci 
        private static FileRepo fileRepo = new FileRepo();

        public static bool UseDataRepo { get; set; } = true;

        public static IRepo GetRepository()
        {
            if (UseDataRepo)
            {
                return dataRepo;
            }
            return fileRepo;
        }
    }
}