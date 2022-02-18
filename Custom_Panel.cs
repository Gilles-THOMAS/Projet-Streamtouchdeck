using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using OBSWebsocketDotNet.Types;

using System.Linq;

namespace WindowsFormsApp1
{
    [Serializable]
    public class Custom_Panel : Panel
    {
        public EventHandler Futur_Click;
        public SourceInfo Source;
        public String Source_name;
        public SceneItem Scene;
        public String Scene_name;
        public Label Text;
        public Boolean Activated;

        //public Custom_Panel Self_Panel { get; set; }

        Form1 Main_form_ref;

        public Custom_Panel(Form1 main_form_ref)
        {
            this.Main_form_ref = main_form_ref;
            Activated = false;
            Text = new Label();
        }

        public void Set_Label(String label_text)
        {
            //Text = new Label();
            Text.Text = label_text;
            Text.Location = new Point((this.Width - Text.Width) / 2, (this.Height - Text.Height) / 2);
            this.Controls.Add(Text);
        }

        public void Mute_Source(object sender, EventArgs e)
        {
            /*
            if (this.Main_form_ref.obs.GetMute("Mic/Aux"))
            {
                this.Main_form_ref.obs.SetMute(Source_name, false);
            }
            else
            {
                this.Main_form_ref.obs.SetMute(Source_name, true);
            }*/
            this.Main_form_ref.obs.SetMute(Source_name, true);
            this.Click += Unmute_Source;
        }

        public void Unmute_Source(object sender, EventArgs e)
        {
            this.Main_form_ref.obs.SetMute(Source_name, false);
            this.Click += Mute_Source;
        }

        public void Change_Scene(object sender, EventArgs e)
        {
            this.Main_form_ref.obs.SetCurrentScene(Scene_name);
        }
    }
}
