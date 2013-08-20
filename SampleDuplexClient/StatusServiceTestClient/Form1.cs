using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StatusServiceTestClient.StatusServiceReference;

namespace StatusServiceTestClient
{
    public partial class Form1 : Form, IStatusServiceCallback
    {
        public Form1()
        {
            InitializeComponent();
        }
        StatusServiceClient client;

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            try
            {
                string name = rnd.Next(3).ToString();
                this.Text = name;
                client =
                 new StatusServiceClient(new InstanceContext(this));
                client.Subscribe(name);
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.ToString());
            }
        }

        #region IStatusServiceCallback Members

        public void OnStatusUpdate(Status S)
        {
            listBox1.Items.Add(S.Name + S.Number.ToString());
        }

        #endregion


    }
}
