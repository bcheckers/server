/*
    Ben's Checker Server Library
    Copyright (C) 2024 Ben Daws.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
*/

// Title: Log.cs
// Author(s): Ben Daws <ben@bendaws.net>
// Description: Unified logging system that will also write to a gamelog

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CheckersServer
{
    class Log
    {
        static string docPath =
          Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static string LogPath = docPath + "CheckersServer";

        static StreamWriter outputFile = new StreamWriter(Path.Combine(LogPath, "gamelog.txt"));

        public static void Write(string source, string text)
        {
            outputFile.WriteLine("[CHECKERS#" + source + "]: " + text);
            Console.WriteLine("[CHECKERS#" + source + "]: " + text);
        }
    }
}
