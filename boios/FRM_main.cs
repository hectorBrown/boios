using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace boios
{
    public partial class FRM_main : Form
    {
        private int alignment, cohesion, seperation;

        private void TB_alignment_Scroll(object sender, EventArgs e)
        {
            alignment = TB_alignment.Value;
        }

        private void TB_seperation_Scroll(object sender, EventArgs e)
        {
            seperation = TB_seperation.Value;
        }

        private void TB_cohesion_Scroll(object sender, EventArgs e)
        {
            cohesion = TB_cohesion.Value;
        }

        private void FRM_main_Load(object sender, EventArgs e)
        {
            alignment = 0; cohesion = 0; seperation = 0;
        }

        public FRM_main()
        {
            InitializeComponent();
        }
    }
}
