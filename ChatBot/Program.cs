using System;
using System.Speech.Synthesis;  // Namespace for speech synthesis
using System.Threading;         // Namespace for threading functionalities

namespace VoiceActivation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a SpeechSynthesizer object to convert text to speech
            SpeechSynthesizer synth = new SpeechSynthesizer();

            // Configure the synthesizer settings
            synth.Volume = 100; // Set volume level (0-100)
            synth.Rate = 0;     // Set speaking rate (-10 to 10)

            // Select a female voice
            synth.SelectVoiceByHints(VoiceGender.Female);

            // ASCII Art Logo for visual appeal
            string logo = @"
 ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄       ▄▄▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄ 
▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░▌ ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌
▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀ ▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀      ▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌ ▀▀▀▀█░█▀▀▀▀ 
▐░▌          ▐░▌          ▐░▌          ▐░▌       ▐░▌▐░▌       ▐░▌▐░▌               ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌     
▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄▄▄ ▐░▌          ▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄▄▄      ▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌     ▐░▌     
▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌          ▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░▌ ▐░▌       ▐░▌     ▐░▌     
 ▀▀▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀ ▐░▌          ▐░▌       ▐░▌▐░█▀▀▀▀█░█▀▀ ▐░█▀▀▀▀▀▀▀▀▀      ▐░█▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌     ▐░▌     
          ▐░▌▐░▌          ▐░▌          ▐░▌       ▐░▌▐░▌     ▐░▌  ▐░▌               ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌     
 ▄▄▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌▐░▌      ▐░▌ ▐░█▄▄▄▄▄▄▄▄▄      ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌     ▐░▌     
▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░▌ ▐░░░░░░░░░░░▌     ▐░▌     
 ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀         ▀  ▀▀▀▀▀▀▀▀▀▀▀       ▀▀▀▀▀▀▀▀▀▀   ▀▀▀▀▀▀▀▀▀▀▀       ▀      
";

            // Greet the user and ask for their name
            Console.WriteLine("\n" + ColorText("Hello! Welcome to the Cybersecurity Secure Bot.", ConsoleColor.Cyan));
            synth.Speak("Hello! Welcome to the Cybersecurity Secure Bot.");

            // Prompt for user name
            Console.Write("\nWhat's your name? ");
            string userName = Console.ReadLine();

            // Personalized welcome message
            Console.WriteLine($"\n{ColorText("Welcome, " + userName + "! We're here to help you stay safe online.", ConsoleColor.Green)}\n");
            Console.WriteLine(logo);

            // Speak the personalized welcome message
            synth.Speak($"Welcome, {userName}! We're here to help you stay safe online.");

            // Basic Response System loop
            while (true)
            {
                // Divider for readability
                Console.WriteLine("\n" + new string('-', 50));
                Console.Write("You can ask me anything: ");
                string userQuestion = Console.ReadLine().ToLower().Trim();

                // Simulate typing effect for user input
                foreach (char c in userQuestion)
                {
                    Console.Write(c);
                    Thread.Sleep(50); // Adjust delay for typing effect
                }
                Console.WriteLine(); // New line after user input

                // Check for empty input
                if (string.IsNullOrEmpty(userQuestion))
                {
                    string response = "I didn't quite understand that. Could you rephrase?";
                    Console.WriteLine(ColorText(response, ConsoleColor.Yellow));
                    synth.Speak(response);
                    continue; // Skip the rest of the loop
                }

                // Respond based on user input
                if (userQuestion.Contains("how are you"))
                {
                    string response = "I'm just a program, but I'm here to help you!";
                    Console.WriteLine(ColorText(response, ConsoleColor.Yellow));
                    synth.Speak(response);
                }
                else if (userQuestion.Contains("what's your purpose"))
                {
                    string response = "My purpose is to help you understand cybersecurity and keep you safe online.";
                    Console.WriteLine(ColorText(response, ConsoleColor.Yellow));
                    synth.Speak(response);
                }
                else if (userQuestion.Contains("what can i ask you about"))
                {
                    string response = "You can ask me about password safety, phishing, and safe browsing.";
                    Console.WriteLine(ColorText(response, ConsoleColor.Yellow));
                    synth.Speak(response);
                }
                else if (userQuestion.Contains("exit"))
                {
                    Console.WriteLine(ColorText("Goodbye!", ConsoleColor.Red));
                    synth.Speak("Goodbye!");
                    break; // Exit the loop
                }
                else
                {
                    string response = "I'm sorry, I don't have an answer for that. Try asking about password safety, phishing, or safe browsing.";
                    Console.WriteLine(ColorText(response, ConsoleColor.Yellow));
                    synth.Speak(response);
                }
            }
        }

        // Method to print colored text in the console
        static string ColorText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color; // Set the text color
            Console.Write(text);              // Print the text
            Console.ResetColor();             // Reset to default color
            return text;                      // Return the text
        }
    }
}