﻿using System;

namespace S2.OOP.Inheritance.Entities
{
    class VideoFileInfo : ImageFileInfo
    {
        private int duration;

        public VideoFileInfo(int duration, int width, int height, string fileName, int fileSize, DateTime creationDate)
            : base(height, width, fileName, fileSize, creationDate)
        {
            Duration = duration;
        }

        public int Duration
        {
            get
            {
                return duration;
            }

            set
            {
                if(duration != value)
                {
                    duration = value;
                }
            }
        }

        public override string ToString()
        {
            return $"Video: {fileName}";
        }
    }
}