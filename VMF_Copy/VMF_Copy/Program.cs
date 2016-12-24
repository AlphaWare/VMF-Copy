using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace VMF_Copy
{
    /*
     * VMF Copy version 0.4
     * Written by AlphaWare141
     * Debugged by SharpOB
     * 
     * This version only copies texture maps
     * Bump, Normal, etc.. should be added!
     */

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //new VMF_COPY().Run(args);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FORM_MAIN());
        }
    }
    
    public class VMF_COPY_CONSOLE
    {

        public List<String> FILTER, MATERIALS, TEXTURES, FOUND_MATERIALS, FOUND_TEXTURES;
        public string VMF, FOLDER, GAME_FOLDER;
        public int FOUND_MATERIAL_COUNT, FOUND_TEXTURE_COUNT, MATERIAL_COUNT, TEXTURE_COUNT;
        string[] keys = new string[] { "$basetexture", "$basetexture2" };

        public void Run(string[] args)
        {
            log.Init();//Initialize log
            log.print("VMF Copy v0.4");
            Console.Write(@"
██╗   ██╗███╗   ███╗███████╗     ██████╗ ██████╗ ██████╗ ██╗   ██╗
██║   ██║████╗ ████║██╔════╝    ██╔════╝██╔═══██╗██╔══██╗╚██╗ ██╔╝
██║   ██║██╔████╔██║█████╗      ██║     ██║   ██║██████╔╝ ╚████╔╝ 
╚██╗ ██╔╝██║╚██╔╝██║██╔══╝      ██║     ██║   ██║██╔═══╝   ╚██╔╝  
 ╚████╔╝ ██║ ╚═╝ ██║██║         ╚██████╗╚██████╔╝██║        ██║   
  ╚═══╝  ╚═╝     ╚═╝╚═╝          ╚═════╝ ╚═════╝ ╚═╝        ╚═╝                                                                  
                                                            v0.4
");
            FILTER = new List<string>();
            if(File.Exists("vmfc_filter.txt"))//Checks if the file exists
            {
                StreamReader FILTER_FILE = new StreamReader("vmfc_filter.txt");
                string line;
                while ((line = FILTER_FILE.ReadLine()) != null)
                {
                    if(!line.Contains('#'))//if the line contains 
                    {
                        FILTER.Add(line.ToLower());
                    }
                    
                }
                Console.WriteLine("Filter:");
                log.print("Filter:");
                foreach (string f in FILTER)
                {
                    Console.Write(f + " - ");
                    log.print(f);
                }
                Console.Write("\n");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Missing vmfc_filter.txt!");
                log.print("Missing vmfc_filter.txt!");
                Console.ResetColor();
            }
            Console.WriteLine("------------------------------");
            Console.WriteLine("Usage: vmfcopy [VMF] [GAME FOLDER] [COPY TO FOLDER]");
            log.print("");
            Console.WriteLine();
            try
            {
                if (args[0] != null)//VMF File
                    VMF = args[0].Trim('"');

                if (args[1] != null)//Game folder
                    GAME_FOLDER = args[1].Trim('"');

                if (args[2] != null)//Copy to folder
                    FOLDER = args[2].Trim('"');
            }
            catch(IndexOutOfRangeException)
            {

            }
            catch (Exception)
            {

            }


            if (VMF == null)
            {
                while(true)
                {
                    Console.Write("VMF Path:");
                    VMF = Console.ReadLine().Trim('"');

                    if(File.Exists(VMF))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("File does exist!");
                        Console.ResetColor();
                        break;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("File does not exist!");
                    Console.ResetColor();
                }

            }
            else
            {

                if (!File.Exists(VMF))
                {
                    while (true)
                    {
                        Console.Write("VMF Path:");
                        VMF = Console.ReadLine().Trim('"');

                        if (File.Exists(VMF))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("File does exist!");
                            Console.ResetColor();
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("File does not exist!");
                        Console.ResetColor();
                    }

                }

            }

            if (GAME_FOLDER == null)
            {
                while (true)
                {
                    Console.Write("Game folder Path:");
                    GAME_FOLDER = Console.ReadLine().Trim('"');

                    if (Directory.Exists(GAME_FOLDER))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Folder does exist!");
                        Console.ResetColor();
                        break;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Folder does not exist!");
                    Console.ResetColor();
                }
            }
            else
            {
                
                if (!Directory.Exists(GAME_FOLDER))
                {
                    while (true)
                    {
                        Console.Write("Game folder Path:");
                        GAME_FOLDER = Console.ReadLine().Trim('"');

                        if (File.Exists(GAME_FOLDER))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Folder does exist!");
                            Console.ResetColor();
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Folder does not exist!");
                        Console.ResetColor();
                    }

                }
            }

            if (FOLDER == null)
            {
                while (!Directory.Exists(FOLDER))
                {
                    Console.Write("Copy to folder Path:");
                    FOLDER = Console.ReadLine().Trim('"');

                    if (Directory.Exists(FOLDER))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Folder does exist!\n");
                        Console.ResetColor();
                        break;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Folder does not exist!\n");
                    Console.ResetColor();
                }
            }
            else
            {
                if (!Directory.Exists(FOLDER))
                {
                    while (true)
                    {
                        Console.Write("VMF Path:");
                        FOLDER = Console.ReadLine().Trim('"');

                        if (Directory.Exists(FOLDER))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Folder does exist!");
                            Console.ResetColor();
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Folder does not exist!");
                        Console.ResetColor();
                    }

                }
            }
            FOLDER = FOLDER.TrimEnd('\\');
            FOLDER = FOLDER.TrimEnd('/');
            GAME_FOLDER = GAME_FOLDER.TrimEnd('\\');
            GAME_FOLDER = GAME_FOLDER.TrimEnd('/');

            Console.WriteLine("VMF Path:" + VMF);
            Console.WriteLine("Game folder:" + GAME_FOLDER);
            Console.WriteLine("Copy to folder:" + FOLDER);
            log.print("VMF Path:" + VMF);
            log.print("Game folder:" + GAME_FOLDER);
            log.print("Copy to folder:" + FOLDER);

            log.print("");
            Console.WriteLine();

            READ_VMF();
        }

        public void READ_VMF()
        {
            
            MATERIALS = new List<string>();
            TEXTURES = new List<string>();
            FOUND_MATERIALS = new List<string>();
            FOUND_TEXTURES = new List<string>();

            StreamReader VMF_FILE = new StreamReader(VMF);
            string line;
            while((line = VMF_FILE.ReadLine()) != null)
            {
                //Console.WriteLine(line);
                try
                {
                    switch (line.TrimStart().Split(' ')[0])
                    {
                        case "\"material\"": // "material" "DEV/DEV_BLENDMEASURE"
                            //Console.WriteLine(line);
                            if(!MATERIALS.Contains(line.Split('\"')[3].Trim(' ').Trim('\"')))
                            {
                                MATERIALS.Add(line.Split('\"')[3].Trim(' ').Trim('\"'));
                            }
                            break;
                    }
                }
                catch (IndexOutOfRangeException)
                {

                }
                catch (Exception)
                {

                }

            }
            foreach(string mat in MATERIALS)
            {
                /*
                 * What a mess...
                 * Should've used Path insted of doing this. :/
                 */

                if(!FILTER.Contains(mat.ToLower().Split('/')[mat.Split('/').Count()-1]))
                {
                    Console.Write("Material:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(GAME_FOLDER + "\\materials\\" + mat.ToLower().Replace('/', '\\') + ".vmt" + "\n");
                    Console.ResetColor();
                    log.print("Material:" + GAME_FOLDER + "\\materials\\" + mat.ToLower().Replace('/', '\\') + ".vmt");
                    if (File.Exists(GAME_FOLDER + "\\materials\\" + mat.ToLower().Replace('/', '\\') + ".vmt"))
                    {
                        FOUND_MATERIAL_COUNT++;
                        StreamReader MAT = new StreamReader(GAME_FOLDER + "\\materials\\" + mat.ToLower().Replace('/', '\\') + ".vmt");
                        string MAT_Line;
                        while ((line = MAT.ReadLine()) != null)
                        {
                            //Console.WriteLine(line.TrimEnd().TrimStart().Trim().Replace("\"",""));
                            switch (keys.FirstOrDefault<string>(s => line.TrimEnd().TrimStart().Trim().Replace("\"", "").Replace("\'", "").Contains(s)))
                            {
                                case "$basetexture":
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("          -$basetexture: " + line.TrimEnd().TrimStart().Trim().Replace('\"', ' ').Replace("   ", " ").Split(' ')[2].ToLower()+".vtf");
                                    log.print("          -$basetexture: " + line.TrimEnd().TrimStart().Trim().Replace('\"', ' ').Replace("   ", " ").Split(' ')[2].ToLower() + ".vtf");
                                    if (!FOUND_TEXTURES.Contains(line.TrimEnd().TrimStart().Trim().Replace('\"', ' ').Replace("   ", " ").Split(' ')[2] + ".vtf"))
                                    {
                                        FOUND_TEXTURES.Add(line.TrimEnd().TrimStart().Trim().Replace('\"', ' ').Replace("   ", " ").Replace("/", "\\").Split(' ')[2] + ".vtf");
                                        FOUND_TEXTURE_COUNT++;
                                    }
                                    Console.ResetColor();
                                    break;

                                case "$basetexture2":
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("           -$basetexture2: " + line.TrimEnd().TrimStart().Trim().Replace('\"', ' ').Replace("   ", " ").Split(' ')[2].ToLower() + ".vtf");
                                    log.print("          -$basetexture2: " + line.TrimEnd().TrimStart().Trim().Replace('\"', ' ').Replace("   ", " ").Split(' ')[2].ToLower() + ".vtf");
                                    if (!FOUND_TEXTURES.Contains(line.TrimEnd().TrimStart().Trim().Replace('\"', ' ').Replace("   ", " ").Split(' ')[2] + ".vtf"))
                                    {
                                        FOUND_TEXTURES.Add(line.TrimEnd().TrimStart().Trim().Replace('\"', ' ').Replace("   ", " ").Replace("/", "\\").Split(' ')[2] + ".vtf");
                                        FOUND_TEXTURE_COUNT++;
                                    }
                                    Console.ResetColor();
                                    break;

                                default:
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("          -" + line);
                                    log.print("          -" + line);
                                    Console.ResetColor();
                                    break;
                            }

                        }
                        FOUND_MATERIALS.Add(mat.Replace('/', '\\').ToLower() + ".vmt");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        log.print("Material file does not exist!");
                        Console.WriteLine("Material file does not exist!");
                        Console.ResetColor();
                    }

                }
                else
                {
                    Console.Write("Material:");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(GAME_FOLDER + "\\materials\\" + mat.ToLower().Replace('/', '\\') + ".vmt -FILTERED- " + "\n");
                    log.print(GAME_FOLDER + "\\materials\\" + mat.ToLower().Replace('/', '\\') + ".vmt -FILTERED- ");
                    Console.ResetColor();
                }

                log.print("");

            }
            COPY();
        }

        public void COPY()
        {
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Copying materials...");
            log.print("Copying materials...");
            Console.ResetColor();

            //Copy materials
            foreach (string mat in FOUND_MATERIALS)
            {
                string file = Path.GetFileName(mat);
                string folder = Path.GetDirectoryName(mat);
                string fullGamePathFolder = GAME_FOLDER + "\\materials\\" + folder;
                string fullFolderPathFolder = FOLDER + "\\materials\\" + folder;
                string fullGamePath = GAME_FOLDER + "\\materials\\" + folder + "\\" + file;
                string fulllFodlerPath = FOLDER + "\\materials\\" + folder + "\\" + file;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Copying material: ");
                log.print("Copying material: " + file);
                Console.ResetColor();
                Console.Write(file);
                
                //First check if the folder exists!
                if(!Directory.Exists(fullFolderPathFolder))
                {
                    Directory.CreateDirectory(fullFolderPathFolder);
                }

                //Copy the file
                try
                {
                    File.Copy(fullGamePath, fulllFodlerPath);
                    MATERIAL_COUNT++;
                }
                catch (Exception)
                {
                    try
                    {
                        File.Copy(fullGamePath, fulllFodlerPath,true);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" OVERWRITTEN! ");
                        Console.ResetColor();
                        MATERIAL_COUNT++;
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex);
                        log.print(""+ex);
                    }
                }

                Console.Write("\n");

            }

            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Copying textures...");
            log.print("Copying textures...");
            Console.ResetColor();

            //Copy textures
            foreach (string tex in FOUND_TEXTURES)
            {
                string file = Path.GetFileName(tex);
                string folder = Path.GetDirectoryName(tex);
                string fullGamePathFolder = GAME_FOLDER + "\\materials\\" + folder;
                string fullFolderPathFolder = FOLDER + "\\materials\\" + folder;
                string fullGamePath = GAME_FOLDER + "\\materials\\" + folder + "\\" + file;
                string fulllFodlerPath = FOLDER + "\\materials\\" + folder + "\\" + file;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Copying texture: ");
                log.print("Copying texture: " + file);
                Console.ResetColor();
                Console.Write(file);

                //First check if the folder exists!
                if (!Directory.Exists(fullFolderPathFolder))
                {
                    Directory.CreateDirectory(fullFolderPathFolder);
                }

                //Copy the file
                try
                {
                    File.Copy(fullGamePath, fulllFodlerPath);
                    TEXTURE_COUNT++;
                }
                catch (Exception)
                {
                    try
                    {
                        File.Copy(fullGamePath, fulllFodlerPath, true);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" OVERWRITTEN! ");
                        Console.ResetColor();
                        TEXTURE_COUNT++;
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex);
                        log.print("" + ex);
                    }
                }

                Console.Write("\n");
            }
            Console.WriteLine(@"");
            Console.WriteLine(@"══════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine(@"Finished!   Materials found:{0}    Materials copied:{1}/{0}    Textures found:{2}    Textures copied:{3}/{2}", FOUND_MATERIAL_COUNT, MATERIAL_COUNT, FOUND_TEXTURE_COUNT, TEXTURE_COUNT);
            Console.WriteLine(@"══════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine(@"Press any key to exit.");
            Console.ReadKey();
        }
    }

    public static class VMF_COPY_UI
    {
        private static int model_count, material_count, texture_count, cc_count, particle_count, sound_count;
        public static bool AbortWork, Debug=false;
        private static string vmf, gameDirectory, copyToDirectory;
        private static FORM_MAIN FM;
        
        private static ArrayList MODEL_COLLECTION, MATERIAL_COLLECTION,TEXTURE_COLLECTION, SOUND_COLLECTION;

        

        private static string StartWork()
        {
            //Models
            //Materials
            //Textures
            //Sounds
            //Color Correction
            //Particle
            MDL_PATTAREN.Read();

            MODEL_COLLECTION = new ArrayList();
            MATERIAL_COLLECTION = new ArrayList();
            SOUND_COLLECTION = new ArrayList();
            TEXTURE_COLLECTION = new ArrayList();

            if (!File.Exists(vmf))
                return vmf+ " does not exist!";

            if (!Directory.Exists(gameDirectory))
                return gameDirectory + " does not exist!";

            if (!Directory.Exists(copyToDirectory))
                return copyToDirectory + " does not exist!";

            using (var vmf_file = new StreamReader(vmf))
            {
                string VMF_LINE;
                while ((VMF_LINE = vmf_file.ReadLine()) != null)
                {
                    try
                    {
                        string key = VMF_LINE.Split('\"')[1];
                        //FM.PrintToLog(VMF_LINE.Split('\"')[1]);
                        switch (key)
                        {
                            case "model":
                                if(!MODEL_COLLECTION.Contains(VMF_LINE.Split('\"')[3].ToLower()))
                                {
                                    FM.PrintToLog("" + VMF_LINE.Split('\"')[3].ToLower(), 6);
                                    MODEL_COLLECTION.Add(VMF_LINE.Split('\"')[3].ToLower());
                                }
                                break;

                            case "material":
                                if(!MATERIAL_COLLECTION.Contains(VMF_LINE.Split('\"')[3].ToLower() + ".vmt"))
                                {
                                    FM.PrintToLog("" + VMF_LINE.Split('\"')[3].ToLower() + ".vmt", 7);
                                    MATERIAL_COLLECTION.Add(VMF_LINE.Split('\"')[3].ToLower() + ".vmt");
                                }
                                break;

                            case "message":
                                if (!SOUND_COLLECTION.Contains(VMF_LINE.Split('\"')[3].ToLower()))
                                {
                                    if("wav" == VMF_LINE.Split('\"')[3].ToLower().Split('.')[1])
                                    {
                                        FM.PrintToLog("" + VMF_LINE.Split('\"')[3].ToLower(), 8);
                                        SOUND_COLLECTION.Add(VMF_LINE.Split('\"')[3].ToLower());
                                    }
                                }
                                break;

                                //case "filename":
                                //    FM.PrintToLog("" + VMF_LINE.Split('\"')[3], 1);
                                //    break;
                        }

                    }
                    catch (Exception ex)
                    {
                        //return ex.ToString();
                    }
                }
            }

            foreach(string MDL in MODEL_COLLECTION)
            {
                if(!File.Exists(gameDirectory+"\\"+MDL))
                {
                    FM.PrintToLog(Path.GetFileName(MDL) +" does not exist!",2);
                    continue;
                }

                try
                {
                    using (var MDLFile = new StreamReader(gameDirectory + "\\" + MDL))
                    {
                        System.Text.Encoding TextEncoder = Encoding.ASCII;
                        string MDLHex = "";
                        //Console.BackgroundColor = ConsoleColor.White;
                        //Console.ForegroundColor = ConsoleColor.Black;

                        //if (Debug)
                        //    new FORM_MDL_HEX(MDLFile.ReadToEnd()).ShowDialog();

                        char[] values = MDLFile.ReadToEnd().ToCharArray();
                        foreach (char letter in values)
                        {
                            // Get the integral value of the character.
                            int value = Convert.ToInt32(letter);
                            // Convert the decimal value to a hexadecimal value in string form.
                            if ("FFFD" == String.Format("{0:X2}", value))//FFFD
                            {
                                MDLHex += "FF FD ";
                            }
                            else if (String.Format("{0:X2}", value).Count() > 2)
                            {
                                MDLHex += "?? ";
                            }
                            else
                            {
                                MDLHex += String.Format("{0:X2}", value) + " ";
                            }


                        }

                        foreach(string hex in MDL_PATTAREN.PATTAREN)
                        {
                            try
                            {
                                string[] hexs = { hex };
                                string splitHex = MDLHex.Split(hexs,StringSplitOptions.None)[1];
                                
                                try
                                {
                                    //Trun it back to ASCII
                                    string stringValue = "";
                                    try
                                    {
                                        //Console.WriteLine(splitHex.Replace(' ','-'));
                                        foreach (string hex_ in splitHex.TrimStart().TrimEnd().Split(' '))
                                        {
                                            if(hex_ == "00")
                                            {
                                                stringValue += System.Char.ConvertFromUtf32(Convert.ToInt32("20", 16));
                                            }
                                            else
                                            {
                                                stringValue += System.Char.ConvertFromUtf32(Convert.ToInt32(hex_, 16));
                                            }
                                            //Console.WriteLine(hex_);
                                            
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        FM.PrintToLog("" + ex, 2);
                                    }
                                    bool FoundFiles = false;
                                    string MatDirectory = "None";
                                    stringValue = stringValue.Replace("base", "").Replace("@idle", "").Replace("idle", "").Replace("body", "").TrimEnd().TrimStart();
                                    //Console.WriteLine(stringValue);
                                    foreach (string mat in stringValue.Split(' '))
                                    {
                                        Console.WriteLine(mat);
                                        if (mat.Contains('/') || mat.Contains('\\'))
                                        {
                                            if (Directory.Exists(gameDirectory+"\\materials\\"+ mat))
                                            {
                                                //FM.PrintToLog("Directory found! - " + gameDirectory + "\\materials\\" + mat, 3);
                                                MatDirectory = mat;
                                                //Console.WriteLine(gameDirectory + "\\materials\\" + mat);
                                            }
                                        }
                                    }

                                    if(MatDirectory != "None")
                                    {
                                        foreach (string mat in stringValue.Split(' '))
                                        {
                                            if (mat.Contains('/') || mat.Contains('\\'))
                                            {

                                            }
                                            else
                                            {
                                                if (File.Exists(gameDirectory + "\\materials\\" + MatDirectory + mat + ".vmt"))
                                                {
                                                    FoundFiles = true;
                                                    MATERIAL_COLLECTION.Add(MatDirectory + mat + ".vmt");
                                                    //Console.WriteLine(MatDirectory + mat + ".vmt");
                                                    //FM.PrintToLog("File found! - "+ MatDirectory + mat + ".vmt", 3);
                                                }
                                                else
                                                {
                                                    FM.PrintToLog("\\materials\\" + MatDirectory + mat + ".vmt does not exist!", 2);
                                                }
                                            }
                                        }
                                        break;
                                    }
                                    
                                    stringValue = "";

                                }
                                catch (Exception ex)
                                {

                                }

                            }
                            catch(Exception)
                            {

                            }
                        }
                        
                    }
                }
                catch(Exception ex)
                {

                }
            }

            foreach(string MAT in MATERIAL_COLLECTION)
            {
                string matFixed = MAT.Replace('/','\\');
                string[] keys = new string[] { "$basetexture", "$basetexture2" };
                //FM.PrintToLog("Mat:"+MAT,1);
                if (File.Exists(gameDirectory + "\\materials\\" + matFixed))
                {
                    StreamReader MATFile = new StreamReader(gameDirectory + "\\materials\\" + matFixed.ToLower());
                    string MAT_Line;
                    while ((MAT_Line = MATFile.ReadLine()) != null)
                    {
                        MAT_Line = MAT_Line.ToLower();
                        Console.WriteLine(MAT_Line);
                        //Console.WriteLine(line.TrimEnd().TrimStart().Trim().Replace("\"",""));
                        switch (keys.FirstOrDefault<string>(s => MAT_Line.TrimEnd().TrimStart().Trim().Replace("\"", "").Replace("\'", "").Contains(s)))
                        {
                            case "$basetexture":
                                //Console.ForegroundColor = ConsoleColor.Yellow;
                                //Console.WriteLine("          -$basetexture: " + MAT_Line.TrimEnd().TrimStart().Trim().Replace('\"', ' ').Replace("   ", " ").Split(' ')[2].ToLower() + ".vtf");
                                //log.print("          -$basetexture: " + MAT_Line.TrimEnd().TrimStart().Trim().Replace('\"', ' ').Replace("   ", " ").Split(' ')[2].ToLower() + ".vtf");
                                if (!TEXTURE_COLLECTION.Contains(MAT_Line.TrimEnd().TrimStart().Trim().Replace('\"', ' ').Replace("   ", " ").Split(' ')[2] + ".vtf"))
                                {
                                    
                                    TEXTURE_COLLECTION.Add(MAT_Line.TrimEnd().TrimStart().Trim().Replace('\"', ' ').Replace("   ", " ").Replace("/", "\\").Split(' ')[2] + ".vtf");
                                    //FOUND_TEXTURE_COUNT++;
                                }
                                //Console.ResetColor();
                                break;

                            case "$basetexture2":
                                //Console.ForegroundColor = ConsoleColor.Yellow;
                                //Console.WriteLine("           -$basetexture2: " + MAT_Line.TrimEnd().TrimStart().Trim().Replace('\"', ' ').Replace("   ", " ").Split(' ')[2].ToLower() + ".vtf");
                                //log.print("          -$basetexture2: " + MAT_Line.TrimEnd().TrimStart().Trim().Replace('\"', ' ').Replace("   ", " ").Split(' ')[2].ToLower() + ".vtf");
                                if (!TEXTURE_COLLECTION.Contains(MAT_Line.TrimEnd().TrimStart().Trim().Replace('\"', ' ').Replace("   ", " ").Split(' ')[2] + ".vtf"))
                                {
                                    TEXTURE_COLLECTION.Add(MAT_Line.TrimEnd().TrimStart().Trim().Replace('\"', ' ').Replace("   ", " ").Replace("/", "\\").Split(' ')[2] + ".vtf");
                                    //FOUND_TEXTURE_COUNT++;
                                }
                                Console.ResetColor();
                                break;

                            default:
                                //Console.ForegroundColor = ConsoleColor.DarkGray;
                                //Console.WriteLine("          -" + line);
                                //log.print("          -" + line);
                                //Console.ResetColor();
                                break;
                        }

                    }
                    MATFile.Close();
                }
                else
                {
                    FM.PrintToLog("\\materials\\" + matFixed + " does not exist!", 2);
                }
            }

            foreach(string tex in TEXTURE_COLLECTION)
            {
                Console.WriteLine(tex);
            }

            return "Done";

        }

        public static void RUN(string vmff, string gamefolder, string folder, string filter, FORM_MAIN MainForm)
        {
            vmf = vmff;
            gameDirectory = gamefolder;
            copyToDirectory = folder;
            FM = MainForm;

            FM.PrintToLog("Starting work....");
            System.Threading.Thread th = new System.Threading.Thread(delegate() { FM.PrintToLog(StartWork()); });
            th.Start();
        }

    }

    public static class VMF_COPY_RUN
    {
        public static void Run(string vmf, string game, string folder, string filter, FORM_MAIN MF)
        {
            Thread th = new Thread(delegate () { MF.PrintToLog(VMF_COPY.Run(vmf, game, folder, filter, MF),17); MF.EnableRunNControls(); });
            th.Start();
        }
    }

    public static class VMF_COPY
    {
        public static string Run(string vmf, string game, string folder, string filter, FORM_MAIN MF)
        {
            CONTENT_COLLECTION.Init();
            VMF_READER.Read(vmf);
            MDL_READER.Read(game);
            VMT_READER.Read(game);

            if (MF.CopyMDL)
                MF.PrintToLog("Copying models...",6);
            foreach(string MDL in CONTENT_COLLECTION.GetModels())
            {
                if(MF.CopyMDL)
                {
                    if (File.Exists(game + "\\" + MDL))
                    {
                        string Dir = Path.GetDirectoryName(MDL);

                        if (!Directory.Exists(Dir))
                            Directory.CreateDirectory(folder + "\\" + Dir);

                        if (File.Exists(folder + "\\" + MDL))
                        {
                            if (MF.Override)
                            {
                                File.Copy(game + "\\" + MDL, folder + "\\" + MDL, true);
                                MF.PrintToLog(MDL, 3);
                            }
                            else
                            {
                                MF.PrintToLog(MDL + " Already exist", 1);
                            }
                        }
                        else
                        {
                            File.Copy(game + "\\" + MDL, folder + "\\" + MDL, true);
                            MF.PrintToLog(MDL, 3);
                        }
                    }
                    else
                    {
                        MF.PrintToLog(MDL + " does not exist!", 4);
                    }
                }
                

            }

            if (MF.CopyVMT)
                MF.PrintToLog("Copying materials...", 7);
            foreach (string MAT in CONTENT_COLLECTION.GetMaterials())
            {
                if(MF.CopyVMT)
                {
                    if (File.Exists(game + "\\" + MAT))
                    {
                        string Dir = Path.GetDirectoryName(MAT);

                        if (!Directory.Exists(Dir))
                            Directory.CreateDirectory(folder + "\\" + Dir);

                        if (File.Exists(folder + "\\" + MAT))
                        {
                            if (MF.Override)
                            {
                                File.Copy(game + "\\" + MAT, folder + "\\" + MAT, true);
                                MF.PrintToLog(MAT, 3);
                            }
                            else
                            {
                                MF.PrintToLog(MAT + " Already exist", 1);
                            }
                        }
                        else
                        {
                            File.Copy(game + "\\" + MAT, folder + "\\" + MAT, true);
                            MF.PrintToLog(MAT, 3);
                        }
                    }
                    else
                    {
                        MF.PrintToLog(MAT + " does not exist!", 4);
                    }

                }

            }

            if (MF.CopyVTF)
                MF.PrintToLog("Copying textures...", 9);
            foreach (string TEX in CONTENT_COLLECTION.GetTextures())
            {
                if(MF.CopyVTF)
                {
                    if (File.Exists(game + "\\" + TEX))
                    {
                        string Dir = Path.GetDirectoryName(TEX);

                        if (!Directory.Exists(Dir))
                            Directory.CreateDirectory(folder + "\\" + Dir);

                        if (File.Exists(folder + "\\" + TEX))
                        {
                            if (MF.Override)
                            {
                                File.Copy(game + "\\" + TEX, folder + "\\" + TEX, true);
                                MF.PrintToLog(TEX, 3);
                            }
                            else
                            {
                                MF.PrintToLog(TEX + " Already exist", 1);
                            }
                        }
                        else
                        {
                            File.Copy(game + "\\" + TEX, folder + "\\" + TEX, true);
                            MF.PrintToLog(TEX, 3);
                        }
                    }
                    else
                    {
                        MF.PrintToLog(TEX + " does not exist!", 4);
                    }
                }
                

            }

            if (MF.CopyWAV)
                MF.PrintToLog("Copying sounds...", 8);
            foreach (string SND in CONTENT_COLLECTION.GetSounds())
            {
                if(MF.CopyWAV)
                {
                    if (File.Exists(game + "\\" + SND))
                    {
                        string Dir = Path.GetDirectoryName(SND);

                        if (!Directory.Exists(Dir))
                            Directory.CreateDirectory(folder + "\\" + Dir);

                        if (File.Exists(folder + "\\" + SND))
                        {
                            if (MF.Override)
                            {
                                File.Copy(game + "\\" + SND, folder + "\\" + SND, true);
                                MF.PrintToLog(SND, 3);
                            }
                            else
                            {
                                MF.PrintToLog(SND + " Already exist", 1);
                            }
                        }
                        else
                        {
                            File.Copy(game + "\\" + SND, folder + "\\" + SND, true);
                            MF.PrintToLog(SND, 3);
                        }
                    }
                    else
                    {
                        MF.PrintToLog(SND + " does not exist!", 4);
                    }
                }
                

            }

            return "Done";
        }
    }

    public static class CONTENT_COLLECTION
    {
        private static ArrayList MODEL_COLLECTION;
        private static ArrayList MATERIAL_COLLECTION;
        private static ArrayList TEXTURE_COLLECTION;
        private static ArrayList SOUND_COLLECTION;

        public static void Init()
        {
            MODEL_COLLECTION = new ArrayList();
            MATERIAL_COLLECTION = new ArrayList();
            TEXTURE_COLLECTION = new ArrayList();
            SOUND_COLLECTION = new ArrayList();
        }

        public static void AddModel(string mdl)
        {
            MODEL_COLLECTION.Add(mdl);
        }

        public static void AddMaterial(string vmt)
        {
            MATERIAL_COLLECTION.Add(vmt);
        }

        public static void AddTexture(string vtf)
        {
            TEXTURE_COLLECTION.Add(vtf);
        }

        public static void AddSound(string wav)
        {
            SOUND_COLLECTION.Add(wav);
        }

        public static ArrayList GetModels()
        {
            return MODEL_COLLECTION;
        }

        public static ArrayList GetMaterials()
        {
            return MATERIAL_COLLECTION;
        }

        public static ArrayList GetTextures()
        {
            return TEXTURE_COLLECTION;
        }

        public static ArrayList GetSounds()
        {
            return SOUND_COLLECTION;
        }

        public static bool ContainsCurrentMaterial(string obj)
        {
            return MATERIAL_COLLECTION.Contains(obj);
        }

        public static bool ContainsCurrentModel(string obj)
        {
            return MODEL_COLLECTION.Contains(obj);
        }

        public static bool ContainsCurrentTexture(string obj)
        {
            return TEXTURE_COLLECTION.Contains(obj);
        }

        public static bool ContainsCurrentSound(string obj)
        {
            return SOUND_COLLECTION.Contains(obj);
        }
    }

    public static class MDL_READER
    {
        static bool debug = false;
        public static string Read(string gamepath)
        {
            MDL_PATTAREN.Read();
            foreach(string mdl in CONTENT_COLLECTION.GetModels())
            {
                try
                {
                   if(File.Exists(gamepath + "\\" + mdl))
                    {
                        FileStream MDL = new FileStream(gamepath + "\\" + mdl, FileMode.Open, FileAccess.Read);
                        byte[] data = new byte[MDL.Length];
                        MDL.Read(data, 0, System.Convert.ToInt32(MDL.Length));
                        MDL.Close();
                        string HEX = BitConverter.ToString(data).Replace('-', ' ');
                        if (debug)
                            new FORM_MDL_HEX(data).ShowDialog();
                        foreach (string pat in MDL_PATTAREN.PATTAREN)
                        {

                            if (HEX.Contains(pat))
                            {
                                string[] sp = { pat };
                                string fixedhex = HEX.Split(sp, StringSplitOptions.None)[1];

                                if (HexToString(fixedhex) != "?")
                                {
                                    if (HexToString(fixedhex).Contains('\\'))
                                    {
                                        if (!HexToString(fixedhex).Contains(".mdl"))
                                        {
                                            string MatDirectory = HexToString(fixedhex).Split(' ')[HexToString(fixedhex).Split(' ').Count() - 1];
                                            string[] Mats = HexToString(fixedhex).Split(' ');
                                            foreach (string mat in Mats)
                                            {
                                                if (mat != MatDirectory)
                                                {
                                                    CONTENT_COLLECTION.AddMaterial("materials\\" + MatDirectory + mat + ".vmt");
                                                }
                                            }
                                            break;
                                        }

                                    }

                                }
                            }
                        }
                    }
                   else
                    {
                        Console.WriteLine(mdl+" does not exist!");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Exception on MDL_READER! ("+ex.Message+")");
                }
                
            }
            return "";
        }

        public static string HexToString(string MDLhex)
        {
            try
            {
                string ascii = "";
                string[] hexValuesSplit = MDLhex.TrimStart().TrimEnd().Split(' ');
                foreach (String hex in hexValuesSplit)
                {
                    //Console.WriteLine(hex);
                    if(hex == "00")
                    {
                        int value = Convert.ToInt32("20", 16);
                        ascii += (char)value;
                    }
                    else
                    {
                        int value = Convert.ToInt32(hex, 16);
                        ascii += (char)value;
                    }
                    
                    ////string stringValue = System.Char.ConvertFromUtf32(value);
                    
                    
                }
                
                return ascii.Replace("idle","").Replace("@idle", "").Replace("body", "").Replace("default", "").Replace("@", "").Replace("base", "").Replace("studio", "").TrimStart().TrimEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "?";
            }
        }
    }

    public static class VMT_READER
    {
        public static void Read(string game)
        {
            foreach(string mat in CONTENT_COLLECTION.GetMaterials())
            {
                
                if(File.Exists(game + "\\" + mat))
                {
                    using (var VMT = new StreamReader(game + "\\" + mat))
                    {
                        string line = "";
                        while ((line = VMT.ReadLine()) != null)
                        {
                            try
                            {
                                string key = line.Split('$')[1].Split('\"')[0].ToLower().TrimEnd().TrimStart();
                                switch(key)
                                {
                                    case "basetexture":
                                        CONTENT_COLLECTION.AddTexture("materials\\" + line.Split('\"')[3].Replace('/', '\\') + ".vtf");
                                        break;

                                    case "basetexture2":
                                        CONTENT_COLLECTION.AddTexture("materials\\" + line.Split('\"')[3].Replace('/', '\\') + ".vtf");
                                        break;
                                }
                            }
                            catch(Exception)
                            {

                            }
                        }
                        VMT.Close();
                    }
                }
            }
        }
    }

    public static class VMF_READER
    {
        public static void Read(string vmf)
        {
            StreamReader VMF = new StreamReader(vmf);
            string line;
            while((line = VMF.ReadLine()) != null)
            {
                try
                {
                    string key = line.Split('\"')[1];
                    
                    switch (key)
                    {
                        case "material":
                            if(!CONTENT_COLLECTION.ContainsCurrentMaterial("materials\\"+ line.Split('\"')[3].ToLower().Replace('/','\\') + ".vmt"))
                            {
                                CONTENT_COLLECTION.AddMaterial("materials\\" + line.Split('\"')[3].ToLower().Replace('/', '\\') + ".vmt");
                            }
                            break;

                        case "model":

                            if(!CONTENT_COLLECTION.ContainsCurrentModel(line.Split('\"')[3].ToLower().Replace('/', '\\')))
                            {
                                CONTENT_COLLECTION.AddModel(line.Split('\"')[3].ToLower().Replace('/', '\\'));
                            }
                            break;

                        case "message"://WAV Only
                            if(line.Split('\"')[3].ToLower().Contains(".wav"))
                            {
                                if(!CONTENT_COLLECTION.ContainsCurrentSound("sounds\\"+line.Split('\"')[3].ToLower().Replace('/', '\\')))
                                {
                                    CONTENT_COLLECTION.AddSound("sounds\\" + line.Split('\"')[3].ToLower().Replace('/', '\\'));
                                }
                            }
                            break;
                    }
                }
                catch(Exception)
                {

                }

            }
            VMF.Close();
        }
    }



    [Serializable]
    public static class MDL_PATTAREN
    {
        public static ArrayList PATTAREN = new ArrayList();
        private static IFormatter format = new BinaryFormatter();

        public static void Write(string hex)
        {
            PATTAREN.Add(hex);
            Stream stream = new FileStream("patterns.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            format.Serialize(stream, PATTAREN);
            stream.Close();
        }

        public static void Read()
        {
            try
            {
                Stream stream = new FileStream("patterns.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                PATTAREN = (ArrayList)format.Deserialize(stream);
                stream.Close();
            }
            catch(Exception)
            {
                
            }

        }
    }

    public static class log
    {
        private static StreamWriter Logger;
        public static void Init()
        {
            Logger = new StreamWriter("vmfc_log.txt");
            Logger.AutoFlush = true;
        }
        public static void print(string text)
        {
            Logger.WriteLine(text);
        }
    }

}
