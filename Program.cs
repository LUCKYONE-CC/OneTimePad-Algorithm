using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace OneTimePad_Algorithm
{
    public class Program
    {
        // Zeichensatz, der für die Verschlüsselung verwendet wird
        private const string Characters = "AÄBCDEFGHIJKLMNOPÖQRSßTÜVWXYZaäbcdefghijklmnoöpqrstuvwxyz0123456789!@#$%&*()-_+=[].{}<>?/\\|:;'\",.,`~ ";

        static void Main(string[] args)
        {
            // Zuordnung von Zeichen zu Indexwerten im Zeichensatz erstellen
            Dictionary<char, int> characterIds = AssignCharacterIds();

            // Nachricht verschlüsseln und verschlüsselte Nachricht und Schlüssel abrufen
            string[] encryptedMsgAndKey = Encrypt("Cool encryption!", characterIds);

            // Verschlüsselte Nachricht anzeigen
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Encrypted: {encryptedMsgAndKey[0]}");

            // Verschlüsselte Nachricht entschlüsseln
            string decryptedMessage = Decrypt(encryptedMsgAndKey[0], encryptedMsgAndKey[1], characterIds);

            // Entschlüsselte Nachricht anzeigen
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Decrypted: {decryptedMessage}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Methode zur Verschlüsselung einer Nachricht
        public static string[] Encrypt(string message, Dictionary<char, int> characterIds)
        {
            // Zufällige Bytes generieren
            byte[] randomBytes = new byte[message.Length];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            // Schlüssel erstellen
            StringBuilder keyBuilder = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                int index = randomBytes[i] % Characters.Length;
                keyBuilder.Append(Characters[index]);
            }
            string key = keyBuilder.ToString();

            // Nachricht und Schlüssel in Zahlen umwandeln
            List<int> convertedMessageChars = ConvertToNumbers(message, characterIds);
            List<int> convertedKeyChars = ConvertToNumbers(key, characterIds);

            // Verschlüsselte Nachricht erstellen
            List<int> convertedEncryptedMessage = new List<int>();
            for (int i = 0; i < convertedMessageChars.Count; i++)
            {
                int messageChar = convertedMessageChars[i];
                int keyChar = convertedKeyChars[i];
                int encryptedChar = (messageChar + keyChar) % Characters.Length;
                convertedEncryptedMessage.Add(encryptedChar);
            }

            // Verschlüsselte Nachricht in Zeichen umwandeln
            StringBuilder encryptedMessageBuilder = new StringBuilder();
            foreach (int i in convertedEncryptedMessage)
            {
                char character = Characters[i];
                encryptedMessageBuilder.Append(character);
            }
            string encryptedMessage = encryptedMessageBuilder.ToString();

            // Verschlüsselte Nachricht und Schlüssel zurückgeben
            return new[] { encryptedMessage, key };
        }

        // Methode zur Entschlüsselung einer Nachricht
        public static string Decrypt(string message, string key, Dictionary<char, int> characterIds)
        {
            // Verschlüsselte Nachricht und Schlüssel in Zahlen umwandeln
            List<int> convertedMessageToNumbers = ConvertToNumbers(message, characterIds);
            List<int> convertedKeyToNumbers = ConvertToNumbers(key, characterIds);

            // Entschlüsselte Zahlen erstellen
            List<int> decryptedMessageNumbers = new List<int>();
            for (int i = 0; i < convertedMessageToNumbers.Count; i++)
            {
                int messageCharNumber = convertedMessageToNumbers[i];
                int keyCharNumber = convertedKeyToNumbers[i];
                int decryptedChar = (messageCharNumber - keyCharNumber) % Characters.Length;
                if (decryptedChar < 0)
                {
                    decryptedChar += Characters.Length;
                }
                decryptedMessageNumbers.Add(decryptedChar);
            }

            // Entschlüsselte Zahlen in Zeichen umwandeln
            StringBuilder decryptedMessageBuilder = new StringBuilder();
            foreach (int i in decryptedMessageNumbers)
            {
                char character = Characters[i];
                decryptedMessageBuilder.Append(character);
            }
            string decryptedMessage = decryptedMessageBuilder.ToString();

            // Entschlüsselte Nachricht zurückgeben
            return decryptedMessage;
        }

        // Methode zur Konvertierung eines Texts in Zahlen anhand der Zeichen-ID-Zuordnung
        private static List<int> ConvertToNumbers(string text, Dictionary<char, int> characterIds)
        {
            List<int> convertedChars = new List<int>();
            foreach (char c in text)
            {
                int value = characterIds[c];
                convertedChars.Add(value);
            }
            return convertedChars;
        }

        // Methode zur Zuordnung von Zeichen zu Indexwerten im Zeichensatz
        private static Dictionary<char, int> AssignCharacterIds()
        {
            Dictionary<char, int> characterIds = new Dictionary<char, int>();

            for (int i = 0; i < Characters.Length; i++)
            {
                char character = Characters[i];
                characterIds[character] = i;
            }

            return characterIds;
        }
    }
}
