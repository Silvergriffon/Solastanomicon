using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using UnityModManagerNet;
using SolastaModApi;
using ModKit;
using ModKit.Utility;

namespace Solastanomicon
{
    public static class Main
    {
        public static readonly string MOD_FOLDER = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [Conditional("DEBUG")]
        internal static void Log(string msg) => Logger.Log(msg);
        internal static void Error(Exception ex) => Logger?.Error(ex.ToString());
        internal static void Error(string msg) => Logger?.Error(msg);
        internal static void Warning(string msg) => Logger?.Warning(msg);
        internal static UnityModManager.ModEntry.ModLogger Logger { get; private set; }
        internal static ModManager<Core, Settings> Mod { get; private set; }
        internal static MenuManager Menu { get; private set; }
        internal static Settings Settings { get { return Mod.Settings; } }

        internal static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                Logger = modEntry.Logger;

                Mod = new ModManager<Core, Settings>();
                Menu = new MenuManager();
                modEntry.OnToggle = OnToggle;

                Translations.Load(MOD_FOLDER);
            }
            catch (Exception ex)
            {
                Error(ex);
                throw;
            }

            return true;
        }

        static bool OnToggle(UnityModManager.ModEntry modEntry, bool enabled)
        {
            if (enabled)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                Mod.Enable(modEntry, assembly);
                Menu.Enable(modEntry, assembly);
            }
            else
            {
                Menu.Disable(modEntry);
                Mod.Disable(modEntry, false);
                ReflectionCache.Clear();
            }
            return true;
        }

        internal static void OnGameReady()
        {
            CharacterRaceDefinition dwarfNames = DatabaseHelper.CharacterRaceDefinitions.Dwarf;
            dwarfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&DwarfFemaleName9Title");
            dwarfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&DwarfFemaleName10Title");
            dwarfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&DwarfFemaleName11Title");
            dwarfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&DwarfFemaleName12Title");
            dwarfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&DwarfFemaleName13Title");
            dwarfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&DwarfFemaleName14Title");
            dwarfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&DwarfFemaleName15Title");
            dwarfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&DwarfFemaleName16Title");
            dwarfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&DwarfFemaleName17Title");
            dwarfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&DwarfFemaleName18Title");
            dwarfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&DwarfFemaleName19Title");
            dwarfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&DwarfFemaleName20Title");
            dwarfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&DwarfMaleName10Title");
            dwarfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&DwarfMaleName11Title");
            dwarfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&DwarfMaleName12Title");
            dwarfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&DwarfMaleName13Title");
            dwarfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&DwarfMaleName14Title");
            dwarfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&DwarfMaleName15Title");
            dwarfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&DwarfMaleName16Title");
            dwarfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&DwarfMaleName17Title");
            dwarfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&DwarfMaleName18Title");
            dwarfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&DwarfMaleName19Title");
            dwarfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&DwarfMaleName20Title");
            dwarfNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&DwarfSurName8Title");
            dwarfNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&DwarfSurName9Title");
            dwarfNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&DwarfSurName10Title");
            dwarfNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&DwarfSurName11Title");
            dwarfNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&DwarfSurName12Title");
            dwarfNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&DwarfSurName13Title");
            dwarfNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&DwarfSurName14Title");
            dwarfNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&DwarfSurName15Title");
            dwarfNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&DwarfSurName16Title");
            dwarfNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&DwarfSurName17Title");
            dwarfNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&DwarfSurName18Title");
            dwarfNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&DwarfSurName19Title");
            dwarfNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&DwarfSurName20Title");

            CharacterRaceDefinition elfHighNames = DatabaseHelper.CharacterRaceDefinitions.ElfHigh;
            elfHighNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&ElfFemaleName17Title");
            elfHighNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&ElfFemaleName18Title");
            elfHighNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&ElfFemaleName19Title");
            elfHighNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&ElfFemaleName20Title");
            elfHighNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&ElfMaleName14Title");
            elfHighNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&ElfMaleName15Title");
            elfHighNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&ElfMaleName16Title");
            elfHighNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&ElfMaleName17Title");
            elfHighNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&ElfMaleName18Title");
            elfHighNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&ElfMaleName19Title");
            elfHighNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&ElfMaleName20Title");
            elfHighNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&ElfSurName18Title");
            elfHighNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&ElfSurName19Title");
            elfHighNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&ElfSurName20Title");

            CharacterRaceDefinition elfSylvanNames = DatabaseHelper.CharacterRaceDefinitions.ElfSylvan;
            elfSylvanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&SylvanElfFemaleName11Title");
            elfSylvanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&SylvanElfFemaleName12Title");
            elfSylvanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&SylvanElfFemaleName13Title");
            elfSylvanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&SylvanElfFemaleName14Title");
            elfSylvanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&SylvanElfFemaleName15Title");
            elfSylvanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&SylvanElfFemaleName16Title");
            elfSylvanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&SylvanElfFemaleName17Title");
            elfSylvanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&SylvanElfFemaleName18Title");
            elfSylvanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&SylvanElfFemaleName19Title");
            elfSylvanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&SylvanElfFemaleName20Title");
            elfSylvanNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&SylvanElfMaleName11Title");
            elfSylvanNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&SylvanElfMaleName12Title");
            elfSylvanNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&SylvanElfMaleName13Title");
            elfSylvanNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&SylvanElfMaleName14Title");
            elfSylvanNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&SylvanElfMaleName15Title");
            elfSylvanNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&SylvanElfMaleName16Title");
            elfSylvanNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&SylvanElfMaleName17Title");
            elfSylvanNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&SylvanElfMaleName18Title");
            elfSylvanNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&SylvanElfMaleName19Title");
            elfSylvanNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&SylvanElfMaleName20Title");
            elfSylvanNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&SylvanElfSurName11Title");
            elfSylvanNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&SylvanElfSurName12Title");
            elfSylvanNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&SylvanElfSurName13Title");
            elfSylvanNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&SylvanElfSurName14Title");
            elfSylvanNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&SylvanElfSurName15Title");
            elfSylvanNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&SylvanElfSurName16Title");
            elfSylvanNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&SylvanElfSurName17Title");
            elfSylvanNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&SylvanElfSurName18Title");
            elfSylvanNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&SylvanElfSurName19Title");
            elfSylvanNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&SylvanElfSurName20Title");

            CharacterRaceDefinition halfElfNames = DatabaseHelper.CharacterRaceDefinitions.HalfElf;
            halfElfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalfElfFemaleName6Title");
            halfElfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalfElfFemaleName7Title");
            halfElfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalfElfFemaleName8Title");
            halfElfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalfElfFemaleName9Title");
            halfElfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalfElfFemaleName10Title");
            halfElfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalfElfFemaleName11Title");
            halfElfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalfElfFemaleName12Title");
            halfElfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalfElfFemaleName13Title");
            halfElfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalfElfFemaleName14Title");
            halfElfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalfElfFemaleName15Title");
            halfElfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalfElfFemaleName16Title");
            halfElfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalfElfFemaleName17Title");
            halfElfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalfElfFemaleName18Title");
            halfElfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalfElfFemaleName19Title");
            halfElfNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalfElfFemaleName20Title");
            halfElfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalfElfMaleName11Title");
            halfElfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalfElfMaleName12Title");
            halfElfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalfElfMaleName13Title");
            halfElfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalfElfMaleName14Title");
            halfElfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalfElfMaleName15Title");
            halfElfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalfElfMaleName16Title");
            halfElfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalfElfMaleName17Title");
            halfElfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalfElfMaleName18Title");
            halfElfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalfElfMaleName19Title");
            halfElfNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalfElfMaleName20Title");
            halfElfNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HalfElfSurName14Title");
            halfElfNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HalfElfSurName15Title");
            halfElfNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HalfElfSurName16Title");
            halfElfNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HalfElfSurName17Title");
            halfElfNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HalfElfSurName18Title");
            halfElfNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HalfElfSurName19Title");
            halfElfNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HalfElfSurName20Title");

            CharacterRaceDefinition halflingNames = DatabaseHelper.CharacterRaceDefinitions.Halfling;
            halflingNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalflingFemaleName8Title");
            halflingNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalflingFemaleName9Title");
            halflingNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalflingFemaleName10Title");
            halflingNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalflingFemaleName11Title");
            halflingNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalflingFemaleName12Title");
            halflingNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalflingFemaleName13Title");
            halflingNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalflingFemaleName14Title");
            halflingNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalflingFemaleName15Title");
            halflingNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalflingFemaleName16Title");
            halflingNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalflingFemaleName17Title");
            halflingNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalflingFemaleName18Title");
            halflingNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalflingFemaleName19Title");
            halflingNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HalflingFemaleName20Title");
            halflingNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalflingMaleName7Title");
            halflingNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalflingMaleName8Title");
            halflingNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalflingMaleName9Title");
            halflingNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalflingMaleName10Title");
            halflingNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalflingMaleName11Title");
            halflingNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalflingMaleName12Title");
            halflingNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalflingMaleName13Title");
            halflingNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalflingMaleName14Title");
            halflingNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalflingMaleName15Title");
            halflingNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalflingMaleName16Title");
            halflingNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalflingMaleName17Title");
            halflingNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalflingMaleName18Title");
            halflingNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalflingMaleName19Title");
            halflingNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HalflingMaleName20Title");
            halflingNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HalflingSurName9Title");
            halflingNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HalflingSurName10Title");
            halflingNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HalflingSurName11Title");
            halflingNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HalflingSurName12Title");
            halflingNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HalflingSurName13Title");
            halflingNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HalflingSurName14Title");
            halflingNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HalflingSurName15Title");
            halflingNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HalflingSurName16Title");
            halflingNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HalflingSurName17Title");
            halflingNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HalflingSurName18Title");
            halflingNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HalflingSurName19Title");
            halflingNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HalflingSurName20Title");

            CharacterRaceDefinition humanNames = DatabaseHelper.CharacterRaceDefinitions.Human;
            humanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HumanFemaleName9Title");
            humanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HumanFemaleName10Title");
            humanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HumanFemaleName11Title");
            humanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HumanFemaleName12Title");
            humanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HumanFemaleName13Title");
            humanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HumanFemaleName14Title");
            humanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HumanFemaleName15Title");
            humanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HumanFemaleName16Title");
            humanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HumanFemaleName17Title");
            humanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HumanFemaleName18Title");
            humanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HumanFemaleName19Title");
            humanNames.RacePresentation.FemaleNameOptions.Add("Solastanomicon/&HumanFemaleName20Title");
            humanNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HumanMaleName14Title");
            humanNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HumanMaleName15Title");
            humanNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HumanMaleName16Title");
            humanNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HumanMaleName17Title");
            humanNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HumanMaleName18Title");
            humanNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HumanMaleName19Title");
            humanNames.RacePresentation.MaleNameOptions.Add("Solastanomicon/&HumanMaleName20Title");
            humanNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HumanSurName14Title");
            humanNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HumanSurName15Title");
            humanNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HumanSurName16Title");
            humanNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HumanSurName17Title");
            humanNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HumanSurName18Title");
            humanNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HumanSurName19Title");
            humanNames.RacePresentation.SurNameOptions.Add("Solastanomicon/&HumanSurName20Title");

        }
    }
}
