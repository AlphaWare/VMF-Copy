using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using SEAReader;
using System.Diagnostics;
using System.Threading;

namespace VMF_Copy
{
    public partial class wfMain : Form
    {
        private string APPROOT = "", SOURCES_FILE_PATH, FILTER_FILE_PATH, BSPZIP_LIST_PATH, APPRES;
        private SEAR sear;
        private List<string> srcDirs = new List<string>();
        private List<string> BSPZIP_LIST = new List<string>();
        private List<string> FILTER_LIST = new List<string>();
        public wfMain()
        {
            InitializeComponent();
            APPROOT = Path.GetDirectoryName(Application.ExecutablePath);
            SOURCES_FILE_PATH = APPROOT + "\\sources.txt";
            FILTER_FILE_PATH = APPROOT + "\\vmfc_filter.txt";
            BSPZIP_LIST_PATH = APPROOT + "\\bspzip.txt";
            APPRES = APPROOT + "\\res";
        }

        private void b_start_Click(object sender, EventArgs e)
        {
            //Check if everything exists
            if(!File.Exists(tb_vmf.Text))
            {
                MessageBox.Show("Invalid Path for VMF", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (!Directory.Exists(tb_output.Text))
            {
                MessageBox.Show("Invalid Path for OUTPUT", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (lb_gameFolders.Items.Count != 0)
                foreach (string path in lb_gameFolders.Items)
                {
                    if (!Directory.Exists(path))
                        MessageBox.Show("Invalid Path : "+ path, "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            else
            {
                MessageBox.Show("Sources is empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
                

            if(cb_use_bspzip.Checked)
            {
                if (!File.Exists(tb_vmf.Text))
                {
                    MessageBox.Show("Invalid Path for BspZip", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                    

                if (!File.Exists(tb_vmf.Text))
                {
                    MessageBox.Show("Invalid Path for BSP", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

            }


            lb_log.Items.Clear();
            sear = new SEAR();
            var vmf = sear.LoadVMF(tb_vmf.Text, srcDirs.ToArray());
            GenerateAssetsList(vmf);
        }

        private void GenerateAssetsList(VMF vmf)
        {
            List<string> Assets = new List<string>();
            Thread mThread = new Thread(delegate() 
            {
                //Generate Filter
                if (!File.Exists(FILTER_FILE_PATH))
                    createFilter();

                if (cb_IgnoreFilter.Checked)
                {
                    FILTER_LIST = new List<string>();
                    using (var sr = new StreamReader(FILTER_FILE_PATH))
                    {
                        string l;
                        while ((l = sr.ReadLine()) != null)
                        {
                            FILTER_LIST.Add(l);
                        }
                        sr.Close();
                    }
                }
                else
                {
                    FILTER_LIST = new List<string>();
                }
                
                    


                foreach(string srcFile in vmf.GetModels())
                {
                    if(!FILTER_LIST.Contains(Path.GetFileName(srcFile).ToLower()))
                    {
                        //Look for files that can be overriden by sources
                        string overridefilenoExtension = "";
                        foreach (string SOURCE in srcDirs)
                            if (File.Exists(SOURCE + "\\" + srcFile))
                                overridefilenoExtension = Path.GetDirectoryName(SOURCE + "\\" + srcFile) + "\\" + Path.GetFileNameWithoutExtension(SOURCE + "\\" + srcFile);

                        string MDL_EXT = ".mdl";
                        if (File.Exists(overridefilenoExtension + MDL_EXT)) // If the mdl file doesn't exist then there's no reason to look for it's additional files
                        {
                            Assets.Add(overridefilenoExtension + MDL_EXT);

                            string EXTENSION = ".mdl";
                            if (cb_sw.Checked)
                            {
                                EXTENSION = ".sw.vtx";
                                if (File.Exists(overridefilenoExtension + EXTENSION))//.sw.vtx
                                    Assets.Add(overridefilenoExtension + EXTENSION);
                                else
                                    this.Invoke(new MethodInvoker(delegate () { Log("Missing " + EXTENSION + " for " + Path.GetFileName(overridefilenoExtension + MDL_EXT)); }));
                            }

                            if (cb_dx80.Checked)
                            {
                                EXTENSION = ".dx80.vtx";
                                if (File.Exists(overridefilenoExtension + EXTENSION))//.dx80.vtx
                                    Assets.Add(overridefilenoExtension + EXTENSION);
                                else
                                    this.Invoke(new MethodInvoker(delegate () { Log("Missing " + EXTENSION + " for " + Path.GetFileName(overridefilenoExtension + MDL_EXT)); }));
                            }

                            if (cb_dx90.Checked)
                            {
                                EXTENSION = ".dx90.vtx";
                                if (File.Exists(overridefilenoExtension + EXTENSION))//.dx90.vtx
                                    Assets.Add(overridefilenoExtension + EXTENSION);
                                else
                                    this.Invoke(new MethodInvoker(delegate () { Log("Missing " + EXTENSION + " for " + Path.GetFileName(overridefilenoExtension + MDL_EXT)); }));
                            }

                            if (cb_phy.Checked)
                            {
                                EXTENSION = ".phy";
                                if (File.Exists(overridefilenoExtension + EXTENSION))//.phy
                                    Assets.Add(overridefilenoExtension + EXTENSION);
                                else
                                    this.Invoke(new MethodInvoker(delegate () { Log("Missing " + EXTENSION + " for " + Path.GetFileName(overridefilenoExtension + MDL_EXT)); }));
                            }

                            if (cb_ani.Checked)
                            {
                                EXTENSION = ".ani";
                                if (File.Exists(overridefilenoExtension + EXTENSION))//.ani
                                    Assets.Add(overridefilenoExtension + EXTENSION);
                                else
                                    this.Invoke(new MethodInvoker(delegate () { Log("Missing " + EXTENSION + " for " + Path.GetFileName(overridefilenoExtension + MDL_EXT)); }));
                            }

                            if (cb_vvd.Checked)
                            {
                                EXTENSION = ".vvd";
                                if (File.Exists(overridefilenoExtension + EXTENSION))//.vvd
                                    Assets.Add(overridefilenoExtension + EXTENSION);
                                else
                                    this.Invoke(new MethodInvoker(delegate () { Log("Missing " + EXTENSION + " for " + Path.GetFileName(overridefilenoExtension + MDL_EXT)); }));
                            }

                        }
                    }
                    else
                    {
                        this.Invoke(new MethodInvoker(delegate () { Log("Filtered "+ Path.GetFileName(srcFile).ToLower()); }));
                    }
                }

                foreach(string srcFile in vmf.GetMaterials())
                {
                    if (!FILTER_LIST.Contains(Path.GetFileName(srcFile).ToLower()))
                    {
                        string overridefile = "";
                        foreach (string SOURCE in srcDirs)
                            if (File.Exists(SOURCE + "\\" + srcFile))
                                overridefile = SOURCE + "\\" + srcFile;

                        if (overridefile != "")
                            Assets.Add(overridefile);
                    }
                    else
                    {
                        this.Invoke(new MethodInvoker(delegate () { Log("Filtered " + Path.GetFileName(srcFile).ToLower()); }));
                    }

                }

                foreach(string srcFile in vmf.GetTexture())
                {
                    if (!FILTER_LIST.Contains(Path.GetFileName(srcFile).ToLower()))
                    {
                        string overridefile = "";
                        foreach (string SOURCE in srcDirs)
                            if (File.Exists(SOURCE + "\\" + srcFile))
                                overridefile = SOURCE + "\\" + srcFile;

                        if (overridefile != "")
                            Assets.Add(overridefile);
                    }
                    else
                    {
                        this.Invoke(new MethodInvoker(delegate () { Log("Filtered " + Path.GetFileName(srcFile).ToLower()); }));
                    }

                }

                foreach (string srcFile in vmf.GetSounds())
                {
                    if (!FILTER_LIST.Contains(Path.GetFileName(srcFile).ToLower()))
                    {
                        string overridefile = "";
                        foreach (string SOURCE in srcDirs)
                            if (File.Exists(SOURCE + "\\" + srcFile))
                                overridefile = SOURCE + "\\" + srcFile;

                        if (overridefile != "")
                            Assets.Add(overridefile);
                    }
                    else
                    {
                        this.Invoke(new MethodInvoker(delegate () { Log("Filtered " + Path.GetFileName(srcFile).ToLower()); }));
                    }

                }

                if (!cb_use_bspzip.Checked)
                    CopyToOutput(Assets.ToArray());
                else
                    Usebspzip(Assets.ToArray());

                this.Invoke(new MethodInvoker(delegate () { Log("Missing Models: "); }));
                foreach (string MISSING in sear.MISSING_MODELS)
                {
                    this.Invoke(new MethodInvoker(delegate () { Log(" "+ MISSING); }));
                }

                this.Invoke(new MethodInvoker(delegate () { Log("Missing Materials: "); }));
                foreach (string MISSING in sear.MISSING_MATERIALS)
                {
                    this.Invoke(new MethodInvoker(delegate () { Log(" " + MISSING); }));
                }

                this.Invoke(new MethodInvoker(delegate () { Log("Missing Textures: "); }));
                foreach (string MISSING in sear.MISSING_TEXTURES)
                {
                    this.Invoke(new MethodInvoker(delegate () { Log(" " + MISSING); }));
                }

                this.Invoke(new MethodInvoker(delegate () { Log("Missing Sounds: "); }));
                foreach (string MISSING in sear.MISSING_SOUNDS)
                {
                    this.Invoke(new MethodInvoker(delegate () { Log(" " + MISSING); }));
                }

            });
            mThread.Start();
        }

        private void CopyToOutput(string[] list)
        {
            foreach(string srcFile in list)
            {
                if(File.Exists(srcFile))
                {

                }
                foreach(string srcFolder in srcDirs)
                {
                    if(srcFile.Contains(srcFolder))
                    {
                        string OUTPUT_FILE = tb_output.Text + "\\" + srcFile.Replace(srcFolder + "\\", "");

                        if (!Directory.Exists(Path.GetDirectoryName(OUTPUT_FILE)))
                            Directory.CreateDirectory(Path.GetDirectoryName(OUTPUT_FILE));

                        if(File.Exists(OUTPUT_FILE))
                        {
                            if(cb_rExistingFiles.Checked)
                            {
                                File.Copy(srcFile, OUTPUT_FILE, true);
                                this.Invoke(new MethodInvoker(delegate () { Log("Replaced "+Path.GetFileName(OUTPUT_FILE)); }));
                            }
                            else
                            {
                                this.Invoke(new MethodInvoker(delegate () { Log("Exists " + Path.GetFileName(OUTPUT_FILE)); }));
                            }
                        }
                        else
                        {
                            File.Copy(srcFile, OUTPUT_FILE, true);
                            this.Invoke(new MethodInvoker(delegate () { Log("Copied " + Path.GetFileName(OUTPUT_FILE)); }));
                        }
                    }
                }

            }
        }

        private void Usebspzip(string[] list)
        {
            if(!cb_extract_bsp.Checked)
            {
                this.Invoke(new MethodInvoker(delegate () { Log("Prepairing list..."); }));
                foreach (string srcFile in list)
                {
                    foreach (string srcFolder in srcDirs)
                    {
                        if (srcFile.Contains(srcFolder))
                        {
                            string INTERNAL = srcFile.Replace(srcFolder + "\\", "").Replace("\\", "/");
                            BSPZIP_LIST.Add(INTERNAL);
                            BSPZIP_LIST.Add(srcFile);
                            this.Invoke(new MethodInvoker(delegate () { Log("BSPZIP " + INTERNAL); }));
                        }
                    }

                }

                this.Invoke(new MethodInvoker(delegate () { Log("Creating list..."); }));
                using (var sw = new StreamWriter(BSPZIP_LIST_PATH))
                {
                    foreach (string line in BSPZIP_LIST)
                    {
                        sw.WriteLine(line);
                    }

                    sw.Flush();
                    sw.Close();
                }

                this.Invoke(new MethodInvoker(delegate () { Log("Starting BSPZIP..."); }));
                Process BSPZIP = new Process();
                BSPZIP.StartInfo.FileName = tb_bspzipPath.Text;
                string ARGS = "-addorupdatelist \"" + tb_bspPath.Text + "\" \"" + BSPZIP_LIST_PATH + "\" \"" + tb_output.Text + "\\" + Path.GetFileName(tb_bspPath.Text) + "\"" + " -game \"" + APPRES + "\"";
                BSPZIP.StartInfo.Arguments = ARGS;
                BSPZIP.StartInfo.CreateNoWindow = true;
                BSPZIP.StartInfo.UseShellExecute = false;
                BSPZIP.StartInfo.RedirectStandardOutput = true;
                BSPZIP.OutputDataReceived += BSPZIP_OutputDataReceived;
                BSPZIP.Start();
                BSPZIP.BeginOutputReadLine();
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate () { Log("Starting BSPZIP..."); }));
                Process BSPZIP = new Process();
                BSPZIP.StartInfo.FileName = tb_bspzipPath.Text;
                string ARGS = "-extract \"" + tb_bspPath.Text + "\" \"" + tb_output.Text + "\\" + Path.GetFileNameWithoutExtension(tb_bspPath.Text) + ".zip\"" + " -game \"" + APPRES + "\"";
                BSPZIP.StartInfo.Arguments = ARGS;
                BSPZIP.StartInfo.CreateNoWindow = true;
                BSPZIP.StartInfo.UseShellExecute = false;
                BSPZIP.StartInfo.RedirectStandardOutput = true;
                BSPZIP.OutputDataReceived += BSPZIP_OutputDataReceived;
                BSPZIP.Start();
                BSPZIP.BeginOutputReadLine();
            }



        }

        private void BSPZIP_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {

            this.Invoke(new MethodInvoker(delegate () {

                try
                {
                    Log("  " + e.Data.ToString());
                }
                catch (Exception)
                {

                }
                
            }));
        }

        private void wfMain_Load(object sender, EventArgs e)
        {
            if(File.Exists(SOURCES_FILE_PATH))
            {
                var SOURCES = new StreamReader(SOURCES_FILE_PATH);
                string l;
                while ((l = SOURCES.ReadLine()) != null)
                {
                    lb_gameFolders.Items.Add(l);
                    srcDirs.Add(l);
                }
                SOURCES.Close();
            }
        }

        private void wfMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            var SOURCES = new StreamWriter(SOURCES_FILE_PATH);
            foreach (var item in lb_gameFolders.Items)
                SOURCES.WriteLine(item.ToString());
            SOURCES.Close();

        }

        private void b_openCreateFilter_Click(object sender, EventArgs e)
        {
            if (File.Exists(FILTER_FILE_PATH))
                Process.Start(FILTER_FILE_PATH).StartInfo.UseShellExecute = false;
            else
                createFilter();

            Process.Start(FILTER_FILE_PATH).StartInfo.UseShellExecute = false;
        }

        public void createFilter()
        {
            using (var sw = new StreamWriter(FILTER_FILE_PATH))
            {
                sw.AutoFlush = true;
                #region a list
                sw.WriteLine(@"additivevertexcolorvertexalpha.vmt
debugambientcube.vmt
debugbrushwireframe.vmt
debugcamerarendertarget.vmt
debugdecalwireframe.vmt
debugdepthbuffer.vmt
debugdrawflat.vmt
debugdrawflatpolygons.vmt
debugdrawflattriangles.vmt
debugempty.vmt
debugfbtexture0.vmt
debughitbox.vmt
debugleafviswireframe.vmt
debuglightingonly.vmt
debuglightmap.vmt
debuglightmapzbuffer.vmt
debugluxels.vmt
debugluxelsnoalpha.vmt
debugmodelbones.vmt
debugmrmfullbright2.vmt
debugmrmnormals.vmt
debugmrmwireframe.vmt
debugmrmwireframezbuffer.vmt
debugparticlewireframe.vmt
debugportals.vmt
debugreflect.vmt
debugrefract.vmt
debugscreenspacewireframe.vmt
debugshadowbuffer.vmt
debugskeleton.vmt
debugsolidmodelhulls.vmt
debugspritewireframe.vmt
debugtexturealpha.vmt
debugtexturecolor.vmt
debugtranslucentmodelhulls.vmt
debugtranslucentsinglecolor.vmt
debugtranslucentvertexcolor.vmt
debugvertexcolor.vmt
debugwireframe.vmt
debugwireframevertexcolor.vmt
debugwireframevertexcolorignorez.vmt
debugworldnormals.vmt
debugworldwireframe.vmt
debugworldwireframezbuffer.vmt
defaultlightmap.vtf
env_cubemap_model.vmt
env_cubemap_model_translucent.vmt
env_cubemap_model_translucent_fountain.vmt
hsv.vmt
modelstats.vmt
particleerror.vmt
showblurredcolor.vmt
showdestalpha.vmt
showdestalphatimescolor_blurred.vmt
showdestalpha_blurred.vmt
showz.vmt
yuv.vmt
blendfb0.vmt
blendfb1.vmt
bloom.vmt
bloomadd.vmt
blurfilterx.vmt
blurfilterx_nohdr.vmt
blurfiltery.vmt
blurfiltery_and_add_nohdr.vmt
blurfiltery_nohdr.vmt
bms_godrays.vmt
bms_godrays_combine.vmt
bms_godrays_downsample.vmt
bms_postprocess.vmt
copyfullframefb.vmt
copyfullframefb_vanilla.vmt
dev2way.vmt
devcubelight.vtf
devnormalmap.vtf
dev_4way_blending.vmt
dev_blendmeasure.vmt
dev_blendmeasure2.vmt
dev_brickwall012d.vmt
dev_brickwall012e.vmt
dev_bullseye.vmt
dev_bullseye.vtf
dev_bumptest.vmt
dev_camo.vmt
dev_ceiling.vmt
dev_combinemonitor_1.vmt
dev_combinemonitor_2.vmt
dev_combinemonitor_3.vmt
dev_combinemonitor_4.vmt
dev_combinemonitor_5.vmt
dev_combinemonitor_b.vmt
dev_combinemonitor_g.vmt
dev_combinemonitor_r.vmt
dev_comintmonitor1a.vmt
dev_concretefloor004a.vmt
dev_concretefloor006a.vmt
dev_concretewall020a.vmt
dev_corrugatedmetal.vmt
dev_cratewood01a.vmt
dev_eastwall.vmt
dev_envcubemap.vmt
dev_envmap.vmt
dev_floor.vmt
dev_glassfrosted01a.vmt
dev_hazzardstripe01a.vmt
dev_interiorfloorgrate03b.vmt
dev_interiorfloorlinoleum01f.vmt
dev_interiorlight02b.vmt
dev_lowerfloorgrate01d.vmt
dev_lowermetaldoor01.vmt
dev_lowermetaldoor02a.vmt
dev_lowertank01a.vmt
dev_lowerwallmetal01a.vmt
dev_lowerwallmetal01c.vmt
dev_lowerwallmetal01d.vmt
dev_materialmodify.vmt
dev_measurebarrel.vmt
dev_measurecolorscale01.vmt
dev_measurecomputer01.vmt
dev_measurecounter.vmt
dev_measurecrate01.vmt
dev_measurecrate02.vmt
dev_measurecrate03.vmt
dev_measuredesk.vmt
dev_measuredoor01.vmt
dev_measuregeneric01.vmt
dev_measuregeneric01b.vmt
dev_measurehall01.vmt
dev_measureice01.vmt
dev_measureladder01.vmt
dev_measurerails01.vmt
dev_measurerails02.vmt
dev_measurestairs01a.vmt
dev_measureswitch01.vmt
dev_measureswitch02.vmt
dev_measureswitch03.vmt
dev_measurewall01a.vmt
dev_measurewall01b.vmt
dev_measurewall01c.vmt
dev_measurewall01d.vmt
dev_monitor.vmt
dev_northwall.vmt
dev_pipes.vmt
dev_plasterwall001c.vmt
dev_prisontvoverlay001.vmt
dev_prisontvoverlay002.vmt
dev_prisontvoverlay003.vmt
dev_prisontvoverlay004.vmt
dev_ram_512_black.vmt
dev_ram_512_black.vtf
dev_ram_512_blue.vmt
dev_ram_512_blue.vtf
dev_ram_512_blue_glow.vmt
dev_ram_512_blue_glow.vtf
dev_ram_512_grey.vmt
dev_ram_512_grey.vtf
dev_ram_512_int_c_floor_lower.vmt
dev_ram_512_int_c_floor_lower.vtf
dev_ram_512_int_c_floor_upper.vmt
dev_ram_512_int_c_floor_upper.vtf
dev_ram_512_int_c_highlight.vmt
dev_ram_512_int_c_highlight.vtf
dev_ram_512_int_c_highlight_dark.vmt
dev_ram_512_int_c_highlight_dark.vtf
dev_ram_512_int_c_wall.vmt
dev_ram_512_int_c_wall.vtf
dev_ram_512_int_c_water.vmt
dev_ram_512_int_c_water.vtf
dev_ram_512_orange.vmt
dev_ram_512_orange.vtf
dev_ram_512_purple_glow.vmt
dev_ram_512_purple_glow.vtf
dev_ram_512_red.vmt
dev_ram_512_red.vtf
dev_ram_512_silver.vmt
dev_ram_512_silver.vtf
dev_red.vmt
dev_red.vtf
dev_signflammable01a.vmt
dev_slime.vmt
dev_slime_int_c.vmt
dev_slime_int_c.vtf
dev_southwall.vmt
dev_stonewall001a.vmt
dev_texlight.vtf
dev_tvmonitor1a.vmt
dev_tvmonitor2a.vmt
dev_tvmonitornonoise.vmt
dev_water2.vmt
dev_water2_cheap.vmt
dev_water3.vmt
dev_water3_beneath.vmt
dev_water3_exp.vmt
dev_water4.vmt
dev_water5.vmt
dev_waterbeneath2.vmt
dev_westwall.vmt
dev_windowportal.vmt
dof.vmt
dof_blur_x.vmt
dof_blur_y.vmt
dof_downsample.vmt
downsample.vmt
downsample_non_hdr.vmt
downsample_non_hdr_cstrike.vmt
engine_post.vmt
example_model_material.vmt
fade_blur.vmt
floattoscreen_combine.vmt
floattoscreen_combine_autoexpose.vmt
gman_spotlight.vtf
graygrid.vmt
hdrselectrange.vmt
hud_blur_x.vmt
hud_blur_y.vmt
hud_display.vmt
hud_downsample.vmt
hud_scanline.vtf
hud_scanlines.vmt
lumcompare.vmt
motion_blur.vmt
noise.vtf
no_pixel_write.vmt
ocean.vmt
oceanbeneath.vmt
pomproptest.vmt
pomproptest2.vmt
pomtest.vmt
pomtest.vtf
pomtest2.vmt
pomtest2.vtf
pomtest2_sepht.vtf
pomtest_height.vtf
pomtest_invert.vtf
postprocess_noise.vtf
reflectivity_10.vmt
reflectivity_10b.vmt
reflectivity_20.vmt
reflectivity_20b.vmt
reflectivity_30.vmt
reflectivity_30b.vmt
reflectivity_40.vmt
reflectivity_40b.vmt
reflectivity_50.vmt
reflectivity_50b.vmt
reflectivity_60.vmt
reflectivity_60b.vmt
reflectivity_70.vmt
reflectivity_70b.vmt
reflectivity_80.vmt
reflectivity_80b.vmt
reflectivity_90.vmt
reflectivity_90b.vmt
samplefb0.vmt
samplefb0_delog.vmt
samplefb1.vmt
samplefb1_delog.vmt
samplefullfb.vmt
samplefullfb_nolog.vmt
test_normals.vmt
twenty.vmt
upscale.vmt
warp.vmt
xbownewrgb.vtf
xbownewstencil.vtf
xbownewstencilold.vtf
xbownew_scope_normal.vtf
xbow_lens_dirt.vtf
xbow_post_downsample.vmt
xbow_post_flare.vmt
xbow_post_flare_draw.vmt
xbow_post_flare_modulate.vmt
xbow_post_threshold.vmt
xbow_upscale.vmt
addlight.vmt
addlight0.vmt
addlight1.vmt
air_node.vmt
air_node_hint.vmt
aiscripted_schedule.vmt
ai_goal_follow.vmt
ai_goal_lead.vmt
ai_goal_police.vmt
ai_goal_standoff.vmt
ai_relationship.vmt
ai_sound.vmt
ambient_generic.vmt
assault_point.vmt
assault_rally.vmt
axis_helper.vmt
basealphaenvmapmaskicon.vmt
bullseye.vmt
choreo_manager.vmt
choreo_scene.vmt
climb_node.vmt
color_correction.vmt
copyalbedo.vmt
cordon.vmt
dotted.vmt
env_cubemap.vmt
env_explosion.vmt
env_fade.vmt
env_fire.vmt
env_firesource.vmt
env_microphone.vmt
env_particles.vmt
env_physexplosion.vmt
env_shake.vmt
env_shooter.vmt
env_skypaint.vmt
env_skypaint.vtf
env_soundscape.vmt
env_spark.vmt
env_sun.vmt
env_sun.vtf
env_tonemap_controller.vmt
env_wind.vmt
erroricon.vmt
filter_class.vmt
filter_multiple.vmt
filter_name.vmt
filter_team.vmt
flat.vmt
flatdecal.vmt
flatignorez.vmt
flatnocull.vmt
fog_controller.vmt
game_end.vmt
game_text.vmt
gibshooter.vmt
gizmoaxis.vmt
gizmorotatehandle.vmt
gizmoscalehandle.vmt
gizmotranslatehandle.vmt
gray.vmt
ground_node.vmt
ground_node_hint.vmt
info_landmark.vmt
info_lighting.vmt
info_target.vmt
light.vmt
lightmapgrid.vmt
lightmapgriddecal.vmt
light_env.vmt
logic_auto.vmt
logic_branch.vmt
logic_case.vmt
logic_compare.vmt
logic_multicompare.vmt
logic_relay.vmt
logic_timer.vmt
lua_run.vmt
lua_run.vtf
math_counter.vmt
multisource.vmt
multi_manager.vmt
node_hint.vmt
npc_maker.vmt
obsolete.vmt
opaqueicon.vmt
orange.vmt
phys_ballsocket.vmt
sample_result_0.vmt
sample_result_1.vmt
scripted_sentence.vmt
selectionoverlay.vmt
selfillumicon.vmt
shadow_control.vmt
tanktrain_ai.vmt
tanktrain_aitarget.vmt
translucentflat.vmt
translucentflatdecal.vmt
translucenticon.vmt
translucentlightmap.vmt
trigger_relay.vmt
vertexcolor.vmt
waterlodcontrol.vmt
wireframe.vmt
xen_portal.vmt
xen_portal.vtf
box.vtf
cubemapdefault.hdr.vtf
cubemapdefault.vtf
writez.vmt
color_correction.vtf
friction_metal_000.vtf
friction_metal_015.vtf
friction_metal_025.vtf
friction_metal_035.vtf
invismetal.vtf
toolsblendinvisible.vtf
toolshide.vtf
camera.dx80.vtx
camera.dx90.vtx
camera.mdl
camera.sw.vtx
camera.vvd");
                #endregion a long one
                sw.Flush();
                sw.Close();
            }
        }

        public void createBspZipList()
        {

        }

        private void b_browse_vmf_Click(object sender, EventArgs e)
        {
            using (var Diag = new OpenFileDialog())
            {
                Diag.Filter = "(Valve Map Format)|*.vmf";
                if (Diag.ShowDialog() == DialogResult.OK)
                    tb_vmf.Text = Diag.FileName;
            }
        }

        private void b_game_folder_Click(object sender, EventArgs e)
        {
            using (var Diag = new FolderBrowserDialog())
            {
                if (Diag.ShowDialog() == DialogResult.OK)
                {
                    lb_gameFolders.Items.Add(Diag.SelectedPath);
                }
            }
        }

        private void b_browse_output_Click(object sender, EventArgs e)
        {
            using (var Diag = new FolderBrowserDialog())
            {
                if (Diag.ShowDialog() == DialogResult.OK)
                    tb_output.Text = Diag.SelectedPath;
            }
        }

        private void lb_gameFolders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
                lb_gameFolders.Items.Remove(lb_gameFolders.SelectedItems[0]);
        }

        private void b_remove_Click(object sender, EventArgs e)
        {
            if(lb_gameFolders.SelectedItems.Count != 0)
             lb_gameFolders.Items.Remove(lb_gameFolders.SelectedItems[0]);
        }

        public void Log(string msg)
        {
            
            lb_log.Items.Add(msg);
            lb_log.SelectedIndex = lb_log.Items.Count - 1;

            Application.DoEvents();
        }

        private void lb_gameFolders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void b_openInExpolorer_vmf_Click(object sender, EventArgs e)
        {
            Process.Start(Path.GetDirectoryName(tb_vmf.Text));
        }

        private void b_openInExpolorer_Output_Click(object sender, EventArgs e)
        {
            Process.Start(tb_output.Text);
        }

        private void b_openInExpolorer_selectedSource_Click(object sender, EventArgs e)
        {
            if (lb_gameFolders.SelectedItems.Count != 0)
                Process.Start(lb_gameFolders.SelectedItems[0].ToString());
        }

        private void b_openInExplorer_bspzip_Click(object sender, EventArgs e)
        {
            Process.Start(Path.GetDirectoryName(tb_bspzipPath.Text));
        }

        private void b_openInExpolorer_bsp_Click(object sender, EventArgs e)
        {
            Process.Start(Path.GetDirectoryName(tb_bspPath.Text));
        }

        private void lb_gameFolders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Process.Start(lb_gameFolders.SelectedItems[0].ToString());
        }

        private void b_browse_bspzip_Click(object sender, EventArgs e)
        {
            using (var Diag = new OpenFileDialog())
            {
                Diag.Filter = "(BSPZIP)|bspzip.exe";
                if (Diag.ShowDialog() == DialogResult.OK)
                    tb_bspzipPath.Text = Diag.FileName;
            }
        }

        private void b_browse_bsp_Click(object sender, EventArgs e)
        {
            using (var Diag = new OpenFileDialog())
            {
                Diag.Filter = "(Valve Map Format)|*.bsp";
                if (Diag.ShowDialog() == DialogResult.OK)
                    tb_bspPath.Text = Diag.FileName;
            }
        }

        private void cb_cModels_CheckedChanged(object sender, EventArgs e)
        {
            cb_sw.Enabled = cb_cModels.Checked;
            cb_dx80.Enabled = cb_cModels.Checked;
            cb_dx90.Enabled = cb_cModels.Checked;
            cb_phy.Enabled = cb_cModels.Checked;
            cb_ani.Enabled = cb_cModels.Checked;
            cb_vvd.Enabled = cb_cModels.Checked;
        }
    }
}
