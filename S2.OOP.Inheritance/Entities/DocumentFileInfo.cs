using System;

namespace S2.OOP.Inheritance
{
    class DocumentFileInfo : CustomFileInfo
    {
        public DocumentFileInfo(string fileName, int fileSize, DateTime creationDate)
            : base(fileName, fileSize, creationDate)
        {
            FileName = fileName;
            FileSize = fileSize;
            CreationDate = creationDate;
        }
    }
}