using System;
using System.Collections.Generic;
using System.IO;

namespace Persistence
{
    public class FileManager
    {
        // The file where all data is stored
        private readonly string filePath = "database.txt";

        // Stores all key-value pairs in memory
        private Dictionary<string, string> records;

        public FileManager()
        {
            records = new Dictionary<string, string>();

            Load();
        }

        public void Save(string id, string content)
        {
            // Add a new key or update an existing one
            records[id] = content;

            SaveToDisk();
        }

        public bool Delete(string id)
        {
            if (records.Remove(id))
            {
                SaveToDisk();
                return true;
            }

            return false;
        }

        public string Retrieve(string id)
        {
            if (records.ContainsKey(id))
            {
                return records[id];
            }

            return "Key does not exist";
        }

        private void Load()
        {
            // Create the file if it doesn't exist
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                return;
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                // Ignore blank lines
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split('=');

                // Ignore malformed lines
                if (parts.Length != 2)
                    continue;

                records[parts[0]] = parts[1];
            }
        }

        private void SaveToDisk()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (KeyValuePair<string, string> entry in records)
                {
                    writer.WriteLine($"{entry.Key}={entry.Value}");
                }
            }
        }
    }
}