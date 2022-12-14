using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shroomworld.FileHandling
{
    internal static class FilePaths
    {
        // Style note: In this class, Dir = Directory
        // todo: make a Create() method here
        // ----- Enums -----
        public enum WorldFiles
        {
            Map,
            Enemies,
            Friendlies,
            Player,
        }
        public enum Elements
        {
            Menu,
            Gui,
            Item,
            Tile,
            Biome,
            Map,
            Enemy,
            Friendly,
            Player,
            Count,
        }

        // ----- Properties -----
        // general
        public static string Users { get => _users; set => _users = value; }
        public static string GeneralSettings { get => _generalSettings; set => _generalSettings = value; }
        public static string MenuText { get => _menuText; set => _menuText = value; }

        public static Dictionary<Elements, string> Types => _types;
        public static Dictionary<Elements, string> WorldSaveFileNames => _worldSaveFiles;
        public static Dictionary<Elements, string> TextureDirs => _textureDirs;

        // ----- Fields -----
        private static Elements[] _typeElements = new Elements[] // elements of which there are types / templates
        {
            Elements.Item,
            Elements.Tile,
            Elements.Biome,
            Elements.Map,
            Elements.Enemy,
            Elements.Friendly,
            Elements.Player
        };
        private static Elements[] _elementsInWorldSaves = new Elements[] // elements present in worldsaves
        {
            Elements.Map,
            Elements.Enemy,
            Elements.Friendly,
            Elements.Player
        };
        private static Elements[] _textureElements = new Elements[] // elements which have texture files
        {
            Elements.Menu,
            Elements.Gui,
            Elements.Item,
            Elements.Tile,
            Elements.Biome,
            Elements.Enemy,
            Elements.Friendly,
            Elements.Player
        };

        // General
        private static string _users; // contains names, ids, and settings of users
        private static string _generalSettings; // contains 
        private static string _menuText; // contains text for all menu buttons and headings for all menus

        private static Dictionary<Elements, string> _types;
        private static string _worldSavesDir; // contains all world save directories
        private static Dictionary<Elements, string> _worldSaveFiles; // names of the files in eachworld save directory
        private static Dictionary<Elements, string> _textureDirs; // paths of all the texture directories


        // ----- Methods -----
        /// <summary>
        /// Takes a list of filepaths and saves them to the appropriate dictionaries.
        /// </summary>
        /// <param name="paths"></param>
        /// <returns>True if all file paths are set successfully; false if not enough paths were passed.</returns>
        public static bool SetFilePaths(params string[] paths)
        {
            int p = 0;
            try
            {
                _generalSettings = paths[p++];
                _menuText = paths[p++];

                _types = new Dictionary<Elements, string>(_textureElements.Length);
                for (int i = 0; i < _typeElements.Length; i++)
                {
                    _types.Add(_typeElements[i], paths[p++]);
                }

                _worldSavesDir = paths[p++];
                _worldSaveFiles = new Dictionary<Elements, string>(_elementsInWorldSaves.Length);
                for (int i = 0; i < _elementsInWorldSaves.Length; i++)
                {
                    _worldSaveFiles.Add(_elementsInWorldSaves[i], paths[p++]);
                }

                _textureDirs = new Dictionary<Elements, string>(_textureElements.Length);
                for (int i = 0; i < _textureElements.Length; i++)
                {
                    _textureDirs.Add(_textureElements[i], paths[p++]);
                }
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            return true;
        }
        public static string GetPathForWorldFile(int worldId, Elements file)
        {
            return $"{_worldSavesDir}{worldId}\\{_worldSaveFiles[file]}";
        }
    }
}
