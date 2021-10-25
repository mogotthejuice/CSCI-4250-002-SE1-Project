using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Models {
    public class GameLog {
        /// <summary>
        /// Instance of the Game Log
        /// </summary>
        private static GameLog instance;
        
        /// <summary>
        /// List of Game Log Messages
        /// </summary>
        public List<string> Messages { get; private set; }

        /// <summary>
        /// Last added message to the Game Log
        /// </summary>
        public string CurrentMessage { get { return Messages[^1]; } private set { } } 
        
        /// <summary>
        /// private constructor for singleton Game Log
        /// </summary>
        private GameLog() {
            Messages = new List<string>();
            CurrentMessage = "";
        }
        
        /// <summary>
        /// Singleton instance handler
        /// </summary>
        /// <returns>An instance of the class</returns>
        public static GameLog GetInstance() {
            if (instance == null) {
                instance = new GameLog();
            }
            return instance;
        }

        /// <summary>
        /// Adds a message to the Game Log.
        /// </summary>
        /// <param name="message">Message to be added to the log.</param>
        public  void AddMessage(string message) {
            Messages.Add(message);
            CurrentMessage = message;
        }
    }
}
