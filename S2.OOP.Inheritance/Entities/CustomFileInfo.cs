using System;

namespace S2.OOP.Inheritance
{
    abstract class CustomFileInfo
    {
        protected string fileName;
        protected int fileSize;
        protected DateTime creationDate;


        protected CustomFileInfo(string fileName, int fileSize, DateTime creationDate)
        {
            FileName = fileName;
            FileSize = fileSize;
            CreationDate = creationDate;
        }

        public virtual string FileName
        {
            get
            {
                return fileName;
            }

            set
            {
                if(fileName != value)
                {
                    fileName = value;
                }
            }
        }

        public virtual int FileSize
        {
            get
            {
                return fileSize;
            }

            set
            {
                bool isValid = IsSizeTooLarge();
                if(!isValid)
                {
                    if(fileSize != value)
                    {
                        fileSize = value;
                    }
                }
                else
                {
                    throw new ArgumentException("The file size is too large", nameof(FileSize));
                }
            }
        }

        public virtual DateTime CreationDate
        {
            get
            {
                return creationDate;
            }

            set
            {
                if(creationDate != value)
                {
                    creationDate = value;
                }
            }
        }

        public override string ToString()
        {
            return fileName;
        }

        public virtual bool IsSizeTooLarge()
        {
            if(fileSize > 45)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}