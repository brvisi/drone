namespace IMU_sensor_headtracker
{
    class Sensors_structure

    {
        public float[] acc { get; set; }
        public float[] mag { get; set; }
        public float[] gyro { get; set; }
        public ulong timestamp { get; set; }
        public float gyro_integration_time { get; set; }
        public string client_info { get; set; }
        public float yaw { get; set; }
        public float pitch { get; set; }
        public float roll { get; set; }
        public float yaw_cal { get; set; }
        public float pitch_cal { get; set; }
        public float roll_cal { get; set; }
        public float yaw_dcm { get; set; }
        public float pitch_dcm { get; set; }
        public float roll_dcm { get; set; }
        public float[] acc_cali { get; set; }
        public float[] mag_cali { get; set; }
        public float[] gyro_scale { get; set; }
        public float[] gyro_cali { get; set; }
        public float yaw_offset { get; set; }
        public float[][] dcm_rotation_matrix { get; set; }
        public string udp_packet_sent { get; set; }
        public float[] comp_filter_angles { get; set; }

    };

    class Sensors_calibration
    {
        public float[] acc_max { get; set; }
        public float[] acc_min { get; set; }
        public float[] gyro_offset { get; set; }
        public float[] mag_max { get; set; }
        public float[] mag_min { get; set; }

    }

}
