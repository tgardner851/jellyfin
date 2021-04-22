#pragma warning disable CS1591

using System;
using System.Collections.Generic;

namespace MediaBrowser.Model.Session
{
    public class GeneralCommand
    {
        public GeneralCommand()
        {
            Arguments = new Dictionary<string, string>();
        }

        public GeneralCommandType Name { get; set; }

        public Guid ControllingUserId { get; set; }

        public Dictionary<string, string> Arguments { get; }
    }
}
