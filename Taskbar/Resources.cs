using LibreHardwareMonitor.Hardware;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Taskbar
{
    public class Resources : INotifyPropertyChanged
    {
        /******************************************************************/
        #region Watched Variables

        #region CPU Values
        //*** CPU Usage Value ***//
        private string _cpu_usage_value;
        public string cpu_usage_value
        {
            get
            {
                return _cpu_usage_value;
            }
            set
            {
                _cpu_usage_value = value;
                OnPropertyChanged("cpu_usage_value");
            }
        }

        //*** CPU Usage Suffix ***//
        private string _cpu_usage_suffix;
        public string cpu_usage_suffix
        {
            get
            {
                return _cpu_usage_suffix;
            }
            set
            {
                _cpu_usage_suffix = value;
                OnPropertyChanged("cpu_usage_suffix");
            }
        }

        //*** CPU Temprature Value ***//
        private string _cpu_temp_value;
        public string cpu_temp_value
        {
            get
            {
                return _cpu_temp_value;
            }
            set
            {
                _cpu_temp_value = value;
                OnPropertyChanged("cpu_temp_value"); ;
            }
        }

        //*** CPU Temprature Suffix ***//
        private string _cpu_temp_suffix;
        public string cpu_temp_suffix
        {
            get
            {
                return _cpu_temp_suffix;
            }
            set
            {
                _cpu_temp_suffix = value;
                OnPropertyChanged("cpu_temp_suffix");
            }
        }
        #endregion

        #region GPU Values
        //*** GPU Usage Value ***//
        private string _gpu_usage_value;
        public string gpu_usage_value
        {
            get
            {
                return _gpu_usage_value;
            }
            set
            {
                _gpu_usage_value = value;
                OnPropertyChanged("gpu_usage_value");
            }
        }

        //*** GPU Usage Suffix ***//
        private string _gpu_usage_suffix;
        public string gpu_usage_suffix
        {
            get
            {
                return _gpu_usage_suffix;
            }
            set
            {
                _gpu_usage_suffix = value;
                OnPropertyChanged("gpu_usage_suffix");
            }
        }

        //*** GPU Temprature Value ***//
        private string _gpu_temp_value;
        public string gpu_temp_value
        {
            get
            {
                return _gpu_temp_value;
            }
            set
            {
                _gpu_temp_value = value;
                OnPropertyChanged("gpu_temp_value");
            }
        }

        //*** GPU Temprature Suffix ***//
        private string _gpu_temp_suffix;
        public string gpu_temp_suffix
        {
            get
            {
                return _gpu_temp_suffix;
            }
            set
            {
                _gpu_temp_suffix = value;
                OnPropertyChanged("gpu_temp_suffix");
            }
        }
        #endregion

        #region RAM Values
        //*** Ram Usage Value ***//
        private string _ram_usage_value;
        public string ram_usage_value
        {
            get
            {
                return _ram_usage_value;
            }
            set
            {
                _ram_usage_value = value;
                OnPropertyChanged("ram_usage_value");
            }
        }

        //*** Ram Usage Suffix ***//
        private string _ram_usage_suffix;
        public string ram_usage_suffix
        {
            get
            {
                return _ram_usage_suffix;
            }
            set
            {
                _ram_usage_suffix = value;
                OnPropertyChanged("ram_usage_suffix");
            }
        }
        #endregion

        #region Disk Values
        //*** Disk Read Value ***//
        private string _disk_read_value;
        public string disk_read_value
        {
            get
            {
                return _disk_read_value;
            }
            set
            {
                _disk_read_value = value;
                OnPropertyChanged("disk_read_value");
            }
        }

        //*** Disk Read Suffix ***//
        private string _disk_read_suffix;
        public string disk_read_suffix
        {
            get
            {
                return _disk_read_suffix;
            }
            set
            {
                _disk_read_suffix = value;
                OnPropertyChanged("disk_read_suffix");
            }
        }

        //*** Disk Write Value ***//
        private string _disk_write_value;
        public string disk_write_value
        {
            get
            {
                return _disk_write_value;
            }
            set
            {
                _disk_write_value = value;
                OnPropertyChanged("disk_write_value");
            }
        }

        //*** Disk Write Suffix ***//
        private string _disk_write_suffix;
        public string disk_write_suffix
        {
            get
            {
                return _disk_write_suffix;
            }
            set
            {
                _disk_write_suffix = value;
                OnPropertyChanged("disk_write_suffix");
            }
        }
        #endregion

        #region Network Values
        //*** Network Upload Value ***//
        private string _network_upload_value;
        public string network_upload_value
        {
            get
            {
                return _network_upload_value;
            }
            set
            {
                _network_upload_value = value;
                OnPropertyChanged("network_upload_value");
            }
        }

        //*** Network Upload Suffix ***//
        private string _network_upload_suffix;
        public string network_upload_suffix
        {
            get
            {
                return _network_upload_suffix;
            }
            set
            {
                _network_upload_suffix = value;
                OnPropertyChanged("network_upload_suffix");
            }
        }

        //*** Network Download Value ***//
        private string _network_download_value;
        public string network_download_value
        {
            get
            {
                return _network_download_value;
            }
            set
            {
                _network_download_value = value;
                OnPropertyChanged("network_download_value");
            }
        }

        //*** Network Download Suffix ***//
        private string _network_download_suffix;
        public string network_download_suffix
        {
            get
            {
                return _network_download_suffix;
            }
            set
            {
                _network_download_suffix = value;
                OnPropertyChanged("network_download_suffix");
            }
        }
        #endregion

        #endregion
        /******************************************************************/

        /******************************************************************/
        #region Variable Listener
        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        /******************************************************************/

        //*** Collect Resources ***//
        public async void Collect(Computer computer)
        {
            //Run async
            await Task.Run(() =>
            {
                //Set which values are scanned
                computer.IsCpuEnabled = true;
                computer.IsGpuEnabled = true;
                computer.IsMemoryEnabled = true;
                computer.IsStorageEnabled = true;
                computer.IsNetworkEnabled = true;

                //Start scanning values
                computer.Open();

                //Store values for atomic updating
                string temp_cpu_usage_value = "";
                string temp_cpu_usage_suffix = "";
                string temp_cpu_temp_value = "";
                string temp_cpu_temp_suffix = "";
                string temp_gpu_usage_value = "";
                string temp_gpu_usage_suffix = "";
                string temp_gpu_temp_value = "";
                string temp_gpu_temp_suffix = "";
                string temp_ram_usage_value = "";
                string temp_ram_usage_suffix = "";
                string temp_disk_read_value = "";
                string temp_disk_read_suffix = "";
                string temp_disk_write_value = "";
                string temp_disk_write_suffix = "";
                string temp_network_upload_value = "";
                string temp_network_upload_suffix = "";
                string temp_network_download_value = "";
                string temp_network_download_suffix = "";

                //Keep track of how many times looped
                int loop_counter = 0;

                //Keep scanning values forever
                while (true)
                {
                    //Scan each hardware type
                    foreach (IHardware hardware in computer.Hardware)
                    {
                        //Scan each hardware component for CPU's
                        if (hardware.HardwareType == HardwareType.Cpu)
                        {
                            //Force value update
                            hardware.Update();

                            //Scan for desired CPU sensors
                            foreach (var sensor in hardware.Sensors)
                            {
                                //Get CPU Usage value
                                if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("CPU Total"))
                                {
                                    temp_cpu_usage_value = ((int)sensor.Value.GetValueOrDefault()).ToString();
                                    temp_cpu_usage_suffix = "%";
                                }

                                //Get CPU Temperature value
                                if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("CPU Package"))
                                {
                                    temp_cpu_temp_value = ((int)sensor.Value.GetValueOrDefault()).ToString();
                                    temp_cpu_temp_suffix = "°C";
                                }
                            }
                        }

                        //Scan each hardware component for GPU's
                        else if (hardware.HardwareType == HardwareType.GpuNvidia)
                        {
                            //Force value update
                            hardware.Update();

                            //Scan for desired GPU sensors
                            foreach (var sensor in hardware.Sensors)
                            {
                                //Get GPU Usage value
                                if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("GPU Core"))
                                {
                                    temp_gpu_usage_value = ((int)sensor.Value.GetValueOrDefault()).ToString();
                                    temp_gpu_usage_suffix = "%";
                                }

                                //Get GPU Temperature value
                                if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("GPU Core"))
                                {
                                    temp_gpu_temp_value = ((int)sensor.Value.GetValueOrDefault()).ToString();
                                    temp_gpu_temp_suffix = "°C";
                                }
                            }
                        }

                        //Scan each hardware component for RAM
                        else if (hardware.HardwareType == HardwareType.Memory)
                        {
                            //Force value update
                            hardware.Update();

                            //Scan for desired RAM sensors
                            foreach (var sensor in hardware.Sensors)
                            {
                                //Get RAM Usage value
                                if (sensor.SensorType == SensorType.Load && sensor.Name == ("Memory"))
                                {
                                    temp_ram_usage_value = ((int)sensor.Value.GetValueOrDefault()).ToString();
                                    temp_ram_usage_suffix = "%";
                                }
                            }
                        }

                        //Scan each hardware component for Storage
                        else if (hardware.HardwareType == HardwareType.Storage)
                        {
                            //Force value update
                            hardware.Update();

                            //Scan for desired Disk sensors
                            foreach (var sensor in hardware.Sensors)
                            {
                                //Get Disk Usage value
                                if (sensor.SensorType == SensorType.Throughput && sensor.Name.Contains("Read Rate"))
                                {
                                    int temp_int = (int)sensor.Value.GetValueOrDefault();

                                    if (temp_int < 1024)
                                    {
                                        temp_disk_read_value = (temp_int).ToString();
                                        temp_disk_read_suffix = "B/s";
                                    }
                                    else if (temp_int < (1024 * 1024))
                                    {
                                        temp_disk_read_value = (temp_int / 1024).ToString();
                                        temp_disk_read_suffix = "KB/s";
                                    }
                                    else if (temp_int < (1024 * 1024 * 1024))
                                    {
                                        temp_disk_read_value = (temp_int / (1024 * 1024)).ToString();
                                        temp_disk_read_suffix = "MB/s";
                                    }
                                    else
                                    {
                                        temp_disk_read_value = (temp_int / (1024 * 1024 * 1024)).ToString();
                                        temp_disk_read_suffix = "GB/s";
                                    }
                                }

                                //Get Disk Usage value
                                if (sensor.SensorType == SensorType.Throughput && sensor.Name.Contains("Write Rate"))
                                {
                                    int temp_int = (int)sensor.Value.GetValueOrDefault();

                                    if (temp_int < 1024)
                                    {
                                        temp_disk_write_value = (temp_int).ToString();
                                        temp_disk_write_suffix = "B/s";
                                    }
                                    else if (temp_int < (1024 * 1024))
                                    {
                                        temp_disk_write_value = (temp_int / 1024).ToString();
                                        temp_disk_write_suffix = "KB/s";
                                    }
                                    else if (temp_int < (1024 * 1024 * 1024))
                                    {
                                        temp_disk_write_value = (temp_int / (1024 * 1024)).ToString();
                                        temp_disk_write_suffix = "MB/s";
                                    }
                                    else
                                    {
                                        temp_disk_write_value = (temp_int / (1024 * 1024 * 1024)).ToString();
                                        temp_disk_write_suffix = "GB/s";
                                    }
                                }
                            }

                        }

                        //Scan each hardware component for Network
                        else if (hardware.HardwareType == HardwareType.Network)
                        {
                            //Force value update
                            hardware.Update();

                            //Scan for desired Network sensors
                            foreach (var sensor in hardware.Sensors)
                            {
                                //Get Network Usage value
                                if (sensor.SensorType == SensorType.Throughput && sensor.Name.Contains("Upload Speed"))
                                {
                                    int temp_int = (int)sensor.Value.GetValueOrDefault();

                                    if (temp_int < 1024)
                                    {
                                        temp_network_upload_value = (temp_int).ToString();
                                        temp_network_upload_suffix = "B/s";
                                    }
                                    else if (temp_int < (1024 * 1024))
                                    {
                                        temp_network_upload_value = (temp_int / 1024).ToString();
                                        temp_network_upload_suffix = "KB/s";
                                    }
                                    else if (temp_int < (1024 * 1024 * 1024))
                                    {
                                        temp_network_upload_value = (temp_int / (1024 * 1024)).ToString();
                                        temp_network_upload_suffix = "MB/s";
                                    }
                                    else
                                    {
                                        temp_network_upload_value = (temp_int / (1024 * 1024 * 1024)).ToString();
                                        temp_network_upload_suffix = "GB/s";
                                    }
                                }

                                //Get Network Usage value
                                if (sensor.SensorType == SensorType.Throughput && sensor.Name.Contains("Download Speed"))
                                {
                                    int temp_int = (int)sensor.Value.GetValueOrDefault();

                                    if (temp_int < 1024)
                                    {
                                        temp_network_download_value = (temp_int).ToString();
                                        temp_network_download_suffix = "B/s";
                                    }
                                    else if (temp_int < (1024 * 1024))
                                    {
                                        temp_network_download_value = (temp_int / 1024).ToString();
                                        temp_network_download_suffix = "KB/s";
                                    }
                                    else if (temp_int < (1024 * 1024 * 1024))
                                    {
                                        temp_network_download_value = (temp_int / (1024 * 1024)).ToString();
                                        temp_network_download_suffix = "MB/s";
                                    }
                                    else
                                    {
                                        temp_network_download_value = (temp_int / (1024 * 1024 * 1024)).ToString();
                                        temp_network_download_suffix = "GB/s";
                                    }
                                }
                            }
                        }
                    }

                    //Update all values
                    cpu_usage_value = temp_cpu_usage_value;
                    cpu_usage_suffix = temp_cpu_usage_suffix;
                    cpu_temp_value = temp_cpu_temp_value;
                    cpu_temp_suffix = temp_cpu_temp_suffix;
                    gpu_usage_value = temp_gpu_usage_value;
                    gpu_usage_suffix = temp_gpu_usage_suffix;
                    gpu_temp_value = temp_gpu_temp_value;
                    gpu_temp_suffix = temp_gpu_temp_suffix;
                    ram_usage_value = temp_ram_usage_value;
                    ram_usage_suffix = temp_ram_usage_suffix;
                    disk_read_value = temp_disk_read_value;
                    disk_read_suffix = temp_disk_read_suffix;
                    disk_write_value = temp_disk_write_value;
                    disk_write_suffix = temp_disk_write_suffix;
                    network_upload_value = temp_network_upload_value;
                    network_upload_suffix = temp_network_upload_suffix;
                    network_download_value = temp_network_download_value;
                    network_download_suffix = temp_network_download_suffix;

                    //Delay for 500 ms before looping again
                    Thread.Sleep(500);

                    //Reload periodicly
                    if (loop_counter % 300 == 0)
                    {
                        computer.Reset();
                        loop_counter = 0;
                    }

                    //Increment counter
                    loop_counter++;
                }
            });
        }
    }
}
