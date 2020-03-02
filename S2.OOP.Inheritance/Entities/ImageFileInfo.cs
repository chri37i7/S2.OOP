using System;

namespace S2.OOP.Inheritance.Entities
{
    class ImageFileInfo : CustomFileInfo
    {
        protected int width;
        protected int height;

        public ImageFileInfo(int height, int width, string fileName, int fileSize, DateTime creationDate)
            : base(fileName, fileSize, creationDate)
        {
            Height = height;
            Width = width;
        }

        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                if(height != value)
                {
                    height = value;
                }
            }
        }

        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                if(width != value)
                {
                    width = value;
                }
            }
        }

        public bool IsFileTooLarge()
        {
            if(fileSize > 45)
            {
                return true;
            }
            if(height > 1080)
            {
                return true;
            }
            if(width > 1920)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}