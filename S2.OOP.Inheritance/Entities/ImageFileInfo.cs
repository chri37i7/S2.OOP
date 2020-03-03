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

        public virtual int Height
        {
            get
            {
                return height;
            }

            set
            {
                bool isValid = IsSizeTooLarge();
                if(!isValid)
                {
                    if(height != value)
                    {
                        height = value;
                    }
                }
                else
                {
                    throw new ArgumentException("The size is too large", nameof(Height));
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
                bool isValid = IsSizeTooLarge();
                if(!isValid)
                {
                    if(width != value)
                    {
                        width = value;
                    }
                }
                else
                {
                    throw new ArgumentException("The size is too large", nameof(Width));
                }
            }
        }

        public override bool IsSizeTooLarge()
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