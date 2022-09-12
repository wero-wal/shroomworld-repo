using System;
using System.Collections.Generic;

namespace QuestPrototype
{
    internal class Game
    {
        // ----- Enums -----
		internal enum UserInput
		{
			MoveUp,
			MoveDown,
			MoveLeft,
			MoveRight,

			Interact,

			ToggleQuestMenu,

			Previous,
			Next,
			Enter,

            DoNothing,
		}

        // ----- Fields -----
        private Dictionary<ConsoleKey, UserInput> _keyBinds;
        private Player _player;
        private List<Npc> _npcs;

        // ----- Constructors -----
        internal Game()
        {
        }

        // ----- Methods -----
		internal static void Play()
		{
            SetKeyBinds();
            Console.CursorVisible = false;
            _player = new Player(GetString("Name: "));
			UserInput userInput;
			do
			{
                userInput = GetUserInput();
				player.Update(userInput);
			} while (true);
		}

        // Setup
		private void SetKeyBinds()
		{
            _keyBinds = new Dictionary<ConsoleKey, UserInput>
            {
				// Movement
                { ConsoleKey.W, UserInput.MoveUp },
                { ConsoleKey.UpArrow, UserInput.MoveUp },
                { ConsoleKey.Spacebar, UserInput.MoveUp },

                { ConsoleKey.S, UserInput.MoveDown },
                { ConsoleKey.DownArrow, UserInput.MoveDown },

                { ConsoleKey.A, UserInput.MoveLeft },
                { ConsoleKey.LeftArrow, UserInput.MoveLeft },

                { ConsoleKey.D, UserInput.MoveRight },
                { ConsoleKey.RightArrow, UserInput.MoveRight },

                // Interaction
                { ConsoleKey.C, UserInput.Interact },

                // Accessing menus
                { ConsoleKey.E, UserInput.ToggleQuestMenu },
                { ConsoleKey.Tab, UserInput.ToggleQuestMenu },

                // Navigating menus
                { ConsoleKey.B, UserInput.Previous },
                { ConsoleKey.N, UserInput.Next },
                { ConsoleKey.Enter, UserInput.Enter },
            };
		}
        private void CreateNpcs(int amount)
        {
            List<Point> usedPoints;
            for(int i = 0; i < amount; i++)
            {
                
            }
        }

        // Inputs
        private UserInput GetUserInput()
        {
            try
            {
                return _keyBinds[Console.ReadKey(true).Key];
            }
            catch(KeyNotFoundException)
            {
                return UserInput.DoNothing;
            }
        }
        private string GetString(string prompt)
        {
            // prompt
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(prompt);

            // get input
            Console.ForegroundColor = ConsoleColor.Yellow;
            bool cursorVisible = Console.CursorVisible;
            Console.CursorVisible = true;
            string input = Console.ReadLine();

            // un-change state
            Console.CursorVisible = cursorVisible;
            Console.ResetColor();

            return input;
        }
    }
}