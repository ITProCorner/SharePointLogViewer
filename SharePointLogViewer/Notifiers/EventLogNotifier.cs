﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SharePointLogViewer.Notifiers
{
    class EventLogNotifier : INotifier
    {
        const string source = "SPLV";

        public EventLogNotifier()
        {
            if (!EventLog.SourceExists(source))
                EventLog.CreateEventSource(source, "Application");
        }
        #region INotifier Members

        public void Notify(LogEntryViewModel logEntry)
        {
            EventLog.WriteEntry(source, logEntry.Message, EventLogEntryType.Error);
        }

        #endregion
    }
}