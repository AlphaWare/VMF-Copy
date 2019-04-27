using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEAReader
{
    /// <summary>
    /// Source Engine Assets Reader
    /// Used for reading Valve Map Format(VMF), Valve Texture File (VTF), Valve Material Type (VTM), Source Engine Model Format (MDL)
    /// This library is in very early stage
    /// </summary>
    public class SEAR
    {
        const bool verbose = false;
        public StringCollection MISSING_MODELS = new StringCollection();
        public StringCollection MISSING_MATERIALS = new StringCollection();
        public StringCollection MISSING_TEXTURES = new StringCollection();
        public StringCollection MISSING_SOUNDS = new StringCollection();
        public StringCollection MISSING_COLOR_CORRECTIONS = new StringCollection();
        public StringCollection MISSING_PARTICLES = new StringCollection();

        private WORLD_SOLID cSOLID;
        private WORLD_SOLID_SIDE cSIDE;
        private WORLD_ENTITY cENTITY;

        public VMF LoadVMF(string path, string[] SOURCES)
        {
            
            if (!File.Exists(path))
                throw new FileNotFoundException();

            var newvmf = new VMF();

            using (var vmf = new StreamReader(path))
            {
                string line;
                while((line = vmf.ReadLine()) != null)
                {
                    string[] keyXvalue = line.TrimStart().Replace("\"","").Split(' ');
                    if(keyXvalue.Length > 1)
                    {
                        if(cSOLID != null)
                        {
                            if(cSIDE != null)
                            {
                                switch (keyXvalue[0])
                                {
                                    case "id":
                                        cSIDE.id = keyXvalue[1];
                                        break;

                                    case "material":
                                        cSIDE.MATERIAL = keyXvalue[1];
                                        newvmf.AddMaterial("materials\\"+keyXvalue[1].Replace('/', '\\').ToLower()+".vmt");
                                        break;
                                }
                            }

                        }

                        if (cENTITY != null)
                        {
                            switch (keyXvalue[0])
                            {
                                case "id":
                                    cENTITY.id = keyXvalue[1];
                                    break;

                                case "classname":
                                    cENTITY.classname = keyXvalue[1];
                                    break;

                                case "material":
                                    cENTITY.material = keyXvalue[1];
                                    break;

                                case "model":
                                    cENTITY.model = keyXvalue[1];
                                    break;

                                case "targetname":
                                    cENTITY.targetname = keyXvalue[1];
                                    break;

                                case "message":
                                    cENTITY.message = keyXvalue[1];
                                    break;

                                case "effect_name":
                                    cENTITY.effect_name = keyXvalue[1];
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (keyXvalue[0])
                        {
                            case "versioninfo":

                                break;

                            case "visgroups":

                                break;

                            case "viewsettings":

                                break;

                            case "world":

                                break;

                            case "solid":
                                if (cSOLID != null)
                                    newvmf.AddSolid(cSOLID);

                                cSOLID = new WORLD_SOLID();
                                cENTITY = null;
                                break;

                            case "side":
                                if (cSIDE != null)
                                    cSOLID.AddSide(cSIDE);

                                cSIDE = new WORLD_SOLID_SIDE();
                                cENTITY = null;
                                break;

                            case "entity":
                                if (cSIDE != null)
                                    cSOLID.AddSide(cSIDE);

                                if (cSOLID != null)
                                    newvmf.AddSolid(cSOLID);

                                if (cENTITY != null)
                                    newvmf.AddEntity(cENTITY);

                                cENTITY = new WORLD_ENTITY();
                                cSOLID = null;
                                cSIDE = null;

                                break;

                            case "cameras":
                                if (cSIDE != null)
                                    cSOLID.AddSide(cSIDE);

                                if (cSOLID != null)
                                    newvmf.AddSolid(cSOLID);

                                if (cENTITY != null)
                                    newvmf.AddEntity(cENTITY);

                                cENTITY = null;
                                cSOLID = null;
                                cSIDE = null;

                                break;
                        }
                    }
                }

                foreach(WORLD_ENTITY ENT in newvmf.GetEntities())
                {
                    switch (ENT.classname)
                    {
                        case "prop_detail":
                            newvmf.AddModel(ENT.model);
                            break;

                        case "prop_door_rotating":
                            newvmf.AddModel(ENT.model);
                            break;

                        case "prop_dynamic":
                            newvmf.AddModel(ENT.model);
                            break;

                        case "prop_dynamic_ornament":
                            newvmf.AddModel(ENT.model);
                            break;

                        case "prop_physics_override":
                            newvmf.AddModel(ENT.model);
                            break;

                        case "prop_physics_multiplayer":
                            newvmf.AddModel(ENT.model);
                            break;

                        case "prop_physics":
                            newvmf.AddModel(ENT.model);
                            break;

                        case "prop_dynamic_override":
                            newvmf.AddModel(ENT.model);
                            break;

                        case "prop_thumper":
                            newvmf.AddModel(ENT.model);
                            break;

                        case "prop_static":
                            newvmf.AddModel(ENT.model);
                            break;

                        case "prop_scalable":
                            newvmf.AddModel(ENT.model);
                            break;

                        case "prop_ragdoll":
                            newvmf.AddModel(ENT.model);
                            break;

                        case "prop_vehicle":
                            newvmf.AddModel(ENT.model);
                            break;

                        case "prop_vehicle_airboat":
                            newvmf.AddModel(ENT.model);
                            break;

                        case "ambient_generic":
                            newvmf.AddSounds("sound\\"+ENT.message);
                            break;

                        case "color_correction":
                            newvmf.AddColorCorrection(ENT.targetname);
                            break;

                        case "info_particle_system":
                            newvmf.AddPArticle(ENT.effect_name);
                            break;
                    }

                }

                vmf.Close();
            }

            foreach (var MODEL in newvmf.GetModels())
            {
                bool MODEL_FOUND = false;
                foreach (string SOURCE_PATH in SOURCES)
                {
                    string FULL_MODEL_PATH = SOURCE_PATH + "\\" + MODEL;
                    if (verbose)
                        Console.WriteLine($"MODEL : {FULL_MODEL_PATH}");
                    if (File.Exists(FULL_MODEL_PATH))
                    {
                        MODEL_FOUND = true;

                        var MDL = LoadMDL(FULL_MODEL_PATH);
                        foreach (var MAT in MDL.materials)
                        {
                            newvmf.AddMaterial(MAT);
                        }
                    }
                }

                if (!MODEL_FOUND && !MISSING_MODELS.Contains(MODEL))
                    MISSING_MODELS.Add(MODEL);
            }

            foreach (var MATERIAL in newvmf.GetMaterials())
            {
                bool MATERIAL_FOUND = false;
                foreach (string SOURCE_PATH in SOURCES)
                {
                    string FULL_MATERIAL_PATH = SOURCE_PATH + "\\" + MATERIAL;
                    if (verbose)
                        Console.WriteLine($"MATERIAL : {FULL_MATERIAL_PATH}");
                    if (File.Exists(FULL_MATERIAL_PATH))
                    {
                        MATERIAL_FOUND = true;

                        var MDL = LoadVMT(FULL_MATERIAL_PATH);
                        foreach (var TEX in MDL.TEXTURES)
                        {
                            string FULL_TEXTURE_PATH = SOURCE_PATH + "\\" + "materials\\" + TEX.Replace("/","\\");
                            bool TEXTURE_FOUND = false;
                            if(File.Exists(FULL_TEXTURE_PATH))
                            {
                                if (verbose)
                                    Console.WriteLine($"TEXTURE : {FULL_TEXTURE_PATH}");

                                TEXTURE_FOUND = true;
                                newvmf.AddTextures("materials\\" + TEX.Replace("/", "\\"));
                            }

                            if (!TEXTURE_FOUND && !MISSING_TEXTURES.Contains("materials\\" + TEX.Replace("/", "\\")))
                                MISSING_TEXTURES.Add("materials\\" + TEX.Replace("/", "\\"));
                        }
                    }
                }

                if (!MATERIAL_FOUND && !MISSING_MATERIALS.Contains(MATERIAL))
                    MISSING_MATERIALS.Add(MATERIAL);
            }

            return newvmf;
        }

        public MDL LoadMDL(string path)
        {
            StringCollection MATERIALS = new StringCollection();
            int offset = 0;
            int INT_SIZE = sizeof(int);
            int CHAR_SIZE = sizeof(char);
            int FLOAT_SIZE = sizeof(float);
            int VECTOR_SIZE = 12;
            int MDL_SIZE = 0;

            if (!File.Exists(path))
                throw new FileNotFoundException();

            byte[] bytes = File.ReadAllBytes(path);
            MDL_SIZE = bytes.Length;

            byte[] bID = new byte[INT_SIZE],
                bVERSION = new byte[INT_SIZE],
                bCHECKSUM = new byte[INT_SIZE],
                bNAME = new byte[64],
                bFLAGS = new byte[INT_SIZE],
                bBONE_COUNT = new byte[INT_SIZE],
                bBONE_OFFSET = new byte[INT_SIZE],
                bBONE_CONTROLLER_COUNT = new byte[INT_SIZE],
                bBONE_CONTROLLER_OFFSET = new byte[INT_SIZE],
                bHITBOX_COUNT = new byte[INT_SIZE],
                bHITBOX_OFFSET = new byte[INT_SIZE],
                bLOCALANIM_COUNT = new byte[INT_SIZE],
                bLOCALANIM_OFFSET = new byte[INT_SIZE],
                bLOCALSEQ_COUNT = new byte[INT_SIZE],
                bLOCALSEQ_OFFSET = new byte[INT_SIZE],
                bACTIVITY_LIST_VERSION = new byte[INT_SIZE],
                bEVENTS_INDEXED = new byte[INT_SIZE],
                bTEXTURE_COUNT = new byte[INT_SIZE],
                bTEXTURE_OFFSET = new byte[INT_SIZE];

            Array.ConstrainedCopy(bytes, offset, bID, 0, INT_SIZE);
            offset += INT_SIZE;

            Array.ConstrainedCopy(bytes, offset, bVERSION, 0, INT_SIZE);
            offset += INT_SIZE;

            Array.ConstrainedCopy(bytes, offset, bCHECKSUM, 0, INT_SIZE);
            offset += INT_SIZE;

            Array.ConstrainedCopy(bytes, offset, bNAME, 0, 64);
            offset += CHAR_SIZE * 64;

            //Skip on the vetrors
            offset += VECTOR_SIZE;

            Array.ConstrainedCopy(bytes, offset, bFLAGS, 0, INT_SIZE);
            offset += INT_SIZE;

            Array.ConstrainedCopy(bytes, offset, bBONE_COUNT, 0, INT_SIZE);
            offset += INT_SIZE;

            Array.ConstrainedCopy(bytes, offset, bBONE_OFFSET, 0, INT_SIZE);
            offset += INT_SIZE;

            Array.ConstrainedCopy(bytes, offset, bBONE_CONTROLLER_COUNT, 0, INT_SIZE);
            offset += INT_SIZE;

            Array.ConstrainedCopy(bytes, offset, bBONE_CONTROLLER_OFFSET, 0, INT_SIZE);
            offset += INT_SIZE;

            Array.ConstrainedCopy(bytes, offset, bHITBOX_COUNT, 0, INT_SIZE);
            offset += INT_SIZE;

            Array.ConstrainedCopy(bytes, offset, bHITBOX_OFFSET, 0, INT_SIZE);
            offset += INT_SIZE;

            Array.ConstrainedCopy(bytes, offset, bLOCALANIM_COUNT, 0, INT_SIZE);
            offset += INT_SIZE;

            Array.ConstrainedCopy(bytes, offset, bLOCALANIM_OFFSET, 0, INT_SIZE);
            offset += INT_SIZE;

            Array.ConstrainedCopy(bytes, offset, bLOCALSEQ_COUNT, 0, INT_SIZE);
            offset += INT_SIZE;

            Array.ConstrainedCopy(bytes, offset, bLOCALSEQ_OFFSET, 0, INT_SIZE);
            offset += INT_SIZE;

            Array.ConstrainedCopy(bytes, offset, bACTIVITY_LIST_VERSION, 0, INT_SIZE);
            offset += INT_SIZE;

            Array.ConstrainedCopy(bytes, offset, bEVENTS_INDEXED, 0, INT_SIZE);
            offset += INT_SIZE;

            Array.ConstrainedCopy(bytes, offset, bTEXTURE_COUNT, 0, INT_SIZE);
            offset += INT_SIZE;

            Array.ConstrainedCopy(bytes, offset, bTEXTURE_OFFSET, 0, INT_SIZE);
            offset += INT_SIZE;

            int ID = BitConverter.ToInt32(bID, 0);
            int VERSION = BitConverter.ToInt32(bVERSION, 0);
            int CHECKSUM = BitConverter.ToInt32(bCHECKSUM, 0);
            string NAME = System.Text.Encoding.UTF8.GetString(bNAME);
            int FLAGS = BitConverter.ToInt32(bFLAGS, 0);
            int bone_count = BitConverter.ToInt32(bBONE_COUNT, 0);
            int bone_offset = BitConverter.ToInt32(bBONE_OFFSET, 0);
            int bonecontroller_count = BitConverter.ToInt32(bBONE_CONTROLLER_COUNT, 0);
            int bonecontroller_offset = BitConverter.ToInt32(bBONE_CONTROLLER_OFFSET, 0);
            int hitbox_count = BitConverter.ToInt32(bHITBOX_COUNT, 0);
            int hitbox_offset = BitConverter.ToInt32(bHITBOX_OFFSET, 0);
            int localanim_count = BitConverter.ToInt32(bLOCALANIM_COUNT, 0);
            int localanim_offset = BitConverter.ToInt32(bLOCALANIM_OFFSET, 0);
            int localseq_count = BitConverter.ToInt32(bLOCALSEQ_COUNT, 0);
            int localseq_offset = BitConverter.ToInt32(bLOCALSEQ_OFFSET, 0);
            int activitylistversion = BitConverter.ToInt32(bACTIVITY_LIST_VERSION, 0);
            int eventsindexed = BitConverter.ToInt32(bEVENTS_INDEXED, 0);
            int texture_count = BitConverter.ToInt32(bTEXTURE_COUNT, 0);
            int texture_offset = BitConverter.ToInt32(bTEXTURE_OFFSET, 0);

            if (verbose)
            {
                Console.WriteLine("--------------------[MDL INFO]--------------------");
                Console.WriteLine($"Name:{NAME}");
                Console.WriteLine($"ID:{ID}");
                Console.WriteLine($"Version:{VERSION}");
                Console.WriteLine($"Checksum:{CHECKSUM}");
                Console.WriteLine($"Flags:{FLAGS}");
                Console.WriteLine();
                Console.WriteLine("--------------------[MATERIALS]-------------------");
            }


            byte[] btnoffset = new byte[INT_SIZE];
            Array.ConstrainedCopy(bytes, texture_offset, btnoffset, 0, INT_SIZE);
            int texture_names_offset = BitConverter.ToInt32(btnoffset, 0);
            int texture_names_position = texture_offset + texture_names_offset;
            int texture_names_size = MDL_SIZE - (texture_offset + texture_names_offset);
            byte[] texturenames = new byte[texture_names_size];
            Array.ConstrainedCopy(bytes, texture_names_position, texturenames, 0, texture_names_size);
            string[] names = System.Text.Encoding.UTF8.GetString(texturenames).Split('\0');
            string materialsPath = "materials\\";
            foreach (string name in names.Reverse())//Reversed to get the materials folder first
            {
                if (name != "")
                {
                    if (name.Contains('\\') || name.Contains('/'))
                        materialsPath = materialsPath + name;
                    else
                        MATERIALS.Add(materialsPath + name + ".vmt");
                }
            }

            if (verbose)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine();
            }


            var loadedMDL = new MDL();
            loadedMDL.name = NAME;
            loadedMDL.version = VERSION;
            loadedMDL.checksum = CHECKSUM;
            loadedMDL.flags = FLAGS;
            loadedMDL.materials = new string[MATERIALS.Count];
            MATERIALS.CopyTo(loadedMDL.materials, 0);
            return loadedMDL;
        }

        public VMT LoadVMT(string path)
        {
            var newVMT = new VMT();

            if (!File.Exists(path))
                throw new FileNotFoundException();

            var newvmf = new VMF();

            using (var vmt = new StreamReader(path))
            {
                string line;
                while ((line = vmt.ReadLine()) != null)
                {
                    string cl = line.ToLower().Replace("\"\"", "\" \"").Replace("\"", "").Trim().TrimEnd().TrimStart();
                    string[] keyXvalue = cl.Split(' ');

                    if(keyXvalue.Count() > 1)
                    {
                        switch (keyXvalue[0])
                        {
                            case "$basetexture":
                                if(verbose)
                                    Console.WriteLine($"$basetexture : {keyXvalue[1]}");
                                newVMT.TEXTURES.Add(keyXvalue[1]+".vtf");
                                break;

                            case "$bumpmap":
                                if (verbose)
                                    Console.WriteLine($"$bumpmap : {keyXvalue[1]}");
                                newVMT.TEXTURES.Add(keyXvalue[1] + ".vtf");
                                break;

                            case "$envmap":
                                if (verbose)
                                    Console.WriteLine($"$envmap : {keyXvalue[1]}");
                                if(keyXvalue[1] != "env_cubemap")
                                    newVMT.TEXTURES.Add(keyXvalue[1] + ".vtf");
                                break;

                            case "$envmapmask":
                                if (verbose)
                                    Console.WriteLine($"$envmapmask : {keyXvalue[1]}");
                                newVMT.TEXTURES.Add(keyXvalue[1] + ".vtf");
                                break;

                            case "$detail":
                                if (verbose)
                                    Console.WriteLine($"$detail : {keyXvalue[1]}");
                                newVMT.TEXTURES.Add(keyXvalue[1] + ".vtf");
                                break;
                        }
                    }

                }
                vmt.Close();
            }

            return newVMT;
        }
    }

    public class VMF
    {
        
        //versioninfo
        public string editorversion,
            editorbuild,
            mapversion,
            formatversion,
            prefab;

        //viewsettings
        public string bSnapToGrid,
            bShowGrid,
            bShowLogicalGrid,
            nGridSpacing,
            bShow3DGrid;

        //world
        public string id,
            mapversionw,
            classname,
            detailmaterial,
            detailvbsp,
            maxpropscreenwidth,
            skyname;// add to materials

        List<string> MODELS = new List<string>(),
            MATERIALS = new List<string>(),
            TEXTURES = new List<string>(),
            SOUNDS = new List<string>(),
            COLOR_CORRECTIONS = new List<string>(), 
            PARTICLES = new List<string>();

        List<WORLD_SOLID> SOLIDS = new List<WORLD_SOLID>();
        List<WORLD_ENTITY> ENTITIES = new List<WORLD_ENTITY>();

        public void AddModel(string name)
        {
            if (MODELS == null)
                MODELS = new List<string>();

            name = name.Replace('/', '\\');

            if (!MODELS.Contains(name))
                MODELS.Add(name);
        }

        public void AddMaterial(string name)
        {
            if (MATERIALS == null)
                MATERIALS = new List<string>();

            name = name.Replace('/', '\\');

            if (!MATERIALS.Contains(name))
                MATERIALS.Add(name);
        }

        public void AddTextures(string name)
        {
            if (TEXTURES == null)
                TEXTURES = new List<string>();

            name = name.Replace('/', '\\');

            if (!TEXTURES.Contains(name))
                TEXTURES.Add(name);
        }

        public void AddSounds(string name)
        {
            if (SOUNDS == null)
                SOUNDS = new List<string>();

            name = name.Replace('/', '\\');

            if (!SOUNDS.Contains(name))
                SOUNDS.Add(name);
        }

        public void AddColorCorrection(string name)
        {
            if (COLOR_CORRECTIONS == null)
                COLOR_CORRECTIONS = new List<string>();

            if (!COLOR_CORRECTIONS.Contains(name))
                COLOR_CORRECTIONS.Add(name);
        }

        public void AddPArticle(string name)
        {
            if (PARTICLES == null)
                PARTICLES = new List<string>();

            if (!PARTICLES.Contains(name))
                PARTICLES.Add(name);
        }

        public void AddSolid(WORLD_SOLID WS)
        {
            SOLIDS.Add(WS);
        }

        public void AddEntity(WORLD_ENTITY WE)
        {
            ENTITIES.Add(WE);
        }


        public string[] GetModels()
        {
            return MODELS.ToArray();
        }

        public string[] GetMaterials()
        {
            return MATERIALS.ToArray();
        }

        public string[] GetTexture()
        {
            return TEXTURES.ToArray();
        }

        public string[] GetSounds()
        {
            return SOUNDS.ToArray();
        }

        public string[] GetColorCorrections()
        {
            return COLOR_CORRECTIONS.ToArray();
        }

        public string[] GetParticles()
        {
            return PARTICLES.ToArray();
        }

        public WORLD_SOLID[] GetSolids()
        {
            return SOLIDS.ToArray();
        }

        public WORLD_ENTITY[] GetEntities()
        {
            return ENTITIES.ToArray();
        }


    }

    public class MDL
    {
        #region Variables
        public string name;
        public int id, version, checksum, flags;
        public string[] materials;
        #endregion
    }

    public class VMT
    {
        public List<string> TEXTURES = new List<string>();
    }

    public class WORLD_SOLID
    {
        List<WORLD_SOLID_SIDE> SIDES = new List<WORLD_SOLID_SIDE>();


        public void AddSide(WORLD_SOLID_SIDE WSS)
        {
            SIDES.Add(WSS);
        }

    }

    public class WORLD_SOLID_SIDE
    {
        public string id;
        public string MATERIAL;
    }

    public class WORLD_ENTITY
    {
        public string id, classname, material, model, targetname, message, effect_name;
    }


}
