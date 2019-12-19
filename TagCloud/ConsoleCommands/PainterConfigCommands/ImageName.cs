﻿using System.Collections.Generic;
using TagCloud.TagCloudPainter;
using UIConsole;

namespace TagCloud.ConsoleCommands
{
    public class ImageName : IConsoleCommand
    {
        private PainterConfig painterConfig;
        
        public ImageName(PainterConfig config)
        {
            painterConfig = config;
        }
        
        public string Name => "ImageName";
        public string Description => "Задает имя для изображения";
        public void Execute(ConsoleUserInterface console, Dictionary<string, object> args)
        {
            var imageName = args["Name"].ToString();
            painterConfig.ImageName = imageName;
        }

        public List<string> ArgsName => new List<string>() {"Name"};
    }
}