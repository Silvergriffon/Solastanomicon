using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using UnityModManagerNet;
using ModKit;
using SolastaModApi;

namespace Solastanomicon
{
    public class Main
    {
        public static bool Enabled = false;
        public static readonly string MOD_FOLDER = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [Conditional("DEBUG")]
        internal static void Log(string msg) => Logger.Log(msg);
        internal static void Error(Exception ex) => Logger?.Error(ex.ToString());
        internal static void Error(string msg) => Logger?.Error(msg);
        internal static void Warning(string msg) => Logger?.Warning(msg);
        internal static UnityModManager.ModEntry.ModLogger Logger { get; private set; }
        internal static ModManager<Core, Settings> Mod;
        //internal static MenuManager Menu;
        internal static Settings Settings { get { return Mod.Settings; } }

        internal static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();

                Logger = modEntry.Logger;

                Mod = new ModManager<Core, Settings>();
                Mod.Enable(modEntry, assembly);
                //Menu = new MenuManager();
                //Menu.Enable(modEntry, assembly);
                Translations.Load(MOD_FOLDER);
            }
            catch (Exception ex)
            {
                Error(ex);
                throw;
            }

            return true;
        }

        internal static void OnGameReady()
        {
            CharacterRaceDefinition dwarfNames = DatabaseHelper.CharacterRaceDefinitions.Dwarf;
            CharacterRaceDefinition elfHighNames = DatabaseHelper.CharacterRaceDefinitions.ElfHigh;
            CharacterRaceDefinition elfSylvanNames = DatabaseHelper.CharacterRaceDefinitions.ElfSylvan;
            CharacterRaceDefinition halfElfNames = DatabaseHelper.CharacterRaceDefinitions.HalfElf;
            CharacterRaceDefinition halflingNames = DatabaseHelper.CharacterRaceDefinitions.Halfling;
            CharacterRaceDefinition humanNames = DatabaseHelper.CharacterRaceDefinitions.Human;

            foreach (var line in File.ReadLines($"{MOD_FOLDER}/translations-en.txt"))
            {

                var splitted = line.Split(new[] { '\t', ' ' }, 2);
                var term = splitted[0];

                if (term.Contains("DwarfFemale"))
                {
                    dwarfNames.RacePresentation.FemaleNameOptions.Add(term);
                }
                else if (term.Contains("DwarfMale"))
                {
                    dwarfNames.RacePresentation.MaleNameOptions.Add(term);
                }
                else if (term.Contains("DwarfSur"))
                {
                    dwarfNames.RacePresentation.SurNameOptions.Add(term);
                }

                else if (term.Contains("ElfFemale"))
                {
                    elfHighNames.RacePresentation.FemaleNameOptions.Add(term);
                }
                else if (term.Contains("ElfMale"))
                {
                    elfHighNames.RacePresentation.MaleNameOptions.Add(term);
                }
                else if (term.Contains("ElfSur"))
                {
                    elfHighNames.RacePresentation.SurNameOptions.Add(term);
                }

                else if (term.Contains("SylvanElfFemale"))
                {
                    elfSylvanNames.RacePresentation.FemaleNameOptions.Add(term);
                }
                else if (term.Contains("SylvanElfMale"))
                {
                    elfSylvanNames.RacePresentation.MaleNameOptions.Add(term);
                }
                else if (term.Contains("SylvanElfSur"))
                {
                    elfSylvanNames.RacePresentation.SurNameOptions.Add(term);
                }

                else if (term.Contains("HalfElfFemale"))
                {
                    halfElfNames.RacePresentation.FemaleNameOptions.Add(term);
                }
                else if (term.Contains("HalfElfMale"))
                {
                    halfElfNames.RacePresentation.MaleNameOptions.Add(term);
                }
                else if (term.Contains("HalfElfSur"))
                {
                    halfElfNames.RacePresentation.SurNameOptions.Add(term);
                }

                else if (term.Contains("HalflingFemale"))
                {
                    halflingNames.RacePresentation.FemaleNameOptions.Add(term);
                }
                else if (term.Contains("HalflingMale"))
                {
                    halflingNames.RacePresentation.MaleNameOptions.Add(term);
                }
                else if (term.Contains("HalflingSur"))
                {
                    halflingNames.RacePresentation.SurNameOptions.Add(term);
                }

                else if (term.Contains("HumanFemale"))
                {
                    humanNames.RacePresentation.FemaleNameOptions.Add(term);
                }
                else if (term.Contains("HumanMale"))
                {
                    humanNames.RacePresentation.MaleNameOptions.Add(term);
                }
                else if (term.Contains("HumanSur"))
                {
                    humanNames.RacePresentation.SurNameOptions.Add(term);
                }
            }
        }
    }
}