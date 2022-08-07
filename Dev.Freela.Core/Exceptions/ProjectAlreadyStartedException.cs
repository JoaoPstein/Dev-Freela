﻿namespace Dev.Freela.Core.Exceptions
{
    public class ProjectAlreadyStartedException : Exception
    {
        public ProjectAlreadyStartedException() : base("Project already in Started status")
        {

        }
    }
}
