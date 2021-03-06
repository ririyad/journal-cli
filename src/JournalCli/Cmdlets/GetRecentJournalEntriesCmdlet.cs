﻿using System;
using System.IO.Abstractions;
using System.Management.Automation;
using JetBrains.Annotations;
using JournalCli.Core;
using JournalCli.Infrastructure;

namespace JournalCli.Cmdlets
{
    [PublicAPI]
    [Cmdlet(VerbsCommon.Get, "RecentJournalEntries")]
    [Obsolete("It will be removed in a future release. Use Get-JournalFiles instead.")]
    public class GetRecentJournalEntriesCmdlet : JournalCmdletBase
    {
        [Parameter]
        public int Limit { get; set; }

        protected override void RunJournalCommand()
        {
            var fileSystem = new FileSystem();
            var readerWriterFactory = new JournalReaderWriterFactory(fileSystem, Location);
            var markdownFiles = new MarkdownFiles(fileSystem, Location);
            var journal = Journal.Open(readerWriterFactory, markdownFiles, SystemProcess);

            var entries = journal.GetRecentEntries(Limit);
            WriteObject(entries, true);
        }
    }
}
