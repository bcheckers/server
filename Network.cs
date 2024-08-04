/*
    Ben's Checker Server Library
    Copyright (C) 2024 Ben Daws.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
*/

// Title: Network.cs
// Author(s): Ben Daws <ben@bendaws.net>
// Description: Mostly manages HTTP socket requests from clients

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace CheckersServer
{
    public class Network
    {
        bool ServerPasswordEnabled = false;
        private string ServerPassword = ""; // note: confirm ServerPasswordEnabled is on before setting password (SetServerPassword() does this by itself)

        private List<string> PlayersOnline = new List<string> {"server"};

        public void AppendOnlinePlayer(string username) {
            if (!PlayersOnline.Contains(username))
            {
                PlayersOnline.Add(username);
            }
            else
            {
                PlayersOnline.Add(username + " (2)");
            }
            
        }

        public void SetServerPassword(string passwordContent)
        {
            if (!ServerPasswordEnabled)
            {
                ServerPasswordEnabled = true;
            }

            ServerPassword = passwordContent;
        }

        public void SendLoseGameTriggerToPlayer(string playerName)
        {
            /*
             * When game finishes, you can send a LoseGameTrigger or a WinGameTrigger to a player.
             * If the game is finished, please use this instead of DisconnectPlayer(plr, reason). 
             * 
             * DisconnectPlayer() should really only be used for errors and kick/ban messages.
            */
        }

        public int DisconnectPlayer(string playerName, string reason = "")
        {
            if (playerName == "" || playerName == null)
            {
                Log.Write("NETWORK", "DisconnectPlayer() attempted to run without a playername, cannot disconnect");
                return 1;
            }

            return 0;
        }

        public int ConnectPlayer(string ipAddress, string username = "player")
        {
            // note: default player name is "player", you can connect without a username.

            if (ipAddress == "" || ipAddress == null)
            {
                Log.Write("NETWORK", "ConnectPlayer() called without an IP address. Connection failed");
                return 1;

            }

            AppendOnlinePlayer(username);

            return 0;
        }
    }
}
