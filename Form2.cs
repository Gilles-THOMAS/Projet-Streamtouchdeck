using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Types;

using System.Linq;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public String source;
        //String bg_img_path;
        Image bg_img;
        //String Cmd_selected;
        Form Cmd_settings;
        Form1 form1_ref;

        //List<SourceInfo> obs_sources;
        public SourceInfo obs_source;

        ListBox selection;
        Button validate;

        Custom_Panel Self_Panel;

        public Form2(Form1 form_ref, Custom_Panel self)
        {
            InitializeComponent();
            comboBox1.Items.Add("Mute source");
            comboBox1.Items.Add("Change Scene");
            form1_ref = form_ref;
            Self_Panel = self;
            btn_validate.Enabled = false;
        }

        private void btn_validate_Click(object sender, EventArgs e)
        {
            if (bg_img != null)
            {
                Self_Panel.BackgroundImage = bg_img;
                Self_Panel.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                Self_Panel.BackgroundImage = null;
            }
            if (textBox1.TextLength > 0)
            {
                Self_Panel.Set_Label(textBox1.Text);
            }
            switch (comboBox1.SelectedItem)
            {
                case "Mute source":
                    Self_Panel.Futur_Click += Self_Panel.Mute_Source;
                    break;
                case "Change Scene":
                    Self_Panel.Futur_Click += Self_Panel.Change_Scene;
                    break;
            }
            Self_Panel.Activated = true;
            this.Close();
        }

        private void btn_img_browse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bg_img = Image.FromStream(openFileDialog1.OpenFile());
                btn_validate.Enabled = true;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cmd_settings = new Form3();
            switch (comboBox1.SelectedItem)
            {
                case "Mute source":
                    Mute_Source();
                    //Cmd_selected = "Mute source";
                    //Self_Panel.Futur_Click += Self_Panel.Mute_Source;
                    break;
                case "Change Scene":
                    Change_Scene();
                    //Self_Panel.Futur_Click += Self_Panel.Change_Scene;
                    break;
            }
        }

        private void Mute_Source()
        {
            selection = new ListBox();
            validate = new Button();
            Form source_select = new Form();

            //SourceInfo obs_source;

            selection.Location = new Point(5, 5);
            selection.Size = new Size(190, 200);
            foreach (SourceInfo src in this.form1_ref.obs.GetSourcesList())
            {
                selection.Items.Add(src.Name);
            }

            selection.SelectedIndexChanged += Select_obs_output;
            //sources_selection.SelectedItem;
            //sources_selection.Items.AddRange(this.form1_ref.obs.GetSourcesList());

            validate.Location = new Point(5, 210);
            validate.Click += get_source;
            validate.Enabled = false;
            validate.Text = "Validate";

            Cmd_settings = new Form();
            Cmd_settings.Size = new Size(200, 300);
            Cmd_settings.StartPosition = FormStartPosition.CenterParent;

            Cmd_settings.Controls.Add(selection);
            Cmd_settings.Controls.Add(validate);

            Cmd_settings.Show();
        }

        private void Change_Scene()
        {
            selection = new ListBox();
            validate = new Button();
            //GetSceneListInfo Scenes = new GetSceneListInfo();
            Form source_select = new Form();

            //SourceInfo obs_source;

            selection.Location = new Point(5, 5);
            selection.Size = new Size(190, 200);
            //Scenes = this.form1_ref.obs.GetSceneList();

            foreach (OBSScene src in this.form1_ref.obs.GetSceneList().Scenes)
            {
                selection.Items.Add(src.Name);
            }

            selection.SelectedIndexChanged += Select_obs_output;
            //sources_selection.SelectedItem;
            //sources_selection.Items.AddRange(this.form1_ref.obs.GetSourcesList());

            validate.Location = new Point(5, 210);
            validate.Click += get_scene;
            validate.Enabled = false;
            validate.Text = "Validate";

            Cmd_settings = new Form();
            Cmd_settings.Size = new Size(200, 300);
            Cmd_settings.StartPosition = FormStartPosition.CenterParent;

            Cmd_settings.Controls.Add(selection);
            Cmd_settings.Controls.Add(validate);

            Cmd_settings.Show();
        }

        private void Select_obs_output(object sender, EventArgs e)
        {
            validate.Enabled = true;
        }

        private void get_scene(object sender, EventArgs e)
        {
            Self_Panel.Scene_name = selection.SelectedItem.ToString();
            Cmd_settings.Close();
        }

        private void get_source(object sender, EventArgs e)
        {
            //obs_sources = this.form1_ref.obs.GetSourcesList();
            //obs_source = obs_sources.Where(s => s.Name == selection.SelectedItem).FirstOrDefault();
            Self_Panel.Source_name = selection.SelectedItem.ToString();
            Cmd_settings.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
            {
                btn_validate.Enabled = true;
            }
            else if (bg_img == null)
            {
                btn_validate.Enabled = false;
            }
        }
    }
}
