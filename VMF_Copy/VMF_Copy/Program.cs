using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

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
        static void Main(string[] args)
        {
            new VMF_COPY().Run(args);
        }
    }
    
    public class VMF_COPY
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
