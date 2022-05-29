using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Threading.Tasks;
using LibreHardwareMonitor.Hardware;

namespace Taskbar
{
    public partial class Taskbar : Form
    {
        /******************************************************************/
        #region Global Variables
        protected static Resources resources = new Resources();
        protected static Computer computer = new Computer();
        #endregion
        /******************************************************************/

        /******************************************************************/
        public Taskbar(CSDeskBand.CSDeskBandWin window)
        {
            InitializeComponent();

            //Bind resource values to resource class
            cpu_usage_value.DataBindings.Add(new Binding("Text", resources, "cpu_usage_value", true, DataSourceUpdateMode.OnPropertyChanged));
            cpu_usage_suffix.DataBindings.Add(new Binding("Text", resources, "cpu_usage_suffix", true, DataSourceUpdateMode.OnPropertyChanged));
            cpu_temp_value.DataBindings.Add(new Binding("Text", resources, "cpu_temp_value", true, DataSourceUpdateMode.OnPropertyChanged));
            cpu_temp_suffix.DataBindings.Add(new Binding("Text", resources, "cpu_temp_suffix", true, DataSourceUpdateMode.OnPropertyChanged));
            gpu_usage_value.DataBindings.Add(new Binding("Text", resources, "gpu_usage_value", true, DataSourceUpdateMode.OnPropertyChanged));
            gpu_usage_suffix.DataBindings.Add(new Binding("Text", resources, "gpu_usage_suffix", true, DataSourceUpdateMode.OnPropertyChanged));
            gpu_temp_value.DataBindings.Add(new Binding("Text", resources, "gpu_temp_value", true, DataSourceUpdateMode.OnPropertyChanged));
            gpu_temp_suffix.DataBindings.Add(new Binding("Text", resources, "gpu_temp_suffix", true, DataSourceUpdateMode.OnPropertyChanged));
            ram_usage_value.DataBindings.Add(new Binding("Text", resources, "ram_usage_value", true, DataSourceUpdateMode.OnPropertyChanged));
            ram_usage_suffix.DataBindings.Add(new Binding("Text", resources, "ram_usage_suffix", true, DataSourceUpdateMode.OnPropertyChanged));
            disk_read_value.DataBindings.Add(new Binding("Text", resources, "disk_read_value", true, DataSourceUpdateMode.OnPropertyChanged));
            disk_read_suffix.DataBindings.Add(new Binding("Text", resources, "disk_read_suffix", true, DataSourceUpdateMode.OnPropertyChanged));
            disk_write_value.DataBindings.Add(new Binding("Text", resources, "disk_write_value", true, DataSourceUpdateMode.OnPropertyChanged));
            disk_write_suffix.DataBindings.Add(new Binding("Text", resources, "disk_write_suffix", true, DataSourceUpdateMode.OnPropertyChanged));
            network_upload_value.DataBindings.Add(new Binding("Text", resources, "network_upload_value", true, DataSourceUpdateMode.OnPropertyChanged));
            network_upload_suffix.DataBindings.Add(new Binding("Text", resources, "network_upload_suffix", true, DataSourceUpdateMode.OnPropertyChanged));
            network_download_value.DataBindings.Add(new Binding("Text", resources, "network_download_value", true, DataSourceUpdateMode.OnPropertyChanged));
            network_download_suffix.DataBindings.Add(new Binding("Text", resources, "network_download_suffix", true, DataSourceUpdateMode.OnPropertyChanged));

            //Start collecting resources
            resources.Collect(computer);
        }

        private void cpu_Paint(object sender, PaintEventArgs e)
        {
            // Create pen.
            Pen pen = new Pen(cpu_header.ForeColor, 1);

            // Create rectangle.
            Rectangle rect = new Rectangle(0, 0, 70, 43);

            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(pen, rect);
        }

        private void gpu_Paint(object sender, PaintEventArgs e)
        {
            // Create pen.
            Pen pen = new Pen(gpu_header.ForeColor, 1);

            // Create rectangle.
            Rectangle rect = new Rectangle(0, 0, 70, 43);

            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(pen, rect);
        }

        private void ram_Paint(object sender, PaintEventArgs e)
        {
            // Create pen.
            Pen pen = new Pen(ram_header.ForeColor, 1);

            // Create rectangle.
            Rectangle rect = new Rectangle(0, 0, 70, 43);

            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(pen, rect);
        }

        private void disk_Paint(object sender, PaintEventArgs e)
        {
            // Create pen.
            Pen pen = new Pen(disk_header.ForeColor, 1);

            // Create rectangle.
            Rectangle rect = new Rectangle(0, 0, 70, 43);

            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(pen, rect);
        }

        private void network_Paint(object sender, PaintEventArgs e)
        {
            // Create pen.
            Pen pen = new Pen(network_header.ForeColor, 1);

            // Create rectangle.
            Rectangle rect = new Rectangle(0, 0, 70, 43);

            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(pen, rect);
        }

        /******************************************************************/
    }

    
}